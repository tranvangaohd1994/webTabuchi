using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
namespace DLL
{
    public class LineColorNight_DAL_base:  Connect
    {
        public bool LineInputNightInsert(int linename, int planid)
        {
            int result = 0;
            using (SqlCommand command = new SqlCommand("Insert into LineColorNight([LineId],[PlanId],[LineName],[Count19H],[Count20H],[Count21H],[Count22H],[Count23H],[Count00H],[Count01H],[Count02H],[Count03H],[Count04H],[Count05H],[Count06H]) values (@LineName,@PlanId,@LineName,0,0,0,0,0,0,0,0,0,0,0,0)", openConnection()))
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
