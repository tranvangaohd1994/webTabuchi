using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class LineColorDay_DAL : Connect
    {
        #region getColorByColumn
        public string getColorByColumn(string nameColumn, int line, int planid)
        {
            string color = "";
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand("Select " + nameColumn + " from LineColorDay where [LineName] ='" + line + "' and [PlanId] = '" + planid + "'", this.openConnection()))
                {
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("@nameColumn", nameColumn));
                    //cmd.Parameters.Add(new SqlParameter("@Line", line));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        color = dt.Rows[0][0].ToString().Trim();
                    }
                   
                }
            }
            catch (Exception) { 
                
            }
            this.closeConnection();
            return color;
        }
        #endregion
    }
}
