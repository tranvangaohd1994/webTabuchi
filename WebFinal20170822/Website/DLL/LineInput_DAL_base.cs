using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
namespace DAL
{
    public class LineInput_DAL_base : Connect
    {

        #region LineInputSelectAll
        public DataTable LineInputSelectAll(int planid)
        {
            DataTable dt = new DataTable();
            using (SqlCommand command = new SqlCommand("Select * from LineInputDay Where PlanId=@PlanId", openConnection()))
            {
                command.Parameters.AddWithValue("@PlanId", planid);
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                this.closeConnection();
                return dt;
            }
        }
        #endregion

        Common.CommonFuntion commonFun = new Common.CommonFuntion();
        #region LineInputSelectById
        public LineInputDay LineInputSelectByLine(int linename, int planid)
        {
            DataTable dt = new DataTable();
            LineInputDay objLine = new LineInputDay();
            try
            {
                using (SqlCommand command = new SqlCommand("Select * from LineInputDay where LineName = @LineName and PlanId = @PlanId", openConnection()))
                {
                    command.Parameters.AddWithValue("@LineName", linename);
                    command.Parameters.AddWithValue("@PlanId", planid);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                    
                    objLine.line = int.Parse(dt.Rows[0]["LineName"].ToString());
                    objLine.rs = bool.Parse(dt.Rows[0]["RS"].ToString());
                    objLine.model = dt.Rows[0]["Model"].ToString();
                    objLine.changemodel = dt.Rows[0]["ChangeModel"].ToString();
                    objLine.planed_woker = commonFun.ConvertInt2(dt.Rows[0]["Planed_Worker"].ToString());
                    objLine.actual_woker = commonFun.ConvertInt2(dt.Rows[0]["Actual_Worker"].ToString());
                    objLine.plan = commonFun.ConvertInt2(dt.Rows[0]["Plan"].ToString());
                    objLine.acchived_rate = (float)commonFun.ConvertDouble(dt.Rows[0]["Archived_Rate"].ToString());
                    objLine.rank = dt.Rows[0]["Rank"].ToString();
                    objLine.tact_time = (float)commonFun.ConvertDouble(dt.Rows[0]["Tact_Time"].ToString());
                    objLine.total_min = commonFun.ConvertInt2(dt.Rows[0]["Total_Minute"].ToString());
                    objLine.actual = commonFun.ConvertInt2(dt.Rows[0]["Actual"].ToString());
                    objLine.diff = commonFun.ConvertInt2(dt.Rows[0]["Diff"].ToString());
                    objLine.target = commonFun.ConvertInt2(dt.Rows[0]["Target"].ToString());
                    objLine.h07 = commonFun.ConvertInt2(dt.Rows[0]["H07"].ToString());
                    objLine.h08 = commonFun.ConvertInt2(dt.Rows[0]["H08"].ToString());
                    objLine.h09 = commonFun.ConvertInt2(dt.Rows[0]["H09"].ToString());
                    objLine.h10 = commonFun.ConvertInt2(dt.Rows[0]["H10"].ToString());
                    objLine.h11 = commonFun.ConvertInt2(dt.Rows[0]["H11"].ToString());
                    objLine.h12 = commonFun.ConvertInt2(dt.Rows[0]["H12"].ToString());
                    objLine.h13 = commonFun.ConvertInt2(dt.Rows[0]["H13"].ToString());
                    objLine.h14 = commonFun.ConvertInt2(dt.Rows[0]["H14"].ToString());
                    objLine.h15 = commonFun.ConvertInt2(dt.Rows[0]["H15"].ToString());
                    objLine.h16 = commonFun.ConvertInt2(dt.Rows[0]["H16"].ToString());
                    objLine.h17 = commonFun.ConvertInt2(dt.Rows[0]["H17"].ToString());
                    objLine.h18 = commonFun.ConvertInt2(dt.Rows[0]["H18"].ToString());
                    objLine.from1 = dt.Rows[0]["From1"].ToString();
                    objLine.to1 = dt.Rows[0]["To1"].ToString();
                    objLine.from2 = dt.Rows[0]["From2"].ToString();
                    objLine.to2 = dt.Rows[0]["To2"].ToString();
                    objLine.from3 = dt.Rows[0]["From3"].ToString();
                    objLine.to3 = dt.Rows[0]["To3"].ToString();
                    objLine.from4 = dt.Rows[0]["From4"].ToString();
                    objLine.to4 = dt.Rows[0]["To4"].ToString();
                    objLine.from5 = dt.Rows[0]["From5"].ToString();
                    objLine.to5 = dt.Rows[0]["To5"].ToString();
                    objLine.from6 = dt.Rows[0]["From6"].ToString();
                    objLine.to6 = dt.Rows[0]["To6"].ToString();
                    objLine.comment = dt.Rows[0]["Comments"].ToString();
                    objLine.status = dt.Rows[0]["Status"].ToString();
                    objLine.changedActual = bool.Parse(dt.Rows[0]["ChangedPlaned"].ToString());
                    
                }
            }
            catch (Exception) {
                objLine = null;
            }
            this.closeConnection();
            return objLine;
        }
        #endregion

