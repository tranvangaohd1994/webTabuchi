using BLL;
using Common;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class ChangeActualInputNight : System.Web.UI.Page
    {
        CommonFuntion common = new CommonFuntion();
        LinetNight_BLL_base input = new LinetNight_BLL_base();
        LineNight_BLL input_BLL = new LineNight_BLL();
        PlanDate_BLL plan_BLL = new PlanDate_BLL();
        DataTable dt;
        private static int planid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour <= 18 && DateTime.Now.Hour >= 7)
            {
                Response.Redirect("ChangeActualInputDay.aspx");
            }

            planid = plan_BLL.findIdByDateTimeNextDay(DateTime.Now);
            if (planid > 0)
            {
                loadGridView();
            }

        }
        private void loadGridView()
        {
            dt = new DataTable();
            dt = input_BLL.InputNight_GetAllLines(planid);
            GridView1.DataSource = dt;
            GridView1.DataBind();
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

        protected void lbtInputForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("InputFormNight.aspx");
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

                if (!input_BLL.InputNight_CheckRSbyLine(line,planid))
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
                    if (input_BLL.InputNight_CheckRSbyLine(common.ConvertInt(row.Cells[0].Text), planid))
                    {
                        setActiveRowEvent(row, true);
                        ImageButton btnSave = (ImageButton)row.FindControl("btnSave");
                        ImageButton btnBack = (ImageButton)row.FindControl("btnBack");
                        btnSave.Visible = true;
                        btnBack.Visible = true;
                        if (DateTime.Now.Hour <= 23 && DateTime.Now.Hour >= 19)
                        {
                            for (int i = 19; i <= DateTime.Now.Hour; i++)
                            {
                                string hourStr = this.convertIntegerLessThan10(i);
                                Label lblhour = (Label)row.FindControl("lbl" + hourStr + "H");
                                TextBox txthour = (TextBox)row.FindControl("txt" + hourStr + "H");
                                lblhour.Visible = false;
                                txthour.Visible = true;
                            }
                        }
                        else if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour <= 6)
                        {
                            for (int i = 19; i <= 23; i++)
                            {
                                string hourStr = this.convertIntegerLessThan10(i);
                                Label lblhour = (Label)row.FindControl("lbl" + hourStr + "H");
                                TextBox txthour = (TextBox)row.FindControl("txt" + hourStr + "H");
                                lblhour.Visible = false;
                                txthour.Visible = true;
                            }
                            for (int i = 0; i <= DateTime.Now.Hour; i++)
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
                            for (int i = 19; i <= 23; i++)
                            {
                                string hourStr = this.convertIntegerLessThan10(i);
                                Label lblhour = (Label)row.FindControl("lbl" + hourStr + "H");
                                TextBox txthour = (TextBox)row.FindControl("txt" + hourStr + "H");
                                lblhour.Visible = false;
                                txthour.Visible = true;
                            }
                            for (int i = 0; i <= 6; i++)
                            {
                                string hourStr = this.convertIntegerLessThan10(i);
                                Label lblhour = (Label)row.FindControl("lbl" + hourStr + "H");
                                TextBox txthour = (TextBox)row.FindControl("txt" + hourStr + "H");
                                lblhour.Visible = false;
                                txthour.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        return;
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

        #region btnSave_Click
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnBack = (ImageButton)sender;
            GridViewRow row = (GridViewRow)btnBack.NamingContainer;
            ImageButton btnSave = (ImageButton)row.FindControl("btnSave");
            LineInputNight line_ = new LineInputNight();
            int actualcount = 0;
            line_ = input.LineNightByLine(int.Parse(row.Cells[0].Text),planid);
            btnSave.Visible = false;
            btnBack.Visible = false;
            if (DateTime.Now.Hour <= 23 && DateTime.Now.Hour >= 19)
            {
                for (int i = 19; i <= DateTime.Now.Hour; i++)
                {
                    int a = 0;
                    string hourStr = this.convertIntegerLessThan10(i);
                    Label lblhour = (Label)row.FindControl("lbl" + hourStr + "H");
                    TextBox txthour = (TextBox)row.FindControl("txt" + hourStr + "H");
                    if (int.TryParse(txthour.Text, out a))
                    {
                        actualcount += a;
                        if (i == 19)
                        {
                            line_.h19 = a;
                        }
                        else if (i == 20)
                        {
                            line_.h20 = a;
                        }
                        else if (i == 21)
                        {
                            line_.h21 = a;
                        }
                        else if (i == 22)
                        {
                            line_.h22 = a;
                        }
                        else if (i == 23)
                        {
                            line_.h23 = a;
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error: " + txthour.ID + " is not integer type');", true);
                        return;
                    }
                }
            }
            else if (DateTime.Now.Hour <= 6)
            {
                for (int i = 19; i <= 23; i++)
                {
                    int a = 0;
                    string hourStr = this.convertIntegerLessThan10(i);
                    Label lblhour = (Label)row.FindControl("lbl" + hourStr + "H");
                    TextBox txthour = (TextBox)row.FindControl("txt" + hourStr + "H");
                    if (int.TryParse(txthour.Text, out a))
                    {
                        actualcount += a;
                        if (i == 19)
                        {
                            line_.h19 = a;
                        }
                        else if (i == 20)
                        {
                            line_.h20 = a;
                        }
                        else if (i == 21)
                        {
                            line_.h21 = a;
                        }
                        else if (i == 22)
                        {
                            line_.h22 = a;
                        }
                        else if (i == 23)
                        {
                            line_.h23 = a;
                        }


                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error: " + txthour.ID + " is not integer type');", true);
                        return;
                    }
                }
                for (int i = 0; i <= DateTime.Now.Hour; i++)
                {
                    int a = 0;
                    string hourStr = this.convertIntegerLessThan10(i);
                    Label lblhour = (Label)row.FindControl("lbl" + hourStr + "H");
                    TextBox txthour = (TextBox)row.FindControl("txt" + hourStr + "H");
                    if (int.TryParse(txthour.Text, out a))
                    {
                        actualcount += a;
                        if (i == 0)
                        {
                            line_.h00 = a;
                        }
                        else if (i == 1)
                        {
                            line_.h01 = a;
                        }
                        else if (i == 2)
                        {
                            line_.h02 = a;
                        }
                        else if (i == 3)
                        {
                            line_.h03 = a;
                        }
                        else if (i == 4)
                        {
                            line_.h04 = a;
                        }
                        else if (i == 5)
                        {
                            line_.h05 = a;
                        }
                        else if (i == 6)
                        {
                            line_.h06 = a;
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error: " + txthour.ID + " is not integer type');", true);
                        return;
                    }
                }
            }
            else
            {
                for (int i = 19; i <= 23; i++)
                {
                    int a = 0;
                    string hourStr = this.convertIntegerLessThan10(i);
                    Label lblhour = (Label)row.FindControl("lbl" + hourStr + "H");
                    TextBox txthour = (TextBox)row.FindControl("txt" + hourStr + "H");
                    if (int.TryParse(txthour.Text, out a))
                    {
                        actualcount += a;
                        if (i == 19)
                        {
                            line_.h19 = a;
                        }
                        else if (i == 20)
                        {
                            line_.h20 = a;
                        }
                        else if (i == 21)
                        {
                            line_.h21 = a;
                        }
                        else if (i == 22)
                        {
                            line_.h22 = a;
                        }
                        else if (i == 23)
                        {
                            line_.h23 = a;
                        }


                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error: " + txthour.ID + " is not integer type');", true);
                        return;
                    }
                }
                for (int i = 0; i <= 6; i++)
                {
                    int a = 0;
                    string hourStr = this.convertIntegerLessThan10(i);
                    Label lblhour = (Label)row.FindControl("lbl" + hourStr + "H");
                    TextBox txthour = (TextBox)row.FindControl("txt" + hourStr + "H");
                    if (int.TryParse(txthour.Text, out a))
                    {
                        actualcount += a;
                        if (i == 0)
                        {
                            line_.h00 = a;
                        }
                        else if (i == 1)
                        {
                            line_.h01 = a;
                        }
                        else if (i == 2)
                        {
                            line_.h02 = a;
                        }
                        else if (i == 3)
                        {
                            line_.h03 = a;
                        }
                        else if (i == 4)
                        {
                            line_.h04 = a;
                        }
                        else if (i == 5)
                        {
                            line_.h05 = a;
                        }
                        else if (i == 6)
                        {
                            line_.h06 = a;
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error: " + txthour.ID + " is not integer type');", true);
                        return;
                    }
                }
            }
            line_.actual = actualcount;
            line_.planid = planid;
            if (input.LineNightUpdate(line_))
            {
                if (DateTime.Now.Hour >= 7 && DateTime.Now.Hour <= 18)
                {
                    for (int i = 0; i <= 6; i++)
                    {
                        string hourStr = this.convertIntegerLessThan10(i);
                        Label lblhour = (Label)row.FindControl("lbl" + hourStr + "H");
                        TextBox txthour = (TextBox)row.FindControl("txt" + hourStr + "H");
                        lblhour.Text = txthour.Text;
                        lblhour.Visible = true;
                        txthour.Visible = false;
                        setActiveRowEvent(row, false);
                    }
                    for (int i = 19; i <= 23; i++)
                    {
                        string hourStr = this.convertIntegerLessThan10(i);
                        Label lblhour = (Label)row.FindControl("lbl" + hourStr + "H");
                        TextBox txthour = (TextBox)row.FindControl("txt" + hourStr + "H");
                        lblhour.Text = txthour.Text;
                        lblhour.Visible = true;
                        txthour.Visible = false;
                        setActiveRowEvent(row, false);
                    }
                    input_BLL.LineInputNight_ChangeActual(int.Parse(row.Cells[0].Text), true,planid);
                    Response.Redirect("ChangeActualInputNight.aspx");
                }
                else
                {
                    if (DateTime.Now.Hour >= 19 && DateTime.Now.Hour <= 23)
                    {
                        for (int i = 19; i <= DateTime.Now.Hour; i++)
                        {
                            string hourStr = this.convertIntegerLessThan10(i);
                            Label lblhour = (Label)row.FindControl("lbl" + hourStr + "H");
                            TextBox txthour = (TextBox)row.FindControl("txt" + hourStr + "H");
                            lblhour.Text = txthour.Text;
                            lblhour.Visible = true;
                            txthour.Visible = false;
                            setActiveRowEvent(row, false);
                        }
                        input_BLL.LineInputNight_ChangeActual(int.Parse(row.Cells[0].Text), true,planid);
                        Response.Redirect("ChangeActualInputNight.aspx");
                    }
                    else
                    {
                        for (int i = 19; i <= 23; i++)
                        {
                            string hourStr = this.convertIntegerLessThan10(i);
                            Label lblhour = (Label)row.FindControl("lbl" + hourStr + "H");
                            TextBox txthour = (TextBox)row.FindControl("txt" + hourStr + "H");
                            lblhour.Text = txthour.Text;
                            lblhour.Visible = true;
                            txthour.Visible = false;
                            setActiveRowEvent(row, false);
                        }
                        for (int i = 0; i <= DateTime.Now.Hour; i++)
                        {
                            string hourStr = this.convertIntegerLessThan10(i);
                            Label lblhour = (Label)row.FindControl("lbl" + hourStr + "H");
                            TextBox txthour = (TextBox)row.FindControl("txt" + hourStr + "H");
                            lblhour.Text = txthour.Text;
                            lblhour.Visible = true;
                            txthour.Visible = false;
                            setActiveRowEvent(row, false);
                        }
                        input_BLL.LineInputNight_ChangeActual(int.Parse(row.Cells[0].Text), true,planid);
                        Response.Redirect("ChangeActualInputNight.aspx");
                    }
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error: Can't save to Database, try again');", true);
                return;
            }
        }
        #endregion

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnBack = (ImageButton)sender;
            GridViewRow row = (GridViewRow)btnBack.NamingContainer;
            ImageButton btnSave = (ImageButton)row.FindControl("btnSave");
            btnSave.Visible = false;
            btnBack.Visible = false;
            if (DateTime.Now.Hour >= 7 && DateTime.Now.Hour <= 18)
            {
                for (int i = 19; i <= 23; i++)
                {
                    string hourStr = this.convertIntegerLessThan10(i);
                    Label lblhour = (Label)row.FindControl("lbl" + hourStr + "H");
                    TextBox txthour = (TextBox)row.FindControl("txt" + hourStr + "H");
                    lblhour.Visible = true;
                    txthour.Visible = false;
                }
                for (int i = 0; i <= 6; i++)
                {
                    string hourStr = this.convertIntegerLessThan10(i);
                    Label lblhour = (Label)row.FindControl("lbl" + hourStr + "H");
                    TextBox txthour = (TextBox)row.FindControl("txt" + hourStr + "H");
                    lblhour.Visible = true;
                    txthour.Visible = false;
                }
            }
            else
            {
                if (DateTime.Now.Hour <= 23 && DateTime.Now.Hour >= 19)
                {
                    for (int i = 19; i <= DateTime.Now.Hour; i++)
                    {
                        string hourStr = this.convertIntegerLessThan10(i);
                        Label lblhour = (Label)row.FindControl("lbl" + hourStr + "H");
                        TextBox txthour = (TextBox)row.FindControl("txt" + hourStr + "H");
                        lblhour.Visible = true;
                        txthour.Visible = false;
                    }
                }
                else
                {
                    for (int i = 19; i <= 23; i++)
                    {
                        string hourStr = this.convertIntegerLessThan10(i);
                        Label lblhour = (Label)row.FindControl("lbl" + hourStr + "H");
                        TextBox txthour = (TextBox)row.FindControl("txt" + hourStr + "H");
                        lblhour.Visible = true;
                        txthour.Visible = false;
                    }
                    for (int i = 0; i <= DateTime.Now.Hour; i++)
                    {
                        string hourStr = this.convertIntegerLessThan10(i);
                        Label lblhour = (Label)row.FindControl("lbl" + hourStr + "H");
                        TextBox txthour = (TextBox)row.FindControl("txt" + hourStr + "H");
                        lblhour.Visible = true;
                        txthour.Visible = false;
                    }
                }
            }
            setActiveRowEvent(row, false);
        }

        protected void lbtHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}