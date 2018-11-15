using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Entity;
namespace DAL
{
    public class Model_DAL_base:Connect
    {
        #region Model Select All
        public DataTable ModelSelectByAll()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand command = new SqlCommand("Model_SelectByAll", openConnection()))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                  
                }
            }
            catch (System.Exception) { 
            }
            this.closeConnection();
            return dt;

        }
        #endregion

        #region Model Select Model
        public DataTable ModelSelectById(string model)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand command = new SqlCommand("Model_SelectByModel", openConnection()))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Model", model);
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

        #region Model Insert
        public bool ModelInsert(Model model)
        {
            int result = 0;
            using (SqlCommand command = new SqlCommand("Model_Insert", openConnection()))
            {
                try
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Model", model.model));
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

        #region Model Delete
        public bool ModelDelete(string model)
        {
            int result = 0;
            using (SqlCommand command = new SqlCommand("Model_Delete", openConnection()))
            {
                try
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Model", model));
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
