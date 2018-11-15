using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Entity;

namespace DAL
{
    public class Model_DAL : Connect
    {
        #region Search Model by Char
        public List<string> SearchModelByChar(string strmodel)
        {
            List<string> model = new List<string>();
            try
            {
                using (SqlCommand command = new SqlCommand("SearchModelByChar", openConnection()))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Model", strmodel));
                    using (SqlDataReader sdr = command.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            model.Add(sdr["Model"].ToString());
                        }
                        
                    }
                }
            }
            catch (System.Exception) { 
                
            }
            this.closeConnection();
            return model;
        }
        #endregion
    }
}
