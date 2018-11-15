using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class LineColorDay_DAL_base: Connect
    {
        public bool LineInputInsert(int linename,int planid)
        {
            int result = 0;
            using (SqlCommand command = new SqlCommand("Insert into LineColorDay([LineId],[PlanId],[LineName],[Count07H],[Count08H],[Count09H],[Count10H],[Count11H],[Count12H],[Count13H],[Count14H],[Count15H],[Count16H],[Count17H],[Count18H]) values (@LineName,@PlanId,@LineName,0,0,0,0,0,0,0,0,0,0,0,0)", openConnection()))
            {
                try
                {
                    command.Parameters.Add(new SqlParameter("@LineName", linename));
                    command.Parameters.Add(new SqlParameter("@PlanId", planid));                  
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
    }
}
