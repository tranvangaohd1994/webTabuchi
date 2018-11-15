using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace Website
{
    public partial class Login : System.Web.UI.Page
    {
        HttpContext context = HttpContext.Current;
        User_BLL user_bll = new User_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtUsername.Attributes.Add("onkeypress", "button_click(this,'" + this.btnLogin.ClientID + "')");
            this.txtPassword.Attributes.Add("onkeypress", "button_click(this,'" + this.btnLogin.ClientID + "')");
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (user_bll.checkLogin(username, md5(password)))
            {
                context.Session["LoggedIn"] = "true";
                context.Session["Username"] = username;
                Response.Redirect("InputForm.aspx");
            }
            else
            {
                txtPassword.Text = "";
                lblAlart.Text = "Username or password are incorrect, try again";
            }
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