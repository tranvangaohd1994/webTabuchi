using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Entity;
using Common;
using System.Data.SqlClient;
namespace DAL
{
    public class LineInputNight_DAL_base : Connect
    {
        Common.CommonFuntion commonFun = new Common.CommonFuntion();

        #region LineInputNightSelectAll
        public DataTable LineInputNightSelectAll(int planid)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand command = new SqlCommand("Select * from LineInputNight where PlanId = @PlanId", openConnection()))
                {
                    command.Parameters.AddWithValue("@PlanId", planid);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                    
                }
            }
            catch (System.Exception) {
                dt = null;
            }
            this.closeConnection();
            return dt;
        }
        #endregion

        #region LineInputNightSelectById
        public LineInputNight LineInputSelectNightByLine(int line, int planid)
        {
            DataTable dt = new DataTable();
            LineInputNight objLine = new LineInputNight();
            try
            {
                using (SqlCommand command = new SqlCommand("LineInputNight_SelectByLine", openConnection()))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Line", line);
                    command.Parameters.AddWithValue("@PlanId", planid);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                    
                    objLine.line = int.Parse(dt.Rows[0]["LineName"].ToString());
                    objLine.rs = bool.Parse(dt.Rows[0]["RS"].ToString());
                    objLine.model = dt.Rows[0]["Model"].ToString();
                    objLine.changemodel = dt.Rows[0]["ChangeModel"].ToString();
                    objLine.planed_woker = commonFun.ConvertInt2(dt.Rows[0]["Planed_Worker"].ToString());
                    objLine.actual_woker = commonFun.ConvertInt2(dt.Rows[0]["Actual_Worker"].ToString());
                    objLine.acchived_rate = (float)commonFun.ConvertDouble(dt.Rows[0]["Archived_Rate"].ToString());
                    objLine.rank = dt.Rows[0]["Rank"].ToString();
                    objLine.plan = commonFun.ConvertInt2(dt.Rows[0]["Plan"].ToString());
                    objLine.tact_time = (float)commonFun.ConvertDouble(dt.Rows[0]["Tact_Time"].ToString());
                    objLine.total_min = commonFun.ConvertInt2(dt.Rows[0]["Total_Minute"].ToString());
                    objLine.actual = commonFun.ConvertInt2(dt.Rows[0]["Actual"].ToString());
                    objLine.diff = commonFun.ConvertInt2(dt.Rows[0]["Diff"].ToString());
                    objLine.target = commonFun.ConvertInt2(dt.Rows[0]["Target"].ToString());
                    objLine.h19 = commonFun.ConvertInt2(dt.Rows[0]["H19"].ToString());
                    objLine.h20 = commonFun.ConvertInt2(dt.Rows[0]["H20"].ToString());
                    objLine.h21 = commonFun.ConvertInt2(dt.Rows[0]["H21"].ToString());
                    objLine.h22 = commonFun.ConvertInt2(dt.Rows[0]["H22"].ToString());
                    objLine.h23 = commonFun.ConvertInt2(dt.Rows[0]["H23"].ToString());
                    objLine.h00 = commonFun.ConvertInt2(dt.Rows[0]["H00"].ToString());
                    objLine.h01 = commonFun.ConvertInt2(dt.Rows[0]["H01"].ToString());
                    objLine.h02 = commonFun.ConvertInt2(dt.Rows[0]["H02"].ToString());
                    objLine.h03 = commonFun.ConvertInt2(dt.Rows[0]["H03"].ToString());
                    objLine.h04 = commonFun.ConvertInt2(dt.Rows[0]["H04"].ToString());
                    objLine.h05 = commonFun.ConvertInt2(dt.Rows[0]["H05"].ToString());
                    objLine.h06 = commonFun.ConvertInt2(dt.Rows[0]["H06"].ToString());
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
            catch (System.Exception) { 
            }
            this.closeConnection();
            return objLine;
        }
        #endregion

        #region LineInput Night Insert
        public bool LineInputNightInsert(LineInputNight line)
        {
            int result = 0;
            using (SqlCommand command = new SqlCommand("LineInputNight_Insert", openConnection()))
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

                    command.Parameters.Add(new SqlParameter("@To6", null));
                    command.Parameters.Add(new SqlParameter("@H19", null));
                    command.Parameters.Add(new SqlParameter("@H20", null));
                    command.Parameters.Add(new SqlParameter("@H21", null));
                    command.Parameters.Add(new SqlParameter("@H22", null));
                    command.Parameters.Add(new SqlParameter("@H23", null));
                    command.Parameters.Add(new SqlParameter("@H00", null));
                    command.Parameters.Add(new SqlParameter("@H01", null));
                    command.Parameters.Add(new SqlParameter("@H02", null));
                    command.Parameters.Add(new SqlParameter("@H03", null));
                    command.Parameters.Add(new SqlParameter("@H04", null));
                    command.Parameters.Add(new SqlParameter("@H05", null));
                    command.Parameters.Add(new SqlParameter("@H06", null));
                    /*
                    command.Parameters.Add(new SqlParameter("@To6", line.to6));
                    command.Parameters.Add(new SqlParameter("@H19", line.h19));
                    command.Parameters.Add(new SqlParameter("@H20", line.h20));
                    command.Parameters.Add(new SqlParameter("@H21", line.h21));
                    command.Parameters.Add(new SqlParameter("@H22", line.h22));
                    command.Parameters.Add(new SqlParameter("@H23", line.h23));
                    command.Parameters.Add(new SqlParameter("@H00", line.h00));
                    command.Parameters.Add(new SqlParameter("@H01", line.h01));
                    command.Parameters.Add(new SqlParameter("@H02", line.h02));
                    command.Parameters.Add(new SqlParameter("@H03", line.h03));
                    command.Parameters.Add(new SqlParameter("@H04", line.h04));
                    command.Parameters.Add(new SqlParameter("@H05", line.h05));
                    command.Parameters.Add(new SqlParameter("@H06", line.h06));
                    */
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

        #region LineInput Night Update
        public bool LineInputNightUpdate(LineInputNight line)
        {
            int result = 0;
            using (SqlCommand command = new SqlCommand("LineInputNight_Update", openConnection()))
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
                    //
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
                    //
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
                    //
                    if (line.h19 == -1)
                        command.Parameters.Add(new SqlParameter("@H19", null));
                    else
                        command.Parameters.Add(new SqlParameter("@H19", line.h19));
                    //
                    if (line.h20 == -1)
                        command.Parameters.Add(new SqlParameter("@H20", null));
                    else
                        command.Parameters.Add(new SqlParameter("@H20", line.h20));
                    //
                    if (line.h21 == -1)
                        command.Parameters.Add(new SqlParameter("@H21", null));
                    else
                        command.Parameters.Add(new SqlParameter("@H21", line.h21));
                    //
                    if (line.h22 == -1)
                        command.Parameters.Add(new SqlParameter("@H22", null));
                    else
                        command.Parameters.Add(new SqlParameter("@H22", line.h22));
                    //
                    if (line.h23 == -1)
                        command.Parameters.Add(new SqlParameter("@H23", null));
                    else
                        command.Parameters.Add(new SqlParameter("@H23", line.h23));
                    //
                    if (line.h00 == -1)
                        command.Parameters.Add(new SqlParameter("@H00", null));
                    else
                        command.Parameters.Add(new SqlParameter("@H00", line.h00));
                    //
                    if (line.h01 == -1)
                        command.Parameters.Add(new SqlParameter("@H01", null));
                    else
                        command.Parameters.Add(new SqlParameter("@H01", line.h01));
                    //
                    if (line.h02 == -1)
                        command.Parameters.Add(new SqlParameter("@H02", null));
                    else
                        command.Parameters.Add(new SqlParameter("@H02", line.h02));
                    //
                    if (line.h03 == -1)
                        command.Parameters.Add(new SqlParameter("@H03", null));
                    else
                        command.Parameters.Add(new SqlParameter("@H03", line.h03));
                    //
                    if (line.h04 == -1)
                        command.Parameters.Add(new SqlParameter("@H04", null));
                    else
                        command.Parameters.Add(new SqlParameter("@H04", line.h04));
                    //
                    if (line.h05 == -1)
                        command.Parameters.Add(new SqlParameter("@H05", null));
                    else
                        command.Parameters.Add(new SqlParameter("@H05", line.h05));
                    if (line.h06 == -1)
                        command.Parameters.Add(new SqlParameter("@H06", null));
                    else
                        command.Parameters.Add(new SqlParameter("@H06", line.h06));
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

        #region LineInput Night Delete
        public bool LineInputNightDelete(int line)
        {
            int result = 0;
            using (SqlCommand command = new SqlCommand("LineInputNight_DeleteByLine", openConnection()))
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
