using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using Common;
using System.Data;
namespace Website
{
    public partial class ChangeActualInputDay : System.Web.UI.Page
    {
        CommonFuntion common = new CommonFuntion();
        LineInput_BLL_base input = new LineInput_BLL_base();
        LineInput_BLL input_BLL = new LineInput_BLL();
        PlanDate_BLL plan_BLL = new PlanDate_BLL();
        DataTable dt;
        private static int planid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour > 18 || DateTime.Now.Hour < 7)
            {
                Response.Redirect("ChangeActualInputNight.aspx");
            }
            planid = plan_BLL.findPlanIdByDateTime(DateTime.Now);
            if (planid > 0)
            {
                loadGridView();
            }

        }
        public void loadGridView()
        {
            dt = new DataTable();
            dt = input_BLL.InputDay_GetAllLines(planid);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void lbtInputForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("InputForm.aspx");
        }

        protected void ddlShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlShift.SelectedValue.Equals("Day"))
            {
                Response.Redirect("ChangeActualInputDay.aspx");
            }
            else
            {
                Response.Redirect("ChangeActualInputNight.aspx");
            }
        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnBack = (ImageButton)sender;
            GridViewRow row = (GridViewRow)btnBack.NamingContainer;
            ImageButton btnSave = (ImageButton)row.FindControl("btnSave");
            LineInputDay line_ = new LineInputDay();
            int actualcount = 0;
            line_ = input.LineDayByLine(int.Parse(row.Cells[0].Text), planid);
            btnSave.Visible = false;
            btnBack.Visible = false;
            for (int i = 7; i <= DateTime.Now.Hour; i++)
            {
                int a = 0;
                string hourStr = this.convertIntegerLessThan10(i);
                Label lblhour = (Label)row.FindControl("lbl" + hourStr + "H");
                TextBox txthour = (TextBox)row.FindControl("txt" + hourStr + "H");
                if (int.TryParse(txthour.Text, out a))
                {
                    actualcount += a;
                    if (i == 7)
                    {
                        line_.h07 = a;
                    }
                    else if (i == 8)
                    {
                        line_.h08 = a;
                    }
                    else if (i == 9)
                    {
                        line_.h09 = a;
                    }
                    else if (i == 10)
                    {
                        line_.h10 = a;
                    }
                    else if (i == 11)
                    {
                        line_.h11 = a;
                    }
                    else if (i == 12)
                    {
                        line_.h12 = a;
                    }
                    else if (i == 13)
                    {
                        line_.h13 = a;
                    }
                    else if (i == 14)
                    {
                        line_.h14 = a;
                    }
                    else if (i == 15)
                    {
                        line_.h15 = a;
                    }
                    else if (i == 16)
                    {
                        line_.h16 = a;
                    }
                    else if (i == 17)
                    {
                        line_.h17 = a;
                    }
                    else if (i == 18)
                    {
                        line_.h18 = a;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error: " + txthour.ID + " is not integer type');", true);
                    return;
                }

            }
            line_.actual = actualcount;
            line_.planid = planid;
            if (input.LineDayUpdate(line_))
            {
                for (int i = 7; i <= DateTime.Now.Hour; i++)
                {
                    string hourStr = this.convertIntegerLessThan10(i);
                    Label lblhour = (Label)row.FindControl("lbl" + hourStr + "H");
                    TextBox txthour = (TextBox)row.FindControl("txt" + hourStr + "H");
                    lblhour.Text = txthour.Text;
                    lblhour.Visible = true;
                    txthour.Visible = false;
                    setActiveRowEvent(row, false);
                }
                input_BLL.LineInput_UpdateChangeActual(int.Parse(row.Cells[0].Text), true, planid);
                Response.Redirect("ChangeActualInputDay.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error: Can't save to Database, try again');", true);
                return;
            }
        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnBack = (ImageButton)sender;
            GridViewRow row = (GridViewRow)btnBack.NamingContainer;
            ImageButton btnSave = (ImageButton)row.FindControl("btnSave");
            btnSave.Visible = false;
            btnBack.Visible = false;
            for (int i = 7; i <= DateTime.Now.Hour; i++)
            {
                string hourStr = this.convertIntegerLessThan10(i);
                Label lblhour = (Label)row.FindControl("lbl" + hourStr + "H");
                TextBox txthour = (TextBox)row.FindControl("txt" + hourStr + "H");
                lblhour.Visible = true;
                txthour.Visible = false;
            }
            setActiveRowEvent(row, false);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click to select this row.";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);

                int line = int.Parse(e.Row.Cells[0].Text);
                int lineNew = line + 7;
                if (line >= 44) e.Row.Cells[0].Text = lineNew.ToString();

                if (!input_BLL.InputDay_CheckRSbyLine(line, planid))
                {
                    for (int i = 1; i < 21; i++)
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[21].Text = "-";
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    if (input_BLL.InputDay_CheckRSbyLine(common.ConvertInt(row.Cells[0].Text), planid))
                    {
                        setActiveRowEvent(row, true);
                        ImageButton btnSave = (ImageButton)row.FindControl("btnSave");
                        ImageButton btnBack = (ImageButton)row.FindControl("btnBack");
                        btnSave.Visible = true;
                        btnBack.Visible = true;
                        for (int i = 7; i <= DateTime.Now.Hour; i++)
                        {
                            string hourStr = this.convertIntegerLessThan10(i);
                            Label lblhour = (Label)row.FindControl("lbl" + hourStr + "H");
                            TextBox txthour = (TextBox)row.FindControl("txt" + hourStr + "H");
                            lblhour.Visible = false;
                            txthour.Visible = true;
                        }
                    }
                    else
                    {
                    }

                }
                else
                {
                    row.ToolTip = "Click to select this row.";
                }
            }
        }
        private string convertIntegerLessThan10(int i)
        {
            if (i < 10)
            {
                return "0" + i;
            }
            else
                return i.ToString();
        }
        private void setActiveRowEvent(GridViewRow grdrow, bool isActive)
        {
            if (isActive == true)
            {
                grdrow.ToolTip = "";
                grdrow.Attributes.Remove("onclick");
                //grdrow.BackColor = ColorTranslator.FromHtml("#A1DCF2");
            }
            else
            {
                grdrow.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + grdrow.RowIndex);
                //grdrow.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                grdrow.ToolTip = "Click to select this row.";
            }
        }

        protected void lbtHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }


    }
}