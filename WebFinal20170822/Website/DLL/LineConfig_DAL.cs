using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class LineConfig_DAL : Connect
    {
        #region getSumLine
        public int getSumLine()
        {
            DataTable dt = new DataTable();
            using (SqlCommand command = new SqlCommand("SELECT * FROM LineConfig WHERE Name = @Name", openConnection()))
            {
                int sumLine = 0;
                command.Parameters.Add(new SqlParameter("@Name", "sumLine"));
                //command.Parameters.Add(new SqlParameter("@PlanId", planid));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    sumLine = int.Parse(dt.Rows[0]["Value"].ToString());
                }
                this.closeConnection();
                return sumLine + 1;
            }
        }
        #endregion

    }
}
