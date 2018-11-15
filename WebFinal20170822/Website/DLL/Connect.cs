using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace DAL
{
    public class Connect
    {
        private SqlConnection conn;
        //private string strConnect = @"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=TabuchiEDB ;User Id=user1;Password=123456;Integrated Security= false;Trusted_Connection=true;";
        //string strConnect = @"Data Source=DAT\SQLEXPRESS;Initial Catalog=TabuchiDB852015;Integrated Security= true;Trusted_Connection=true;";
        private string strConnect = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        protected Connect()
        {
            conn = new SqlConnection(strConnect);
        }
        protected SqlConnection openConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }
        protected void closeConnection()
        {
            if(conn.State==ConnectionState.Open)
                conn.Close();

        }
    }
}
