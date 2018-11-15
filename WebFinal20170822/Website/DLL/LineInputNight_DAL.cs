using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
namespace DAL
{
    public class LineInputNight_DAL : Connect
    {
        #region LineNight_UpdateChangeModel
        public bool LineNight_UpdateChangeModel(int line, string value)
        {
            int result = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand("LineNight_UpdateChangeModel", openConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Line", line));
                    cmd.Parameters.Add(new SqlParameter("@ChangeModel", value));
                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Exception) { 
            }
            this.closeConnection();
            return result > 0;
        }
        #endregion

        #region LineNight_UpdateRS
        public bool LineNight_UpdateRS(int line, bool value)
        {
            int result = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand("LineNight_UpdateRS", openConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Line", line));
                    cmd.Parameters.Add(new SqlParameter("@RS", value));
                    result = cmd.ExecuteNonQuery();
                }
            }
            catch { 
                
            }
            this.closeConnection();
            return result > 0;
        }
        #endregion

        #region LineInputSelectByRs
        public DataTable LineInputSelectByRS()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand command = new SqlCommand("Select * from LineInputNight where RS=1", openConnection()))
                {
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

        public bool LineNight_GetRSByLine(int line,int planId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand command = new SqlCommand("Select RS from LineInputNight where LineName = @LineName AND PlanId= @PlanId", openConnection()))
                {
                    command.Parameters.Add(new SqlParameter("@LineName", line));
                    command.Parameters.Add(new SqlParameter("@PlanId", planId));
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                    
                }
            }
            catch (System.Exception) { 
            }
            string result = dt.Rows[0][0].ToString();
            this.closeConnection();
            if (result.Equals("True"))
            {
                return true;
            }
            return false;
        }

        public DataTable LineNight_GetAllLines(int planid)
        {
            DataTable dt = new DataTable();
            using (SqlCommand command = new SqlCommand("SELECT * FROM  LineInputNight WHERE PlanId = @PlanId AND Model <> @Model", openConnection()))
            {
                command.Parameters.Add(new SqlParameter("@Model", "Stocking"));
                command.Parameters.Add(new SqlParameter("@PlanId", planid));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                this.closeConnection();
                return dt;
            }
        }

        public LineInputNight LineNight_GetStocking(int planid)
        {
            DataTable dt = new DataTable();
            LineInputNight line_ = new LineInputNight();
            using (SqlCommand command = new SqlCommand("Select * FROM  LineInputNight Where Model = @Model And PlanId= @PlanId", openConnection()))
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
                if (int.TryParse(dt.Rows[0]["H19"].ToString(), out i))
                {
                    line_.h19 = i;
                }
                if (int.TryParse(dt.Rows[0]["H20"].ToString(), out i))
                {
                    line_.h20 = i;
                }
                if (int.TryParse(dt.Rows[0]["H21"].ToString(), out i))
                {
                    line_.h21 = i;
                }
                if (int.TryParse(dt.Rows[0]["H22"].ToString(), out i))
                {
                    line_.h22 = i;
                }
                if (int.TryParse(dt.Rows[0]["H23"].ToString(), out i))
                {
                    line_.h23 = i;
                }
                if (int.TryParse(dt.Rows[0]["H00"].ToString(), out i))
                {
                    line_.h00 = i;
                }
                if (int.TryParse(dt.Rows[0]["H01"].ToString(), out i))
                {
                    line_.h01 = i;
                }
                if (int.TryParse(dt.Rows[0]["H02"].ToString(), out i))
                {
                    line_.h02 = i;
                }
                if (int.TryParse(dt.Rows[0]["H03"].ToString(), out i))
                {
                    line_.h03 = i;
                }
                if (int.TryParse(dt.Rows[0]["H04"].ToString(), out i))
                {
                    line_.h04 = i;
                }
                if (int.TryParse(dt.Rows[0]["H05"].ToString(), out i))
                {
                    line_.h05 = i;
                }
                if (int.TryParse(dt.Rows[0]["H06"].ToString(), out i))
                {
                    line_.h06 = i;
                }
                line_.comment = dt.Rows[0]["Comments"].ToString();
                line_.status = dt.Rows[0]["Status"].ToString();
            }
            return line_;
        }

        public DataTable LineInputNight_ToExportExcel(int planid)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand command = new SqlCommand("Select [Model],[RS],[ChangeModel],[Planed_Worker],[Actual_Worker],[Plan],[Tact_Time],[Total_Minute],[Actual],[Diff],[Target],[From1],[To1],[From2],[To2],[From3],[To3],[From4],[To4],[From5],[To5],[From6],[To6],[Rank],[Comments] FROM  LineInputNight Where PlanId= @PlanId", openConnection()))
                {
                    command.Parameters.Add(new SqlParameter("@PlanId", planid));
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

        public bool LineInputNight_ChangeActual(int line, bool value, int planid)
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
            catch (System.Exception) {
                return false;
            }
        }
    }
}
