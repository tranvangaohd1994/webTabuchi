using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        HttpContext context = HttpContext.Current;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void lbtInputForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("InputForm.aspx");
        }
    }
}