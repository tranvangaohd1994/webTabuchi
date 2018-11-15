using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using DAL;
namespace BLL
{
    public class User_BLL
    {
        User_DAL user_DAL = new User_DAL();
        public bool checkLogin(string username,string password)
        {
            return user_DAL.CheckLogin_DAL(username,password);
        }

        public bool updatePassword(string username,string password)
        {
            return user_DAL.ChangePassword(username, password);
        }
    }
}
