using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BLL;
namespace Website
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        HttpContext context = HttpContext.Current;
        CommonFuntion common = new CommonFuntion();
        User_BLL userBLL = new User_BLL();
        User_BLL_base userBLL_base = new User_BLL_base();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            Entity.User user_ = new Entity.User();
            string username = context.Session["Username"].ToString();
            string oldpass = txtOldPass.Text;
            string newpass = txtNewPass.Text;
            string confirm = txtConfirm.Text;
            if (userBLL.checkLogin(username, md5(oldpass)))
            {
                if (userBLL.updatePassword(username,md5(newpass)))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Change password successfully ');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Fail, Old password is incorrect');", true);
            }
        }

        protected void btnReset_Click(object sender, ImageClickEventArgs e)
        {
            txtConfirm.Text = String.Empty;
            txtNewPass.Text = String.Empty;
            txtOldPass.Text = String.Empty;
        }
        public static byte[] encryptData(string data)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }
        public static string md5(string data)
        {
            return BitConverter.ToString(encryptData(data)).Replace("-", "").ToLower();
        }
    }
}