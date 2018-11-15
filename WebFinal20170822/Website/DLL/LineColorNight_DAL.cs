using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class LineColorNight_DAL : Connect
    {
        #region getColorByColumn
        public string getColorByColumn(string nameColumn, int line, int planid)
        {
            string color = "";
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("Select " + nameColumn + " from LineColorNight where [LineName] ='" + line + "' And PlanId= '" + planid + "'", this.openConnection()))
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
                this.closeConnection();
            }
            return color;
        }
        #endregion
    }
}
