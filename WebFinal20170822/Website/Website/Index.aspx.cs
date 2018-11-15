using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour > 6 && DateTime.Now.Hour < 19)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Response.Redirect("OutputNight.aspx");
            }
        }
    }
}