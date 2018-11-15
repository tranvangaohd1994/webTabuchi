using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using DAL;
using System.Data;
namespace BLL
{
    public class User_BLL_base
    {
        User_DAL_base userDaL = new User_DAL_base();

        #region User Select All
        public DataTable UserSelectAll()
        {
            return userDaL.UserSelectAll();
        }
        #endregion

        #region User Select By Id
        public DataTable UserSelectById(int id)
        {
            return userDaL.UserSelectById(id);
        }
        #endregion

        #region User Insert
        public bool UserInsert(User user)
        {
            return userDaL.UserInsert(user);
        }
        #endregion

        #region User Update
        public bool UserUpdate(User user)
        {
            return userDaL.UserUpdate(user);
        }
        #endregion

        #region User Delete
        public bool UserDelete(string id)
        {
            return userDaL.UserDelete(id);
        }
        #endregion
    }
}
