using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
namespace DAL
{
    public class LineInput_DAL : Connect
    {
        #region LineDay_UpdateChangeModel
        public bool LineDay_UpdateChangeModel(int line,string value)
        {
            int result = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand("Update LineInputDay set ChangeModel = @ChangeModel WHERE LineName = @Line and PlanId = @PlanId", openConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Line", line));
                    cmd.Parameters.Add(new SqlParameter("@ChangeModel", value));

                    result = cmd.ExecuteNonQuery();
                    this.closeConnection();
                }
            }
            catch(Exception){

            }
            return result > 0;
        }
        #endregion

        #region LineDay_UpdateRS
        public bool LineDay_UpdateRS(int line, bool value)
        {
            int result = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand("LineDay_UpdateRS", openConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Line", line));
                    cmd.Parameters.Add(new SqlParameter("@RS", value));
                    result = cmd.ExecuteNonQuery();
                    this.closeConnection();
                }
            }
            catch (Exception) { 
            }
            return result > 0;
        }
        #endregion

        #region LineInputSelectByRs
        public DataTable LineInputSelectByRS()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand command = new SqlCommand("Select * from LineInputDay where RS=1", openConnection()))
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }
            }
            catch(Exception){
                dt = null;
            }
            this.closeConnection();
            return dt;
        }
        #endregion

        public bool LineInput_GetRSByLine(int line,int planid)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand command = new SqlCommand("Select RS from LineInputDay where LineName = @Line And PlanId=@PlanId", openConnection()))
                {
                    command.Parameters.Add(new SqlParameter("@PlanId", planid));
                    command.Parameters.Add(new SqlParameter("@Line", line));
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt); 
                }
            }
            catch (System.Exception)
            {

            }
            finally {
                this.closeConnection();
                
            }
            string result = dt.Rows[0][0].ToString();
            if (result.Equals("True"))
            {
                return true;
            }
            return false;
        }

        public DataTable LineInput_GetAllLines(int planid)
        {
            DataTable dt = new DataTable();
            using (SqlCommand command = new SqlCommand("Select * FROM LineInputDay WHERE PlanId = @PlanId AND Model <> @Model", openConnection()))
            {
                command.Parameters.Add(new SqlParameter("@Model", "Stocking"));
                command.Parameters.Add(new SqlParameter("@PlanId", planid));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                this.closeConnection();
                return dt;
            }
        }

        public LineInputDay LineInput_GetStocking(int planid)
        {
            DataTable dt = new DataTable();
            LineInputDay line_ = new LineInputDay();
            using (SqlCommand command = new SqlCommand("Select * FROM LineInputDay Where Model = @Model AND PlanId = @PlanId", openConnection()))
            {
                command.Parameters.Add(new SqlParameter("@Model", "Stocking"));
                command.Parameters.Add(new SqlParameter("@PlanId", planid));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                int i = 0;
                this.closeConnection();
                line_.line = int.Parse(dt.Rows[0]["LineName"].ToString());
                if (int.TryParse(dt.Rows[0]["Actual"].ToString(), out i))
                {
                    line_.actual = i;
                }
                if (int.TryParse(dt.Rows[0]["Plan"].ToString(), out i))
                {
                    line_.plan = i;
                }
                if (int.TryParse(dt.Rows[0]["Diff"].ToString(), out i))
                {
                    line_.diff = i;
                }
                if (int.TryParse(dt.Rows[0]["Target"].ToString(), out i))
                {
                    line_.target = i;
                }
                if (int.TryParse(dt.Rows[0]["H07"].ToString(), out i))
                {
                    line_.h07 = i;
                }
                if (int.TryParse(dt.Rows[0]["H08"].ToString(), out i))
                {
                    line_.h08 = i;
                }
                if (int.TryParse(dt.Rows[0]["H09"].ToString(), out i))
                {
                    line_.h09 = i;
                }
                if (int.TryParse(dt.Rows[0]["H10"].ToString(), out i))
                {
                    line_.h10 = i;
                }
                if (int.TryParse(dt.Rows[0]["H11"].ToString(), out i))
                {
                    line_.h11 = i;
                }
                if (int.TryParse(dt.Rows[0]["H12"].ToString(), out i))
                {
                    line_.h12 = i;
                }
                if (int.TryParse(dt.Rows[0]["H13"].ToString(), out i))
                {
                    line_.h13 = i;
                }
                if (int.TryParse(dt.Rows[0]["H14"].ToString(), out i))
                {
                    line_.h14 = i;
                }
                if (int.TryParse(dt.Rows[0]["H15"].ToString(), out i))
                {
                    line_.h15 = i;
                }
                if (int.TryParse(dt.Rows[0]["H16"].ToString(), out i))
                {
                    line_.h16 = i;
                }
                if (int.TryParse(dt.Rows[0]["H17"].ToString(), out i))
                {
                    line_.h17 = i;
                }
                if (int.TryParse(dt.Rows[0]["H18"].ToString(), out i))
                {
                    line_.h18 = i;
                }
                line_.comment = dt.Rows[0]["Comments"].ToString();
                line_.status = dt.Rows[0]["Status"].ToString();
            }
            return line_;
        }

        public DataTable LineInput_ToExportExcel(int planid)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand command = new SqlCommand("Select [Model],[RS],[ChangeModel],[Planed_Worker],[Actual_Worker],[Plan],[Tact_Time],[Total_Minute],[Actual],[Diff],[Target],[From1],[To1],[From2],[To2],[From3],[To3],[From4],[To4],[From5],[To5],[From6],[To6],[Rank],[Comments] FROM  LineInputDay Where PlanId = @PlanId", openConnection()))
                {
                    command.Parameters.Add(new SqlParameter("@PlanId", planid));
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                   
                }
            }
            catch(Exception) {
                dt = null;
            }
            this.closeConnection();
            return dt;
        }

        public bool LineInput_InsertNewDay(int planid)
        {
            bool isDone = false;
            return isDone;
        }

        public bool LineInput_ChangeActual(int line, bool value, int planid)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("Update LineInputDay SET ChangedPlaned = @ChangedPlaned Where LineName = @Line and PlanId = @PlanId", openConnection()))
                {
                    cmd.Parameters.Add(new SqlParameter("@Line", line));
                    cmd.Parameters.Add(new SqlParameter("@PlanId", planid));
                    cmd.Parameters.Add(new SqlParameter("@ChangedPlaned", value));
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception){
                return false;
            }
            
        }
    }
}