        #region LineInputInsert
        public bool LineInputInsert(LineInputDay line)
        {
            int result = 0;
            using (SqlCommand command = new SqlCommand("LineInput_Insert", openConnection()))
            {
                try
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@LineName", line.line));
                    command.Parameters.Add(new SqlParameter("@PlanId", line.planid));
                    command.Parameters.Add(new SqlParameter("@Model", line.model));
                    command.Parameters.Add(new SqlParameter("@ModelA", line.modelA));
                    command.Parameters.Add(new SqlParameter("@ModelB", line.modelB));
                    command.Parameters.Add(new SqlParameter("@ModelC", line.modelC));
                    command.Parameters.Add(new SqlParameter("@RS", line.rs));
                    command.Parameters.Add(new SqlParameter("@Planed_Worker", line.planed_woker));
                    command.Parameters.Add(new SqlParameter("@Actual_Worker", line.actual_woker));
                    command.Parameters.Add(new SqlParameter("@Plan", line.plan));
                    command.Parameters.Add(new SqlParameter("@Tact_Time", line.tact_time));
                    command.Parameters.Add(new SqlParameter("@Total_Minute", line.total_min));

                    command.Parameters.Add(new SqlParameter("@Actual", null));
                    command.Parameters.Add(new SqlParameter("@Diff", null));
                    command.Parameters.Add(new SqlParameter("@Target", null));
                    /*
                    command.Parameters.Add(new SqlParameter("@Actual", line.actual));
                    command.Parameters.Add(new SqlParameter("@Diff", line.diff));
                    command.Parameters.Add(new SqlParameter("@Target", line.target));
                    */
                    command.Parameters.Add(new SqlParameter("@Archived_Rate", line.acchived_rate));
                    command.Parameters.Add(new SqlParameter("@Rank", line.rank));
                    command.Parameters.Add(new SqlParameter("@From1", line.from1));
                    command.Parameters.Add(new SqlParameter("@To1", line.to1));
                    command.Parameters.Add(new SqlParameter("@From2", line.from2));
                    command.Parameters.Add(new SqlParameter("@To2", line.to2));
                    command.Parameters.Add(new SqlParameter("@From3", line.from3));
                    command.Parameters.Add(new SqlParameter("@To3", line.to3));
                    command.Parameters.Add(new SqlParameter("@From4", line.from4));
                    command.Parameters.Add(new SqlParameter("@To4", line.to4));
                    command.Parameters.Add(new SqlParameter("@From5", line.from5));
                    command.Parameters.Add(new SqlParameter("@To5", line.to5));
                    command.Parameters.Add(new SqlParameter("@From6", line.from6));
                    command.Parameters.Add(new SqlParameter("@To6", line.to6));


                    command.Parameters.Add(new SqlParameter("@H07", null));
                    command.Parameters.Add(new SqlParameter("@H08", null));
                    command.Parameters.Add(new SqlParameter("@H09", null));
                    command.Parameters.Add(new SqlParameter("@H10", null));
                    command.Parameters.Add(new SqlParameter("@H11", null));
                    command.Parameters.Add(new SqlParameter("@H12", null));
                    command.Parameters.Add(new SqlParameter("@H13", null));
                    command.Parameters.Add(new SqlParameter("@H14", null));
                    command.Parameters.Add(new SqlParameter("@H15", null));
                    command.Parameters.Add(new SqlParameter("@H16", null));
                    command.Parameters.Add(new SqlParameter("@H17", null));
                    command.Parameters.Add(new SqlParameter("@H18", null));
                    
                    command.Parameters.Add(new SqlParameter("@Comments", line.comment));
                    command.Parameters.Add(new SqlParameter("@Status", line.status));
                    result = command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    return false;
                }
                finally
                {
                    this.closeConnection();
                }
                return result > 0;
            }
        }
        #endregion

