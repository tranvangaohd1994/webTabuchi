using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using Entity;
namespace Website
{
    public partial class AddNewModel : System.Web.UI.Page
    {
        Model_BLL_base modelBLL = new Model_BLL_base();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, ImageClickEventArgs e)
        {
            txtName.Text = "";
        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            string nameModel = txtName.Text;
            DataTable dt = new DataTable();

            dt = modelBLL.ModelSelectById(nameModel);
            if (dt.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalart", "alert('Model already exists');", true);
            }
            Model model_ = new Model();
            model_.model = nameModel;
            if (modelBLL.ModelInsert(model_))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalart", "alert('Model add success');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalart", "alert('Adding model fail,try again');", true);
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchCustomers(string prefixText, int count)
        {
            Model_BLL modelBLL = new Model_BLL();
            return modelBLL.SearchByChar(prefixText);
        }
    }
}