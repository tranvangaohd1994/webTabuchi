using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class User_DAL_base : Connect
    {

        #region UserSelectAll
        public DataTable UserSelectAll()
        {
            DataTable dt = new DataTable();
            using (SqlCommand command = new SqlCommand("User_SelectByAll", openConnection()))
            {
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        #region UserSelectById
        public DataTable UserSelectById(int id)
        {
            DataTable dt = new DataTable();
            using (SqlCommand command = new SqlCommand("User_SelectById", openConnection()))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        #region UserInsert
        public bool UserInsert(User user)
        {
            int result = 0;
            using (SqlCommand command = new SqlCommand("User_Insert", openConnection()))
            {
                try
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", user.id));
                    command.Parameters.Add(new SqlParameter("@Username", user.username));
                    command.Parameters.Add(new SqlParameter("@Password", user.password));
                    command.Parameters.Add(new SqlParameter("@Information", user.infomation));
                    result = command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    return false;
                }
                return result > 0;
            }
        }
        #endregion

        #region UserUpdate
        public bool UserUpdate(User user)
        {
            int result = 0;
            using (SqlCommand command = new SqlCommand("User_UpdateById", openConnection()))
            {
                try
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", user.id));
                    command.Parameters.Add(new SqlParameter("@Username", user.username));
                    command.Parameters.Add(new SqlParameter("@Password", user.password));
                    command.Parameters.Add(new SqlParameter("@Information", user.infomation));
                    result = command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    return false;
                }
                return result > 0;
            }
        }
        #endregion

        #region UserDelete
        public bool UserDelete(string id)
        {
            int result = 0;
            using (SqlCommand command = new SqlCommand("User_Delete", openConnection()))
            {
                try
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    result = command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    return false;
                }
                return result > 0;
            }
        }
        #endregion

    }
}