        #region LineInputUpdate
        public bool LineInputUpdate(LineInputDay line)
        {
            int result = 0;
            using (SqlCommand command = new SqlCommand("LineInput_Update", openConnection()))
            {
                try
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@LineName", line.line));
                    command.Parameters.Add(new SqlParameter("@PlanId", line.planid));
                    command.Parameters.Add(new SqlParameter("@Model", line.model));
                    command.Parameters.Add(new SqlParameter("@ModelA", line.modelA));
                    command.Parameters.Add(new SqlParameter("@ModelB", line.modelB));
                    command.Parameters.Add(new SqlParameter("@ModelC", line.modelC));
                    command.Parameters.Add(new SqlParameter("@RS", line.rs));
                    command.Parameters.Add(new SqlParameter("@ChangeModel", line.changemodel));
                    if (line.planed_woker == -1)
                        command.Parameters.Add(new SqlParameter("@Planed_Worker", null));
                    else
                        command.Parameters.Add(new SqlParameter("@Planed_Worker", line.planed_woker));
                    //
                    if (line.actual_woker == -1)
                        command.Parameters.Add(new SqlParameter("@Actual_Worker", null));
                    else
                        command.Parameters.Add(new SqlParameter("@Actual_Worker", line.actual_woker));
                    //
                    if (line.plan == -1)
                        command.Parameters.Add(new SqlParameter("@Plan", null));
                    else
                        command.Parameters.Add(new SqlParameter("@Plan", line.plan));
                    //
                    command.Parameters.Add(new SqlParameter("@Tact_Time", line.tact_time));
                    //
                    if (line.total_min == -1)
                        command.Parameters.Add(new SqlParameter("@Total_Minute", null));
                    else
                        command.Parameters.Add(new SqlParameter("@Total_Minute", line.total_min));
                    //
                    if (line.actual == -1)
                        command.Parameters.Add(new SqlParameter("@Actual", null));
                    else
                        command.Parameters.Add(new SqlParameter("@Actual", line.actual));
                    //
                    if (line.diff == -1)
                        command.Parameters.Add(new SqlParameter("@Diff", null));
                    else
                        command.Parameters.Add(new SqlParameter("@Diff", line.diff));
                    //
                    if (line.target == -1)
                        command.Parameters.Add(new SqlParameter("@Target", null));
                    else
                        command.Parameters.Add(new SqlParameter("@Target", line.target));
                    command.Parameters.Add(new SqlParameter("@Archived_Rate", line.acchived_rate));
                    command.Parameters.Add(new SqlParameter("@Rank", line.rank));
                    command.Parameters.Add(new SqlParameter("@From1", line.from1));
                    command.Parameters.Add(new SqlParameter("@To1", line.to1));
                    command.Parameters.Add(new SqlParameter("@From2", line.from2));
                    command.Parameters.Add(new SqlParameter("@To2", line.to2));
                    command.Parameters.Add(new SqlParameter("@From3", line.from3));
                    command.Parameters.Add(new SqlParameter("@To3", line.to3));
                    command.Parameters.Add(new SqlParameter("@From4", line.from4));
                    command.Parameters.Add(new SqlParameter("@To4", line.to4));
                    command.Parameters.Add(new SqlParameter("@From5", line.from5));
                    command.Parameters.Add(new SqlParameter("@To5", line.to5));
                    command.Parameters.Add(new SqlParameter("@From6", line.from6));
                    command.Parameters.Add(new SqlParameter("@To6", line.to6));
                    if (line.h07 == -1)
                        command.Parameters.Add(new SqlParameter("@H07", null));
                    else
                        command.Parameters.Add(new SqlParameter("@H07", line.h07));
                    if (line.h08 == -1)
                        command.Parameters.Add(new SqlParameter("@H08", null));
                    else
                        command.Parameters.Add(new SqlParameter("@H08", line.h08));
                    if (line.h09 == -1)
                        command.Parameters.Add(new SqlParameter("@H09", null));
                    else
                        command.Parameters.Add(new SqlParameter("@H09", line.h09));
                    if (line.h10 == -1)
                        command.Parameters.Add(new SqlParameter("@H10", null));
                    else
                        command.Parameters.Add(new SqlParameter("@H10", line.h10));
                    if (line.h11 == -1)
                        command.Parameters.Add(new SqlParameter("@H11", null));
                    else
                        command.Parameters.Add(new SqlParameter("@H11", line.h11));
                    if (line.h12 == -1)
                        command.Parameters.Add(new SqlParameter("@H12", null));
                    else
                        command.Parameters.Add(new SqlParameter("@H12", line.h12));
                    if (line.h13 == -1)
                        command.Parameters.Add(new SqlParameter("@H13", null));
                    else
                        command.Parameters.Add(new SqlParameter("@H13", line.h13));
                    if (line.h14 == -1)
                        command.Parameters.Add(new SqlParameter("@H14", null));
                    else
                        command.Parameters.Add(new SqlParameter("@H14", line.h14));
                    if (line.h15 == -1)
                        command.Parameters.Add(new SqlParameter("@H15", null));
                    else
                        command.Parameters.Add(new SqlParameter("@H15", line.h15));
                    if (line.h16 == -1)
                        command.Parameters.Add(new SqlParameter("@H16", null));
                    else
                        command.Parameters.Add(new SqlParameter("@H16", line.h16));
                    if (line.h17 == -1)
                        command.Parameters.Add(new SqlParameter("@H17", null));
                    else
                        command.Parameters.Add(new SqlParameter("@H17", line.h17));
                    if (line.h18 == -1)
                        command.Parameters.Add(new SqlParameter("@H18", null));
                    else
                        command.Parameters.Add(new SqlParameter("@H18", line.h18));
                    command.Parameters.Add(new SqlParameter("@Comments", line.comment));
                    command.Parameters.Add(new SqlParameter("@Status", line.status));
                    result = command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    return false;
                }
                finally
                {
                    this.closeConnection();
                }
                return result > 0;
            }
        }
        #endregion

        #region LineInputDelete
        public bool LineInputDelete(int line)
        {
            int result = 0;
            using (SqlCommand command = new SqlCommand("LineInputDB_DeleteByLine", openConnection()))
            {
                try
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Line", line));
                    result = command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    return false;
                }
                finally
                {
                    this.closeConnection();
                }
                return result > 0;
            }
        }
        #endregion
    }
}
