using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Entity;

namespace DAL
{
    public class User_DAL : Connect
    {
        public bool CheckLogin_DAL(string username, string password)
        {
            bool check = false;
            using (SqlCommand cmd = new SqlCommand("User_CheckLogin", openConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Username", username));
                cmd.Parameters.Add(new SqlParameter("@Password", password));
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                check = dt.Rows.Count > 0;
            }
            return check;
        }

        public bool ChangePassword(string username,string password)
        {
            int i;
            using (SqlCommand cmd = new SqlCommand("Update dbo.[User] SET [Password] = @password WHERE Username = @username", openConnection()))
            {
                cmd.Parameters.Add(new SqlParameter("@username", username));
                cmd.Parameters.Add(new SqlParameter("@password", password));
                i = cmd.ExecuteNonQuery();
            }
            return i > 0;
        }
    }
}
