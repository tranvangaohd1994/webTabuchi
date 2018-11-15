﻿using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using System.IO;
using System.Drawing;
using System.Globalization;
using System.Diagnostics;

namespace Website
{
    public partial class AddNewPlan : System.Web.UI.Page
    {
        private static int planid = 0;
        PlanDate_BLL plan_BLL = new PlanDate_BLL();
        LineConfig_BLL lineConfig = new LineConfig_BLL();
        LineInput_BLL_base inputDay = new LineInput_BLL_base();
        LineInput_BLL inputDay_BLL = new LineInput_BLL();
        LinetNight_BLL_base inputNight = new LinetNight_BLL_base();
        LineNight_BLL inputNight_BLL = new LineNight_BLL();
        LineColorDay_BLL_base colorDay = new LineColorDay_BLL_base();
        LineColorNight_BLL_base colorNight = new LineColorNight_BLL_base();
        Common.CommonFuntion common = new Common.CommonFuntion();
        DataTable dt;
        HttpContext context = HttpContext.Current;
        private string alartError;
        private string alartErrorTime = "";
        private static int sumLine = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            sumLine = lineConfig.getSumLine();
            if (context.Session["LoggedIn"] != "true")
            {
                context.Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                planid = plan_BLL.findPlanIdByDateTime(DateTime.Now);
                if (planid > 0)
                {
                    loadGridView();
                }
            }
        }

        protected void lbtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void lbtnExport_Click(object sender, EventArgs e)
        {

            // lay bang dang hoat dong.
            try
            {
                string nameFile = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "-Input-Day ";
                DataTable dttb = inputDay_BLL.InputDay_ExportExcel(planid);
                string attachment = "attachment;filename=" + nameFile + ".xls";
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/vnd.ms-excel";
                string tab = "";
                foreach (DataColumn dc in dttb.Columns)
                {
                    Response.Write(tab + dc.ColumnName);
                    tab = "\t";
                }
                Response.Write("\n");

                int i;
                foreach (DataRow dr in dttb.Rows)
                {
                    tab = "";
                    for (i = 0; i < dttb.Columns.Count; i++)
                    {
                        Response.Write(tab + dr[i].ToString());
                        tab = "\t";
                    }
                    Response.Write("\n");
                }
                Response.End();
            }
            catch (Exception ex)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(ex.Message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        #region ddlShift_SelectedIndexChanged
        protected void ddlShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlShift.SelectedValue.Equals("Day"))
            {
                loadGridView();
            }
            else
            {
                dt = new DataTable();
                dt = inputNight.LineNightSelectAll(planid);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        #endregion

        #region btnSave_Click
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnSave = (ImageButton)sender;
            GridViewRow row = (GridViewRow)btnSave.NamingContainer;
            ImageButton btnBack = (ImageButton)row.FindControl("btnBack");
            Label LabelMD = (Label)row.FindControl("LabelMD");
            CheckBox chkAll = (CheckBox)row.FindControl("chkAll");
            TextBox txtModelA = (TextBox)row.FindControl("TextBoxMDA");
            TextBox txtModelB = (TextBox)row.FindControl("TextBoxMDB");
            TextBox txtModelC = (TextBox)row.FindControl("TextBoxMDC");
            RadioButton rdModelA = (RadioButton)row.FindControl("rdModelA");
            RadioButton rdModelB = (RadioButton)row.FindControl("rdModelB");
            RadioButton rdModelC = (RadioButton)row.FindControl("rdModelC");
            TextBox TextBoxMD = (TextBox)row.FindControl("TextBoxMD");
            Label LabelTT = (Label)row.FindControl("LabelTT");
            TextBox TextBoxTT = (TextBox)row.FindControl("TextBoxTT");
            Label LabelTM = (Label)row.FindControl("LabelTM");
            TextBox TextBoxTM = (TextBox)row.FindControl("TextBoxTM");
            Label LabelPW = (Label)row.FindControl("LabelPW");
            TextBox TextBoxPW = (TextBox)row.FindControl("TextBoxPW");
            Label LabelAW = (Label)row.FindControl("LabelAW");
            TextBox TextBoxAW = (TextBox)row.FindControl("TextBoxAW");
            Label LabelPl = (Label)row.FindControl("LabelPl");
            TextBox TextBoxPl = (TextBox)row.FindControl("TextBoxPl");
            Label LabelF1 = (Label)row.FindControl("LabelF1");
            TextBox TextBoxF11 = (TextBox)row.FindControl("TextBoxF11");
            TextBox TextBoxF12 = (TextBox)row.FindControl("TextBoxF12");
            Label LabelT1 = (Label)row.FindControl("LabelT1");
            TextBox TextBoxT11 = (TextBox)row.FindControl("TextBoxT11");
            TextBox TextBoxT12 = (TextBox)row.FindControl("TextBoxT12");
            Label LabelF2 = (Label)row.FindControl("LabelF2");
            TextBox TextBoxF21 = (TextBox)row.FindControl("TextBoxF21");
            TextBox TextBoxF22 = (TextBox)row.FindControl("TextBoxF22");
            Label LabelT2 = (Label)row.FindControl("LabelT2");
            TextBox TextBoxT21 = (TextBox)row.FindControl("TextBoxT21");
            TextBox TextBoxT22 = (TextBox)row.FindControl("TextBoxT22");
            Label LabelF3 = (Label)row.FindControl("LabelF3");
            TextBox TextBoxF31 = (TextBox)row.FindControl("TextBoxF31");
            TextBox TextBoxF32 = (TextBox)row.FindControl("TextBoxF32");
            Label LabelT3 = (Label)row.FindControl("LabelT3");
            TextBox TextBoxT31 = (TextBox)row.FindControl("TextBoxT31");
            TextBox TextBoxT32 = (TextBox)row.FindControl("TextBoxT32");
            Label LabelF4 = (Label)row.FindControl("LabelF4");
            TextBox TextBoxF41 = (TextBox)row.FindControl("TextBoxF41");
            TextBox TextBoxF42 = (TextBox)row.FindControl("TextBoxF42");
            Label LabelT4 = (Label)row.FindControl("LabelT4");
            TextBox TextBoxT41 = (TextBox)row.FindControl("TextBoxT41");
            TextBox TextBoxT42 = (TextBox)row.FindControl("TextBoxT42");
            Label LabelF5 = (Label)row.FindControl("LabelF5");
            TextBox TextBoxF51 = (TextBox)row.FindControl("TextBoxF51");
            TextBox TextBoxF52 = (TextBox)row.FindControl("TextBoxF52");
            Label LabelT5 = (Label)row.FindControl("LabelT5");
            TextBox TextBoxT51 = (TextBox)row.FindControl("TextBoxT51");
            TextBox TextBoxT52 = (TextBox)row.FindControl("TextBoxT52");
            Label LabelF6 = (Label)row.FindControl("LabelF6");
            TextBox TextBoxF61 = (TextBox)row.FindControl("TextBoxF61");
            TextBox TextBoxF62 = (TextBox)row.FindControl("TextBoxF62");
            Label LabelT6 = (Label)row.FindControl("LabelT6");
            TextBox TextBoxT61 = (TextBox)row.FindControl("TextBoxT61");
            TextBox TextBoxT62 = (TextBox)row.FindControl("TextBoxT62");
            Label LabelCM = (Label)row.FindControl("LabelCM");
            TextBox TextBoxCM = (TextBox)row.FindControl("TextBoxCM");
            Label LabelRank = (Label)row.FindControl("LabelRank");
            TextBox TextBoxRank = (TextBox)row.FindControl("TextBoxRank");
            alartError = "";
            int line = int.Parse(row.Cells[0].Text);
            if (ddlShift.SelectedValue.Equals("Day"))
            {
                #region Chinh sua ca ngay
                if (txtModelA.Text.Equals("Stocking"))
                {
                    checkTextBoxInt(TextBoxPl, 999999, 1);
                }
                else
                {
                    checkTextBoxInt(TextBoxPl, 9999, 1);
                }
                checkTextBoxIntAllowNull(TextBoxF11, 19, 7);
                checkTextBoxIntAllowNull(TextBoxF21, 19, 7);
                checkTextBoxIntAllowNull(TextBoxF31, 19, 7);
                checkTextBoxIntAllowNull(TextBoxF41, 19, 7);
                checkTextBoxIntAllowNull(TextBoxF51, 19, 7);
                checkTextBoxIntAllowNull(TextBoxF61, 19, 7);

                checkTextBoxIntAllowNull(TextBoxF12, 59, 0);
                checkTextBoxIntAllowNull(TextBoxF22, 59, 0);
                checkTextBoxIntAllowNull(TextBoxF32, 59, 0);
                checkTextBoxIntAllowNull(TextBoxF42, 59, 0);
                checkTextBoxIntAllowNull(TextBoxF52, 59, 0);
                checkTextBoxIntAllowNull(TextBoxF62, 59, 0);

                checkTextBoxIntAllowNull(TextBoxT11, 19, 7);
                checkTextBoxIntAllowNull(TextBoxT21, 19, 7);
                checkTextBoxIntAllowNull(TextBoxT31, 19, 7);
                checkTextBoxIntAllowNull(TextBoxT41, 19, 7);
                checkTextBoxIntAllowNull(TextBoxT51, 19, 7);
                checkTextBoxIntAllowNull(TextBoxT61, 19, 7);

                checkTextBoxIntAllowNull(TextBoxT12, 59, 0);
                checkTextBoxIntAllowNull(TextBoxT22, 59, 0);
                checkTextBoxIntAllowNull(TextBoxT32, 59, 0);
                checkTextBoxIntAllowNull(TextBoxT42, 59, 0);
                checkTextBoxIntAllowNull(TextBoxT52, 59, 0);
                checkTextBoxIntAllowNull(TextBoxT62, 59, 0);
                if (alartError.Equals(""))
                {
                    checkIntegerTextBox(TextBoxF11);
                    checkIntegerTextBox(TextBoxF12);
                    checkIntegerTextBox(TextBoxT11);
                    checkIntegerTextBox(TextBoxT12);
                    checkIntegerTextBox(TextBoxF21);
                    checkIntegerTextBox(TextBoxF22);
                    checkIntegerTextBox(TextBoxT21);
                    checkIntegerTextBox(TextBoxT22);
                    checkIntegerTextBox(TextBoxF31);
                    checkIntegerTextBox(TextBoxF32);
                    checkIntegerTextBox(TextBoxT31);
                    checkIntegerTextBox(TextBoxT32);
                    checkIntegerTextBox(TextBoxF41);
                    checkIntegerTextBox(TextBoxF42);
                    checkIntegerTextBox(TextBoxT41);
                    checkIntegerTextBox(TextBoxT42);
                    checkIntegerTextBox(TextBoxF51);
                    checkIntegerTextBox(TextBoxF52);
                    checkIntegerTextBox(TextBoxT51);
                    checkIntegerTextBox(TextBoxT52);
                    checkIntegerTextBox(TextBoxF61);
                    checkIntegerTextBox(TextBoxF62);
                    checkIntegerTextBox(TextBoxT61);
                    checkIntegerTextBox(TextBoxT62);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error: " + alartError + "');", true);
                    return;
                }
                // Kiem tra integer textbox >0

                // kiem tra thoi gian co dung hay khong
                compareTimeFromTo(TextBoxF11, TextBoxF12, TextBoxT11, TextBoxT12);
                compareTimeFromTo(TextBoxT11, TextBoxT12, TextBoxF21, TextBoxF22);
                compareTimeFromTo(TextBoxF21, TextBoxF22, TextBoxT21, TextBoxT22);
                compareTimeFromTo(TextBoxT21, TextBoxT22, TextBoxF31, TextBoxF32);
                compareTimeFromTo(TextBoxF31, TextBoxF32, TextBoxT31, TextBoxT32);
                compareTimeFromTo(TextBoxT31, TextBoxT32, TextBoxF41, TextBoxF42);
                compareTimeFromTo(TextBoxF41, TextBoxF42, TextBoxT41, TextBoxT42);
                compareTimeFromTo(TextBoxT41, TextBoxT42, TextBoxF51, TextBoxF52);
                compareTimeFromTo(TextBoxF51, TextBoxF52, TextBoxT51, TextBoxT52);
                compareTimeFromTo(TextBoxT51, TextBoxT52, TextBoxF61, TextBoxF62);
                compareTimeFromTo(TextBoxF61, TextBoxF62, TextBoxT61, TextBoxT62);
                if (!alartErrorTime.Equals(""))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error: " + alartErrorTime + "');", true);
                    return;
                }
                // lay gia tri moi 

                setLabelfromTextBox(LabelF1, LabelT1, TextBoxF11, TextBoxF12, TextBoxT11, TextBoxT12);
                setLabelfromTextBox(LabelF2, LabelT2, TextBoxF21, TextBoxF22, TextBoxT21, TextBoxT22);
                setLabelfromTextBox(LabelF3, LabelT3, TextBoxF31, TextBoxF32, TextBoxT31, TextBoxT32);
                setLabelfromTextBox(LabelF4, LabelT4, TextBoxF41, TextBoxF42, TextBoxT41, TextBoxT42);
                setLabelfromTextBox(LabelF5, LabelT5, TextBoxF51, TextBoxF52, TextBoxT51, TextBoxT52);
                setLabelfromTextBox(LabelF6, LabelT6, TextBoxF61, TextBoxF62, TextBoxT61, TextBoxT62);
                LabelPW.Text = TextBoxPW.Text;
                LabelAW.Text = TextBoxAW.Text;
                LabelPl.Text = TextBoxPl.Text;
                LabelRank.Text = TextBoxRank.Text.Trim();
                LabelCM.Text = TextBoxCM.Text;

                // lay du lieu vao doi tuong
                LineInputDay line_ = new LineInputDay();
                int numLine = int.Parse(row.Cells[0].Text);
                if (numLine > 50) numLine -= 7;
                line_ = inputDay.LineDayByLine(numLine, planid);
                line_.modelA = txtModelA.Text;
                line_.modelB = txtModelB.Text;
                line_.modelC = txtModelC.Text;
                if (rdModelA.Checked)
                {
                    line_.model = txtModelA.Text;
                    line_.changemodel = "";
                }
                else if (rdModelB.Checked)
                {
                    line_.model = txtModelB.Text;
                    line_.changemodel = "C";
                }
                else if (rdModelC.Checked)
                {
                    line_.model = txtModelC.Text;
                    line_.changemodel = "C";
                }
                line_.rs = chkAll.Checked;
                line_.rank = LabelRank.Text;
                line_.plan = int.Parse(LabelPl.Text);
                line_.planed_woker = common.ConvertInt(LabelPW.Text);
                line_.actual_woker = common.ConvertInt(LabelAW.Text);
                line_.total_min = common.calcuTotalMinuteDay(LabelF1.Text, LabelT1.Text, LabelF2.Text, LabelT2.Text,
                 LabelF3.Text, LabelT3.Text, LabelF4.Text, LabelT4.Text,
                 LabelF5.Text, LabelT5.Text, LabelF6.Text, LabelT6.Text
                 );
                LabelTM.Text = line_.total_min.ToString();
                line_.tact_time = common.calcuTactTime(int.Parse(LabelTM.Text), int.Parse(TextBoxPl.Text));
                LabelTT.Text = line_.tact_time.ToString("F1");
                line_.comment = LabelCM.Text;
                line_.planid = planid;
                line_.rank = LabelRank.Text;
                line_.from1 = LabelF1.Text;
                line_.from2 = LabelF2.Text;
                line_.from3 = LabelF3.Text;
                line_.from4 = LabelF4.Text;
                line_.from5 = LabelF5.Text;
                line_.from6 = LabelF6.Text;
                line_.to1 = LabelT1.Text;
                line_.to2 = LabelT2.Text;
                line_.to3 = LabelT3.Text;
                line_.to4 = LabelT4.Text;
                line_.to5 = LabelT5.Text;
                line_.to6 = LabelT6.Text;
                if (inputDay.LineDayUpdate(line_))
                {

                    txtModelA.Enabled = false;
                    txtModelB.Enabled = false;
                    txtModelC.Enabled = false;

                    rdModelA.Enabled = false;
                    rdModelB.Enabled = false;
                    rdModelC.Enabled = false;

                    LabelF1.Visible = true;
                    TextBoxF11.Visible = false;
                    TextBoxF12.Visible = false;

                    LabelT1.Visible = true;
                    TextBoxT11.Visible = false;
                    TextBoxT12.Visible = false;

                    LabelF2.Visible = true;
                    TextBoxF21.Visible = false;
                    TextBoxF22.Visible = false;

                    LabelT2.Visible = true;
                    TextBoxT21.Visible = false;
                    TextBoxT22.Visible = false;

                    LabelF3.Visible = true;
                    TextBoxF31.Visible = false;
                    TextBoxF32.Visible = false;

                    LabelT3.Visible = true;
                    TextBoxT31.Visible = false;
                    TextBoxT32.Visible = false;

                    LabelF4.Visible = true;
                    TextBoxF41.Visible = false;
                    TextBoxF42.Visible = false;

                    LabelT4.Visible = true;
                    TextBoxT41.Visible = false;
                    TextBoxT42.Visible = false;

                    LabelF5.Visible = true;
                    TextBoxF51.Visible = false;
                    TextBoxF52.Visible = false;

                    LabelT5.Visible = true;
                    TextBoxT51.Visible = false;
                    TextBoxT52.Visible = false;

                    LabelF6.Visible = true;
                    TextBoxF61.Visible = false;
                    TextBoxF62.Visible = false;

                    LabelT6.Visible = true;
                    TextBoxT61.Visible = false;
                    TextBoxT62.Visible = false;

                    LabelRank.Visible = true;
                    TextBoxRank.Visible = false;

                    LabelPW.Visible = true;
                    TextBoxPW.Visible = false;

                    LabelCM.Visible = true;
                    TextBoxCM.Visible = false;

                    LabelPl.Visible = true;
                    TextBoxPl.Visible = false;

                    LabelAW.Visible = true;
                    TextBoxAW.Visible = false;

                    btnSave.Visible = false;
                    btnBack.Visible = false;
                    setActiveRowEvent(row, false);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error: Can't store this model to database');", true);
                }
                #endregion
            }
            else
            {
                #region chinh sua ca toi
                if (txtModelA.Text.Equals("Stocking"))
                {
                    checkTextBoxInt(TextBoxPl, 999999, 1);
                }
                else
                {
                    checkTextBoxInt(TextBoxPl, 9999, 1);
                }
                checkTextBoxNight(TextBoxF11, 19, 7);
                checkTextBoxNight(TextBoxF21, 19, 7);
                checkTextBoxNight(TextBoxF31, 19, 7);
                checkTextBoxNight(TextBoxF41, 19, 7);
                checkTextBoxNight(TextBoxF51, 19, 7);
                checkTextBoxNight(TextBoxF61, 19, 7);

                checkTextBoxInt(TextBoxF12, 59, 0);
                checkTextBoxInt(TextBoxF22, 59, 0);
                checkTextBoxInt(TextBoxF32, 59, 0);
                checkTextBoxInt(TextBoxF42, 59, 0);
                checkTextBoxInt(TextBoxF52, 59, 0);
                checkTextBoxInt(TextBoxF62, 59, 0);

                checkTextBoxNight(TextBoxT11, 19, 7);
                checkTextBoxNight(TextBoxT21, 19, 7);
                checkTextBoxNight(TextBoxT31, 19, 7);
                checkTextBoxNight(TextBoxT41, 19, 7);
                checkTextBoxNight(TextBoxT51, 19, 7);
                checkTextBoxNight(TextBoxT61, 19, 7);

                checkTextBoxInt(TextBoxT12, 59, 0);
                checkTextBoxInt(TextBoxT22, 59, 0);
                checkTextBoxInt(TextBoxT32, 59, 0);
                checkTextBoxInt(TextBoxT42, 59, 0);
                checkTextBoxInt(TextBoxT52, 59, 0);
                checkTextBoxIntAllowNull(TextBoxT62, 59, 0);
                if (!alartError.Equals(""))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error: " + alartError + "');", true);
                    //return;
                }
                else
                {
                    checkIntegerTextBox(TextBoxF11);
                    checkIntegerTextBox(TextBoxF12);
                    checkIntegerTextBox(TextBoxT11);
                    checkIntegerTextBox(TextBoxT12);

                    checkIntegerTextBox(TextBoxF21);
                    checkIntegerTextBox(TextBoxF22);
                    checkIntegerTextBox(TextBoxT21);
                    checkIntegerTextBox(TextBoxT22);

                    checkIntegerTextBox(TextBoxF31);
                    checkIntegerTextBox(TextBoxF32);
                    checkIntegerTextBox(TextBoxT31);
                    checkIntegerTextBox(TextBoxT32);

                    checkIntegerTextBox(TextBoxF41);
                    checkIntegerTextBox(TextBoxF42);
                    checkIntegerTextBox(TextBoxT41);
                    checkIntegerTextBox(TextBoxT42);

                    checkIntegerTextBox(TextBoxF51);
                    checkIntegerTextBox(TextBoxF52);
                    checkIntegerTextBox(TextBoxT51);
                    checkIntegerTextBox(TextBoxT52);
                    checkIntegerTextBox(TextBoxF61);
                    checkIntegerTextBox(TextBoxF62);
                    checkIntegerTextBox(TextBoxT61);
                    checkIntegerTextBox(TextBoxT62);
                }
                compareTimeFromToNight(TextBoxF11, TextBoxF12, TextBoxT11, TextBoxT12);
                compareTimeFromToNight(TextBoxT11, TextBoxT12, TextBoxF21, TextBoxF22);
                compareTimeFromToNight(TextBoxF21, TextBoxF22, TextBoxT21, TextBoxT22);
                compareTimeFromToNight(TextBoxT21, TextBoxT22, TextBoxF31, TextBoxF32);
                compareTimeFromToNight(TextBoxF31, TextBoxF32, TextBoxT31, TextBoxT32);
                compareTimeFromToNight(TextBoxT31, TextBoxT32, TextBoxF41, TextBoxF42);
                compareTimeFromToNight(TextBoxF41, TextBoxF42, TextBoxT41, TextBoxT42);
                compareTimeFromToNight(TextBoxT41, TextBoxT42, TextBoxF51, TextBoxF52);
                compareTimeFromToNight(TextBoxF51, TextBoxF52, TextBoxT51, TextBoxT52);
                if (!TextBoxF61.Text.Equals("") && !TextBoxT62.Text.Equals(""))
                {
                    compareTimeFromToNight(TextBoxT51, TextBoxT52, TextBoxF61, TextBoxF62);
                }
                if (!TextBoxF61.Text.Equals("") && !TextBoxT62.Text.Equals("") && !TextBoxF61.Text.Equals("") && !TextBoxT61.Text.Equals(""))
                {
                    compareTimeFromToNight(TextBoxF61, TextBoxF62, TextBoxT61, TextBoxT62);
                }
                if (!alartErrorTime.Equals(""))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error: " + alartErrorTime + "');", true);
                    return;
                }
                setLabelfromTextBox(LabelF1, LabelT1, TextBoxF11, TextBoxF12, TextBoxT11, TextBoxT12);
                setLabelfromTextBox(LabelF2, LabelT2, TextBoxF21, TextBoxF22, TextBoxT21, TextBoxT22);
                setLabelfromTextBox(LabelF3, LabelT3, TextBoxF31, TextBoxF32, TextBoxT31, TextBoxT32);
                setLabelfromTextBox(LabelF4, LabelT4, TextBoxF41, TextBoxF42, TextBoxT41, TextBoxT42);
                setLabelfromTextBox(LabelF5, LabelT5, TextBoxF51, TextBoxF52, TextBoxT51, TextBoxT52);
                setLabelfromTextBox(LabelF6, LabelT6, TextBoxF61, TextBoxF62, TextBoxT61, TextBoxT62);

                LabelPW.Text = TextBoxPW.Text;
                LabelAW.Text = TextBoxAW.Text;
                LabelPl.Text = TextBoxPl.Text;


                LabelRank.Text = TextBoxRank.Text.Trim();
                LabelCM.Text = TextBoxCM.Text;

                LineInputNight line_ = new LineInputNight();
                int numLine = int.Parse(row.Cells[0].Text);
                if (numLine > 50) numLine -= 7;
                line_ = inputNight.LineNightByLine(numLine, planid);
                line_.planid = planid;
                line_.modelA = txtModelA.Text;
                line_.modelB = txtModelB.Text;
                line_.modelC = txtModelC.Text;
                if (rdModelA.Checked)
                {
                    line_.model = txtModelA.Text;
                    line_.changemodel = "";
                }
                else if (rdModelB.Checked)
                {
                    line_.model = txtModelB.Text;
                    line_.changemodel = "C";
                }
                else if (rdModelC.Checked)
                {
                    line_.model = txtModelC.Text;
                    line_.changemodel = "C";
                }
                line_.rs = chkAll.Checked;
                line_.rank = LabelRank.Text;
                line_.plan = int.Parse(LabelPl.Text);
                line_.planed_woker = common.ConvertInt(LabelPW.Text);
                line_.actual_woker = common.ConvertInt(LabelAW.Text);
                line_.total_min = common.calcuTotalMinuteNight(LabelF1.Text, LabelT1.Text, LabelF2.Text, LabelT2.Text,
                 LabelF3.Text, LabelT3.Text, LabelF4.Text, LabelT4.Text,
                 LabelF5.Text, LabelT5.Text, LabelF6.Text, LabelT6.Text
                 );
                LabelTM.Text = line_.total_min.ToString();
                line_.tact_time = common.calcuTactTime(int.Parse(LabelTM.Text), int.Parse(TextBoxPl.Text));
                LabelTT.Text = line_.tact_time.ToString("F1");
                line_.comment = LabelCM.Text;
                line_.rank = LabelRank.Text;
                line_.from1 = LabelF1.Text;
                line_.from2 = LabelF2.Text;
                line_.from3 = LabelF3.Text;
                line_.from4 = LabelF4.Text;
                line_.from5 = LabelF5.Text;
                line_.from6 = LabelF6.Text;
                line_.to1 = LabelT1.Text;
                line_.to2 = LabelT2.Text;
                line_.to3 = LabelT3.Text;
                line_.to4 = LabelT4.Text;
                line_.to5 = LabelT5.Text;
                line_.to6 = LabelT6.Text;
                if (inputNight.LineNightUpdate(line_))
                {
                    txtModelA.Enabled = false;
                    txtModelB.Enabled = false;
                    txtModelC.Enabled = false;

                    rdModelA.Enabled = false;
                    rdModelB.Enabled = false;
                    rdModelC.Enabled = false;

                    LabelF1.Visible = true;
                    TextBoxF11.Visible = false;
                    TextBoxF12.Visible = false;

                    LabelT1.Visible = true;
                    TextBoxT11.Visible = false;
                    TextBoxT12.Visible = false;

                    LabelF2.Visible = true;
                    TextBoxF21.Visible = false;
                    TextBoxF22.Visible = false;

                    LabelT2.Visible = true;
                    TextBoxT21.Visible = false;
                    TextBoxT22.Visible = false;

                    LabelF3.Visible = true;
                    TextBoxF31.Visible = false;
                    TextBoxF32.Visible = false;

                    LabelT3.Visible = true;
                    TextBoxT31.Visible = false;
                    TextBoxT32.Visible = false;

                    LabelF4.Visible = true;
                    TextBoxF41.Visible = false;
                    TextBoxF42.Visible = false;

                    LabelT4.Visible = true;
                    TextBoxT41.Visible = false;
                    TextBoxT42.Visible = false;

                    LabelF5.Visible = true;
                    TextBoxF51.Visible = false;
                    TextBoxF52.Visible = false;

                    LabelT5.Visible = true;
                    TextBoxT51.Visible = false;
                    TextBoxT52.Visible = false;

                    LabelF6.Visible = true;
                    TextBoxF61.Visible = false;
                    TextBoxF62.Visible = false;

                    LabelT6.Visible = true;
                    TextBoxT61.Visible = false;
                    TextBoxT62.Visible = false;

                    LabelRank.Visible = true;
                    TextBoxRank.Visible = false;

                    LabelPW.Visible = true;
                    TextBoxPW.Visible = false;

                    LabelCM.Visible = true;
                    TextBoxCM.Visible = false;

                    LabelPl.Visible = true;
                    TextBoxPl.Visible = false;

                    LabelAW.Visible = true;
                    TextBoxAW.Visible = false;

                    btnSave.Visible = false;
                    btnBack.Visible = false;


                    setActiveRowEvent(row, false);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error: Can't store this model to database');", true);
                }
                #endregion

            }

        }
        #endregion

        #region
        private bool compareTimeFromToNight(TextBox textbox11, TextBox textbox12, TextBox textbox21, TextBox textbox22)
        {
            if (textbox11.Text.Equals("") || textbox12.Text.Equals("") || textbox21.Text.Equals("") || textbox22.Text.Equals(""))
            {
                return true;
            }
            string from = textbox11.Text + ":" + textbox12.Text;
            string to = textbox21.Text + ":" + textbox22.Text;
            DateTime timeF1 = DateTime.ParseExact(from, "HH:mm", System.Globalization.CultureInfo.CurrentCulture);
            DateTime timeT1 = DateTime.ParseExact(to, "HH:mm", System.Globalization.CultureInfo.CurrentCulture);
            TimeSpan timeCompare = timeT1.Subtract(timeF1);
            if (timeCompare.TotalMinutes <= 0 && (timeF1.Hour >= 19 && timeF1.Hour <= 23) && (timeT1.Hour >= 0 && timeT1.Hour <= 6))
            {
                textbox11.BackColor = System.Drawing.Color.White;
                textbox12.BackColor = System.Drawing.Color.White;
                textbox21.BackColor = System.Drawing.Color.White;
                textbox22.BackColor = System.Drawing.Color.White;
                return true;
            }
            else if (timeCompare.TotalMinutes > 0)
            {
                if ((timeF1.Hour >= 0 && timeF1.Hour <= 6) && (timeT1.Hour >= 19 && timeT1.Hour <= 23))
                {
                    alartErrorTime += " \\n Error " + textbox11.ID + " and " + textbox21.ID + ", check again";
                    textbox11.BackColor = System.Drawing.Color.Red;
                    textbox12.BackColor = System.Drawing.Color.Red;
                    textbox21.BackColor = System.Drawing.Color.Red;
                    textbox22.BackColor = System.Drawing.Color.Red;
                    return false;
                }
                else
                {
                    textbox11.BackColor = System.Drawing.Color.White;
                    textbox12.BackColor = System.Drawing.Color.White;
                    textbox21.BackColor = System.Drawing.Color.White;
                    textbox22.BackColor = System.Drawing.Color.White;
                    return true;
                }
            }
            else
            {
                alartErrorTime += " \\n Error " + textbox11.ID + " and " + textbox21.ID + ", check again";
                textbox11.BackColor = System.Drawing.Color.Red;
                textbox12.BackColor = System.Drawing.Color.Red;
                textbox21.BackColor = System.Drawing.Color.Red;
                textbox22.BackColor = System.Drawing.Color.Red;
                return false;
            }

        }
        #endregion

        #region checkTextBoxNight
        private bool checkTextBoxNight(TextBox textbox, int max, int min)
        {
            bool check = true;
            int outint = 0;
            if (textbox.Text.Trim().Equals(""))
            {
                return true;
            }
            if (!int.TryParse(textbox.Text, out outint))
            {
                check = false;
            }
            if (outint > min && outint < max)
            {
                check = false;
            }
            if (!check)
            {
                alartError += "\\n" + textbox.ID + "is only integer, not blank, from " + min + " to " + max;
            }
            return check;
        }
        #endregion

        #region btnBack_Click
        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnBack = (ImageButton)sender;
            GridViewRow row = (GridViewRow)btnBack.NamingContainer;
            ImageButton btnSave = (ImageButton)row.FindControl("btnSave");

            TextBox txtModelA = (TextBox)row.FindControl("TextBoxMDA");
            TextBox txtModelB = (TextBox)row.FindControl("TextBoxMDB");
            TextBox txtModelC = (TextBox)row.FindControl("TextBoxMDC");
            RadioButton rdModelA = (RadioButton)row.FindControl("rdModelA");
            RadioButton rdModelB = (RadioButton)row.FindControl("rdModelB");
            RadioButton rdModelC = (RadioButton)row.FindControl("rdModelC");
            Label LabelTT = (Label)row.FindControl("LabelTT");
            Label LabelTM = (Label)row.FindControl("LabelTM");
            Label LabelPW = (Label)row.FindControl("LabelPW");
            TextBox TextBoxPW = (TextBox)row.FindControl("TextBoxPW");
            Label LabelAW = (Label)row.FindControl("LabelAW");
            TextBox TextBoxAW = (TextBox)row.FindControl("TextBoxAW");
            Label LabelPl = (Label)row.FindControl("LabelPl");
            TextBox TextBoxPl = (TextBox)row.FindControl("TextBoxPl");
            Label LabelF1 = (Label)row.FindControl("LabelF1");
            TextBox TextBoxF11 = (TextBox)row.FindControl("TextBoxF11");
            TextBox TextBoxF12 = (TextBox)row.FindControl("TextBoxF12");
            Label LabelT1 = (Label)row.FindControl("LabelT1");
            TextBox TextBoxT11 = (TextBox)row.FindControl("TextBoxT11");
            TextBox TextBoxT12 = (TextBox)row.FindControl("TextBoxT12");
            Label LabelF2 = (Label)row.FindControl("LabelF2");
            TextBox TextBoxF21 = (TextBox)row.FindControl("TextBoxF21");
            TextBox TextBoxF22 = (TextBox)row.FindControl("TextBoxF22");
            Label LabelT2 = (Label)row.FindControl("LabelT2");
            TextBox TextBoxT21 = (TextBox)row.FindControl("TextBoxT21");
            TextBox TextBoxT22 = (TextBox)row.FindControl("TextBoxT22");
            Label LabelF3 = (Label)row.FindControl("LabelF3");
            TextBox TextBoxF31 = (TextBox)row.FindControl("TextBoxF31");
            TextBox TextBoxF32 = (TextBox)row.FindControl("TextBoxF32");
            Label LabelT3 = (Label)row.FindControl("LabelT3");
            TextBox TextBoxT31 = (TextBox)row.FindControl("TextBoxT31");
            TextBox TextBoxT32 = (TextBox)row.FindControl("TextBoxT32");
            Label LabelF4 = (Label)row.FindControl("LabelF4");
            TextBox TextBoxF41 = (TextBox)row.FindControl("TextBoxF41");
            TextBox TextBoxF42 = (TextBox)row.FindControl("TextBoxF42");
            Label LabelT4 = (Label)row.FindControl("LabelT4");
            TextBox TextBoxT41 = (TextBox)row.FindControl("TextBoxT41");
            TextBox TextBoxT42 = (TextBox)row.FindControl("TextBoxT42");
            Label LabelF5 = (Label)row.FindControl("LabelF5");
            TextBox TextBoxF51 = (TextBox)row.FindControl("TextBoxF51");
            TextBox TextBoxF52 = (TextBox)row.FindControl("TextBoxF52");
            Label LabelT5 = (Label)row.FindControl("LabelT5");
            TextBox TextBoxT51 = (TextBox)row.FindControl("TextBoxT51");
            TextBox TextBoxT52 = (TextBox)row.FindControl("TextBoxT52");
            Label LabelF6 = (Label)row.FindControl("LabelF6");
            TextBox TextBoxF61 = (TextBox)row.FindControl("TextBoxF61");
            TextBox TextBoxF62 = (TextBox)row.FindControl("TextBoxF62");
            Label LabelT6 = (Label)row.FindControl("LabelT6");
            TextBox TextBoxT61 = (TextBox)row.FindControl("TextBoxT61");
            TextBox TextBoxT62 = (TextBox)row.FindControl("TextBoxT62");
            Label LabelCM = (Label)row.FindControl("LabelCM");
            TextBox TextBoxCM = (TextBox)row.FindControl("TextBoxCM");
            Label LabelRank = (Label)row.FindControl("LabelRank");
            TextBox TextBoxRank = (TextBox)row.FindControl("TextBoxRank");

            btnBack.Visible = false;
            btnSave.Visible = false;

            txtModelA.Enabled = false;
            txtModelB.Enabled = false;
            txtModelC.Enabled = false;

            rdModelA.Enabled = false;
            rdModelB.Enabled = false;
            rdModelC.Enabled = false;

            LabelF1.Visible = true;
            TextBoxF11.Visible = false;
            TextBoxF12.Visible = false;

            LabelT1.Visible = true;
            TextBoxT11.Visible = false;
            TextBoxT12.Visible = false;

            LabelF2.Visible = true;
            TextBoxF21.Visible = false;
            TextBoxF22.Visible = false;

            LabelT2.Visible = true;
            TextBoxT21.Visible = false;
            TextBoxT22.Visible = false;

            LabelF3.Visible = true;
            TextBoxF31.Visible = false;
            TextBoxF32.Visible = false;

            LabelT3.Visible = true;
            TextBoxT31.Visible = false;
            TextBoxT32.Visible = false;

            LabelF4.Visible = true;
            TextBoxF41.Visible = false;
            TextBoxF42.Visible = false;

            LabelT4.Visible = true;
            TextBoxT41.Visible = false;
            TextBoxT42.Visible = false;

            LabelF5.Visible = true;
            TextBoxF51.Visible = false;
            TextBoxF52.Visible = false;

            LabelT5.Visible = true;
            TextBoxT51.Visible = false;
            TextBoxT52.Visible = false;

            LabelF6.Visible = true;
            TextBoxF61.Visible = false;
            TextBoxF62.Visible = false;

            LabelT6.Visible = true;
            TextBoxT61.Visible = false;
            TextBoxT62.Visible = false;

            LabelRank.Visible = true;
            TextBoxRank.Visible = false;

            LabelPW.Visible = true;
            TextBoxPW.Visible = false;

            LabelCM.Visible = true;
            TextBoxCM.Visible = false;

            LabelPl.Visible = true;
            TextBoxPl.Visible = false;

            LabelAW.Visible = true;
            TextBoxAW.Visible = false;
            btnSave.Visible = false;
            setActiveRowEvent(row, false);
        }
        #endregion

        #region setLabelfromTextBox
        private void setLabelfromTextBox(Label lblFrom, Label lblTo, TextBox txtFromHour, TextBox txtFromMin, TextBox txtToHour, TextBox txtToMin)
        {
            if ("".Equals(txtFromHour.Text) || "".Equals(txtFromMin.Text) || "".Equals(txtToHour.Text) || "".Equals(txtToMin.Text))
            {
                lblFrom.Text = "";
                lblTo.Text = "";
            }
            else
            {
                lblFrom.Text = txtFromHour.Text + ":" + txtFromMin.Text;
                lblTo.Text = txtToHour.Text + ":" + txtToMin.Text;
            }
        }
        #endregion

        #region compareTimeFromTo
        private bool compareTimeFromTo(TextBox textbox11, TextBox textbox12, TextBox textbox21, TextBox textbox22)
        {
            if (textbox11.Text.Equals("") || textbox12.Text.Equals("") || textbox21.Text.Equals("") || textbox22.Text.Equals(""))
            {
                return true;
            }
            string from = textbox11.Text + ":" + textbox12.Text;
            string to = textbox21.Text + ":" + textbox22.Text;
            DateTime timeF1 = DateTime.ParseExact(from, "HH:mm", System.Globalization.CultureInfo.CurrentCulture);
            DateTime timeT1 = DateTime.ParseExact(to, "HH:mm", System.Globalization.CultureInfo.CurrentCulture);
            TimeSpan timeCompare = timeT1.Subtract(timeF1);
            if (timeCompare.TotalMinutes > 0)
            {
                textbox11.BackColor = System.Drawing.Color.White;
                textbox12.BackColor = System.Drawing.Color.White;
                textbox21.BackColor = System.Drawing.Color.White;
                textbox22.BackColor = System.Drawing.Color.White;
                return true;
            }
            else
            {
                alartErrorTime += " \\n Error " + textbox11.ID + " and " + textbox21.ID + ", check again";
                textbox11.BackColor = System.Drawing.Color.Red;
                textbox12.BackColor = System.Drawing.Color.Red;
                textbox21.BackColor = System.Drawing.Color.Red;
                textbox22.BackColor = System.Drawing.Color.Red;
                return false;
            }

        }
        #endregion

        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox rdBtn = (CheckBox)sender;
            GridViewRow rowChoosed = (GridViewRow)rdBtn.NamingContainer;
            int line = int.Parse(rowChoosed.Cells[0].Text);
            bool rs = rdBtn.Checked;
            LineInput_BLL line_ = new LineInput_BLL();
            line_.LineDay_UpdateRS(line, rs);
        }

        #region loadGridView()
        public void loadGridView()
        {
            dt = new DataTable();
            dt = inputDay.LineDaySelectAll(planid);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        #endregion
        // load grid view
        #region rowcreated event
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                headerRow1.CssClass = "GridviewScrollHeader";
                headerRow2.CssClass = "GridviewScrollHeader";
                
                TableHeaderCell headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "L";
                headerTableCell.RowSpan = 2;
                headerRow1.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "Model A";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerTableCell.RowSpan = 2;
                headerRow1.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "Model B";
                headerTableCell.RowSpan = 2;
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow1.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "Model C";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerTableCell.RowSpan = 2;
                headerRow1.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "R/S";
                headerTableCell.ToolTip = "Run / Stop";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerTableCell.RowSpan = 2;
                headerRow1.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "P.W";
                headerTableCell.ToolTip = "Planed worker";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerTableCell.RowSpan = 2;
                headerRow1.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "A.W";
                headerTableCell.ToolTip = "Actual worker";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerTableCell.RowSpan = 2;
                headerRow1.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "Plan";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerTableCell.RowSpan = 2;
                headerRow1.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "T. Time";
                headerTableCell.ToolTip = "Tact Time";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerTableCell.RowSpan = 2;
                headerRow1.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "T. Minute";
                headerTableCell.ToolTip = "Total Minute";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerTableCell.RowSpan = 2;
                headerRow1.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "Time 1";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerTableCell.ColumnSpan = 2;
                headerRow1.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "Time 2";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerTableCell.ColumnSpan = 2;
                headerRow1.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "Time 3";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerTableCell.ColumnSpan = 2;
                headerRow1.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "Time 4";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerTableCell.ColumnSpan = 2;
                headerRow1.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "Time 5";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerTableCell.ColumnSpan = 2;
                headerRow1.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "Time 6";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerTableCell.ColumnSpan = 2;
                headerRow1.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "Cmts";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerTableCell.RowSpan = 2;
                headerRow1.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "Rank";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerTableCell.RowSpan = 2;
                headerRow1.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "Op.";
                headerTableCell.ToolTip = "Option";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerTableCell.RowSpan = 2;
                headerRow1.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "Fr.1";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "To1";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "Fr.2";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "To2";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "Fr.3";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "To4";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "Fr.4";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "To4";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "Fr.5";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "To5";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "Fr.6";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Controls.Add(headerTableCell);
                headerTableCell = new TableHeaderCell();
                headerTableCell.Text = "To6";
                headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Controls.Add(headerTableCell);
                GridView1.Controls[0].Controls.AddAt(0, headerRow2);
                GridView1.Controls[0].Controls.AddAt(0, headerRow1);
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.CssClass = "GridviewScrollItem";
            }
        }
        #endregion

        #region checkTextBox
        public bool checkTextBoxInt(TextBox textbox, int max, int min)
        {
            bool check = true;
            int outint = 0;
            if (textbox.Text.Trim().Equals(""))
            {
                check = false;
                return check;
            }
            if (!int.TryParse(textbox.Text, out outint))
            {
                check = false;
            }
            if (outint < min || outint > max)
            {
                check = false;
            }
            if (!check)
            {
                alartError += "\\n" + textbox.ID + "is only integer, not blank, from " + min + " to " + max;
            }
            return check;
        }
        #endregion

        #region checkIntegerTextBox
        private bool checkIntegerTextBox(TextBox textbox)
        {
            int checkint = 0;
            if (!int.TryParse(textbox.Text, out checkint))
            {
                textbox.Text = "";
                return false;
            }
            if (checkint < 10)
                textbox.Text = "0" + checkint;
            else
                textbox.Text = checkint.ToString();
            return true;
        }
        #endregion


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchCustomers(string prefixText, int count)
        {
            Model_BLL modelBLL = new Model_BLL();
            return modelBLL.SearchByChar(prefixText);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click to select this row.";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);

                ImageButton btnSave = (ImageButton)e.Row.FindControl("btnSave");
                TextBox txtModelA = (TextBox)e.Row.FindControl("TextBoxMDA");
                TextBox txtModelB = (TextBox)e.Row.FindControl("TextBoxMDB");
                TextBox txtModelC = (TextBox)e.Row.FindControl("TextBoxMDC");
                RadioButton rdModelA = (RadioButton)e.Row.FindControl("rdModelA");
                RadioButton rdModelB = (RadioButton)e.Row.FindControl("rdModelB");
                RadioButton rdModelC = (RadioButton)e.Row.FindControl("rdModelC");
                CheckBox chkAll = (CheckBox)e.Row.FindControl("chkAll");
                Label LabelPW = (Label)e.Row.FindControl("LabelPW");
                TextBox TextBoxPW = (TextBox)e.Row.FindControl("TextBoxPW");
                Label LabelAW = (Label)e.Row.FindControl("LabelAW");
                TextBox TextBoxAW = (TextBox)e.Row.FindControl("TextBoxAW");

                int line = int.Parse(e.Row.Cells[0].Text);
                int lineNew = line + 7;
                if (line >= 44) e.Row.Cells[0].Text = lineNew.ToString();


                string model = dt.Rows[line - 1]["Model"].ToString();
                txtModelA.Attributes.Add("onkeypress", "button_click(this,'" + btnSave.ClientID + "')");
                if (txtModelA.Text.Equals(model))
                {
                    rdModelA.Checked = true;
                }
                else if (txtModelB.Text.Equals(model))
                {
                    rdModelB.Checked = true;
                }
                else if (txtModelC.Text.Equals(model))
                {
                    rdModelC.Checked = true;
                }
                if (line == dt.Rows.Count)
                {
                    txtModelA.Text = "Stocking";
                    txtModelB.Visible = false;
                    txtModelC.Visible = false;
                    rdModelA.Visible = false;
                    rdModelB.Visible = false;
                    rdModelC.Visible = false;
                    chkAll.Visible = false;
                    TextBoxAW.Visible = false;
                    TextBoxPW.Visible = false;
                }
            }
        }

        private bool checkTextBoxIntAllowNull(TextBox textbox, int max, int min)
        {
            bool check = true;
            int outint = 0;
            if (textbox.Text.Equals(""))
            {
                return true;
            }
            if (!int.TryParse(textbox.Text, out outint))
            {
                check = false;
            }
            if (outint < min || outint > max)
            {
                check = false;
            }
            if (!check)
            {
                alartError += "\\n" + textbox.ID + "is only integer, from " + min + " to " + max;
            }
            return check;
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
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    setActiveRowEvent(row, true);
                    ImageButton btnSave = (ImageButton)row.FindControl("btnSave");
                    ImageButton btnBack = (ImageButton)row.FindControl("btnBack");
                    Label LabelMD = (Label)row.FindControl("LabelMD");
                    TextBox txtModelA = (TextBox)row.FindControl("TextBoxMDA");
                    TextBox txtModelB = (TextBox)row.FindControl("TextBoxMDB");
                    TextBox txtModelC = (TextBox)row.FindControl("TextBoxMDC");
                    RadioButton rdModelA = (RadioButton)row.FindControl("rdModelA");
                    RadioButton rdModelB = (RadioButton)row.FindControl("rdModelB");
                    RadioButton rdModelC = (RadioButton)row.FindControl("rdModelC");
                    TextBox TextBoxMD = (TextBox)row.FindControl("TextBoxMD");
                    Label LabelTT = (Label)row.FindControl("LabelTT");
                    TextBox TextBoxTT = (TextBox)row.FindControl("TextBoxTT");
                    Label LabelTM = (Label)row.FindControl("LabelTM");
                    TextBox TextBoxTM = (TextBox)row.FindControl("TextBoxTM");
                    Label LabelPW = (Label)row.FindControl("LabelPW");
                    TextBox TextBoxPW = (TextBox)row.FindControl("TextBoxPW");
                    Label LabelAW = (Label)row.FindControl("LabelAW");
                    TextBox TextBoxAW = (TextBox)row.FindControl("TextBoxAW");
                    Label LabelPl = (Label)row.FindControl("LabelPl");
                    TextBox TextBoxPl = (TextBox)row.FindControl("TextBoxPl");
                    Label LabelF1 = (Label)row.FindControl("LabelF1");
                    TextBox TextBoxF11 = (TextBox)row.FindControl("TextBoxF11");
                    TextBox TextBoxF12 = (TextBox)row.FindControl("TextBoxF12");
                    Label LabelT1 = (Label)row.FindControl("LabelT1");
                    TextBox TextBoxT11 = (TextBox)row.FindControl("TextBoxT11");
                    TextBox TextBoxT12 = (TextBox)row.FindControl("TextBoxT12");
                    Label LabelF2 = (Label)row.FindControl("LabelF2");
                    TextBox TextBoxF21 = (TextBox)row.FindControl("TextBoxF21");
                    TextBox TextBoxF22 = (TextBox)row.FindControl("TextBoxF22");
                    Label LabelT2 = (Label)row.FindControl("LabelT2");
                    TextBox TextBoxT21 = (TextBox)row.FindControl("TextBoxT21");
                    TextBox TextBoxT22 = (TextBox)row.FindControl("TextBoxT22");
                    Label LabelF3 = (Label)row.FindControl("LabelF3");
                    TextBox TextBoxF31 = (TextBox)row.FindControl("TextBoxF31");
                    TextBox TextBoxF32 = (TextBox)row.FindControl("TextBoxF32");
                    Label LabelT3 = (Label)row.FindControl("LabelT3");
                    TextBox TextBoxT31 = (TextBox)row.FindControl("TextBoxT31");
                    TextBox TextBoxT32 = (TextBox)row.FindControl("TextBoxT32");
                    Label LabelF4 = (Label)row.FindControl("LabelF4");
                    TextBox TextBoxF41 = (TextBox)row.FindControl("TextBoxF41");
                    TextBox TextBoxF42 = (TextBox)row.FindControl("TextBoxF42");
                    Label LabelT4 = (Label)row.FindControl("LabelT4");
                    TextBox TextBoxT41 = (TextBox)row.FindControl("TextBoxT41");
                    TextBox TextBoxT42 = (TextBox)row.FindControl("TextBoxT42");
                    Label LabelF5 = (Label)row.FindControl("LabelF5");
                    TextBox TextBoxF51 = (TextBox)row.FindControl("TextBoxF51");
                    TextBox TextBoxF52 = (TextBox)row.FindControl("TextBoxF52");
                    Label LabelT5 = (Label)row.FindControl("LabelT5");
                    TextBox TextBoxT51 = (TextBox)row.FindControl("TextBoxT51");
                    TextBox TextBoxT52 = (TextBox)row.FindControl("TextBoxT52");
                    Label LabelF6 = (Label)row.FindControl("LabelF6");
                    TextBox TextBoxF61 = (TextBox)row.FindControl("TextBoxF61");
                    TextBox TextBoxF62 = (TextBox)row.FindControl("TextBoxF62");
                    Label LabelT6 = (Label)row.FindControl("LabelT6");
                    TextBox TextBoxT61 = (TextBox)row.FindControl("TextBoxT61");
                    TextBox TextBoxT62 = (TextBox)row.FindControl("TextBoxT62");
                    Label LabelCM = (Label)row.FindControl("LabelCM");
                    TextBox TextBoxCM = (TextBox)row.FindControl("TextBoxCM");
                    Label LabelRank = (Label)row.FindControl("LabelRank");
                    TextBox TextBoxRank = (TextBox)row.FindControl("TextBoxRank");
                    // set trang thai de chinh sua
                    btnSave.Visible = true;
                    btnBack.Visible = true;
                    LabelPW.Visible = false;
                    TextBoxPW.Visible = true;
                    TextBoxPW.Text = LabelPW.Text;

                    txtModelA.Enabled = true;
                    txtModelB.Enabled = true;
                    txtModelC.Enabled = true;

                    rdModelA.Enabled = true;
                    rdModelB.Enabled = true;
                    rdModelC.Enabled = true;

                    LabelAW.Visible = false;
                    TextBoxAW.Visible = true;
                    TextBoxAW.Text = LabelAW.Text;

                    LabelPl.Visible = false;
                    TextBoxPl.Visible = true;
                    TextBoxPl.Text = LabelPl.Text;

                    LabelF1.Visible = false;
                    TextBoxF11.Visible = true;
                    TextBoxF12.Visible = true;
                    if (!LabelF1.Text.Equals(""))
                    {
                        string[] f1 = LabelF1.Text.Split(':');
                        TextBoxF11.Text = f1[0].ToString();
                        TextBoxF12.Text = f1[1].ToString();
                    }

                    LabelT1.Visible = false;
                    TextBoxT11.Visible = true;
                    TextBoxT12.Visible = true;
                    if (!LabelT1.Text.Equals(""))
                    {
                        string[] t1 = LabelT1.Text.Split(':');
                        TextBoxT11.Text = t1[0].ToString();
                        TextBoxT12.Text = t1[1].ToString();
                    }

                    LabelF2.Visible = false;
                    TextBoxF21.Visible = true;
                    TextBoxF22.Visible = true;
                    if (!LabelF2.Text.Equals(""))
                    {
                        string[] f2 = LabelF2.Text.Split(':');
                        TextBoxF21.Text = f2[0].ToString();
                        TextBoxF22.Text = f2[1].ToString();
                    }

                    LabelT2.Visible = false;
                    TextBoxT21.Visible = true;
                    TextBoxT22.Visible = true;
                    if (!LabelT2.Text.Equals(""))
                    {
                        string[] t2 = LabelT2.Text.Split(':');
                        TextBoxT21.Text = t2[0].ToString();
                        TextBoxT22.Text = t2[1].ToString();
                    }

                    LabelF3.Visible = false;
                    TextBoxF31.Visible = true;
                    TextBoxF32.Visible = true;
                    if (!LabelF3.Text.Equals(""))
                    {
                        string[] f3 = LabelF3.Text.Split(':');
                        TextBoxF31.Text = f3[0].ToString();
                        TextBoxF32.Text = f3[1].ToString();
                    }

                    LabelT3.Visible = false;
                    TextBoxT31.Visible = true;
                    TextBoxT32.Visible = true;
                    if (!LabelT3.Text.Equals(""))
                    {
                        string[] t3 = LabelT3.Text.Split(':');
                        TextBoxT31.Text = t3[0].ToString();
                        TextBoxT32.Text = t3[1].ToString();
                    }
                    LabelF4.Visible = false;
                    TextBoxF41.Visible = true;
                    TextBoxF42.Visible = true;
                    if (!LabelF4.Text.Equals(""))
                    {
                        string[] f4 = LabelF4.Text.Split(':');
                        TextBoxF41.Text = f4[0].ToString();
                        TextBoxF42.Text = f4[1].ToString();
                    }

                    LabelT4.Visible = false;
                    TextBoxT41.Visible = true;
                    TextBoxT42.Visible = true;
                    if (!LabelT4.Text.Equals(""))
                    {
                        string[] t4 = LabelT4.Text.Split(':');
                        TextBoxT41.Text = t4[0].ToString();
                        TextBoxT42.Text = t4[1].ToString();
                    }
                    LabelF5.Visible = false;
                    TextBoxF51.Visible = true;
                    TextBoxF52.Visible = true;
                    if (!LabelF5.Text.Equals(""))
                    {
                        string[] f5 = LabelF5.Text.Split(':');
                        TextBoxF51.Text = f5[0].ToString();
                        TextBoxF52.Text = f5[1].ToString();

                    }
                    LabelT5.Visible = false;
                    TextBoxT51.Visible = true;
                    TextBoxT52.Visible = true;
                    if (!LabelT5.Text.Equals(""))
                    {
                        string[] t5 = LabelT5.Text.Split(':');
                        TextBoxT51.Text = t5[0].ToString();
                        TextBoxT52.Text = t5[1].ToString();
                    }
                    LabelF6.Visible = false;
                    TextBoxF61.Visible = true;
                    TextBoxF62.Visible = true;
                    if (LabelF6.Text.Length != 0)
                    {
                        string[] f6 = LabelF6.Text.Split(':');
                        TextBoxF61.Text = f6[0].ToString();
                        TextBoxF62.Text = f6[1].ToString();
                    }


                    LabelT6.Visible = false;
                    TextBoxT61.Visible = true;
                    TextBoxT62.Visible = true;
                    if (LabelT6.Text.Length != 0)
                    {
                        string[] t6 = LabelT6.Text.Split(':');
                        TextBoxT61.Text = t6[0].ToString();
                        TextBoxT62.Text = t6[1].ToString();
                    }

                    LabelCM.Visible = false;
                    TextBoxCM.Visible = true;
                    TextBoxCM.Text = LabelCM.Text;

                    LabelRank.Visible = false;
                    TextBoxRank.Visible = true;
                    TextBoxRank.Text = LabelRank.Text;

                }
                else
                {
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        protected void lbtInputForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("InputForm.aspx");
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            // Cần để vào try catch vì phát sinh lỗi bấm show trước khi chọn ngày tháng => datepick không hợp lệ
            try
            {
                DateTime datepick = DateTime.ParseExact(datepicker.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                planid = plan_BLL.findPlanIdByDateTime(datepick);
                if (planid == 0)
                {
                    // khong co du lieu ve ngay duoc chon
                    lblAlart.Text = "No datasoure at " + datepick;
                    statusPage(true);
                    btnCreate.Visible = true;
                }
                else
                {
                    // co du lieu ngay da chon
                    statusPage(false);
                    loadGridView();
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Loi: Chua chon ngay thang.\n"+ ex);
                Debug.WriteLine("Exception: Chua chon ngay\n" + ex.Message);
            }
        }

        private void statusPage(bool check)
        {
            lblAlart.Visible = check;
            btnCreate.Visible = check;
            GridView1.Visible = !check;
            ddlShift.Visible = !check;
        }

        //Thêm một line ca ngày không có dữ liệu có sẵn
        private void insertLineDayNoData(int lineName)
        {
            LineInputDay line_ = new LineInputDay();
            DateTime datepickChoose = DateTime.ParseExact(datepicker.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            line_.line = lineName;
            if (lineName == sumLine)
            {
                // Nếu là line stocking
                line_.modelA = "Stocking";
                line_.model = "Stocking";
            }
            line_.planid = plan_BLL.findPlanIdByDateTime(datepickChoose);
            line_.rs = false;
            line_.planed_woker = 0;
            line_.actual_woker = 0;
            line_.plan = 0;
            line_.tact_time = 0;
            line_.total_min = 0;
            line_.from1 = "7:05";
            line_.to1 = "09:00";
            line_.from2 = "09:10";
            line_.to2 = "11:15";
            line_.from3 = "12:00";
            line_.to3 = "14:00";
            line_.from4 = "14:10";
            line_.to4 = "16:15";
            line_.from5 = "16:25";
            line_.to5 = "18:20";
            line_.from6 = "";
            line_.to6 = "";
            line_.rank = "-";
            line_.comment = "-";
            line_.status = "-";

            inputDay.LineDayInsert(line_);

            //Thêm 1 line lưu màu sắc
            colorDay.LineColor_Insert(lineName, plan_BLL.findPlanIdByDateTime(datepickChoose));
        }

        //Thêm một line ca ngày lấy dữ liệu từ plan cũ
        private void insertLineDay(int i, int lineName)
        {
            LineInputDay line_ = new LineInputDay();
            DateTime datepickChoose = DateTime.ParseExact(datepicker.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            line_.line = lineName; //common.ConvertInt(dt.Rows[i]["LineName"].ToString());
            line_.planid = plan_BLL.findPlanIdByDateTime(datepickChoose);
            line_.model = dt.Rows[i]["Model"].ToString();
            line_.modelA = dt.Rows[i]["ModelA"].ToString();
            line_.modelB = dt.Rows[i]["ModelB"].ToString();
            line_.modelC = dt.Rows[i]["ModelC"].ToString();
            line_.rs = bool.Parse(dt.Rows[i]["RS"].ToString());
            line_.planed_woker = common.ConvertInt(dt.Rows[i]["Planed_Worker"].ToString());
            line_.actual_woker = common.ConvertInt(dt.Rows[i]["Actual_Worker"].ToString());
            line_.plan = common.ConvertInt(dt.Rows[i]["Plan"].ToString());
            float a = 0;
            if (float.TryParse(dt.Rows[i]["Tact_Time"].ToString(), out a))
            {
                line_.tact_time = a;
            }
            else
            {
                line_.tact_time = a;
            }

            line_.total_min = common.ConvertInt(dt.Rows[i]["Total_Minute"].ToString());
            line_.from1 = dt.Rows[i]["From1"].ToString();
            line_.to1 = dt.Rows[i]["To1"].ToString();
            line_.from2 = dt.Rows[i]["From2"].ToString();
            line_.to2 = dt.Rows[i]["To2"].ToString();
            line_.from3 = dt.Rows[i]["From3"].ToString();
            line_.to3 = dt.Rows[i]["To3"].ToString();
            line_.from4 = dt.Rows[i]["From4"].ToString();
            line_.to4 = dt.Rows[i]["To4"].ToString();
            line_.from5 = dt.Rows[i]["From5"].ToString();
            line_.to5 = dt.Rows[i]["To5"].ToString();
            line_.from6 = dt.Rows[i]["From6"].ToString();
            line_.to6 = dt.Rows[i]["To6"].ToString();
            line_.rank = dt.Rows[i]["Rank"].ToString();
            line_.comment = dt.Rows[i]["Comments"].ToString();
            line_.status = "-";
            inputDay.LineDayInsert(line_);
            colorDay.LineColor_Insert(lineName, plan_BLL.findPlanIdByDateTime(datepickChoose));
        }

        //Thêm một line ca tối không có dữ liệu có sẵn
        private void insertLineNightNoData(int lineName)
        {
            LineInputNight line_ = new LineInputNight();
            DateTime datepickChoose = DateTime.ParseExact(datepicker.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            line_.line = lineName;
            if (lineName == sumLine)
            {
                // Nếu là line stocking
                line_.modelA = "Stocking";
                line_.model = "Stocking";
            }
            line_.planid = plan_BLL.findPlanIdByDateTime(datepickChoose);
            line_.rs = false;
            line_.planed_woker = 0;
            line_.actual_woker = 0;
            line_.plan = 0;
            line_.tact_time = 0;
            line_.total_min = 0;
            line_.from1 = "19:05";
            line_.to1 = "21:00";
            line_.from2 = "21:10";
            line_.to2 = "23:00";
            line_.from3 = "23:45";
            line_.to3 = "02:00";
            line_.from4 = "02:10";
            line_.to4 = "04:15";
            line_.from5 = "04:25";
            line_.to5 = "06:20";
            line_.from6 = "";
            line_.to6 = "";
            line_.rank = "-";
            line_.comment = "-";
            line_.status = "-";

            inputNight.LineNightInsert(line_);

            // Thêm line màu sắc
            colorNight.LineColor_Insert(lineName, plan_BLL.findPlanIdByDateTime(datepickChoose));
        }

        //Thêm một line ca tối lấy dữ liệu từ plan cũ
        private void insertLineNight(int i, int lineName)
        {
            LineInputNight line_ = new LineInputNight();
            DateTime datepickChoose = DateTime.ParseExact(datepicker.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            line_.line = lineName; // common.ConvertInt(dt.Rows[i]["LineName"].ToString());
            line_.planid = plan_BLL.findPlanIdByDateTime(datepickChoose);
            line_.model = dt.Rows[i]["Model"].ToString();
            line_.modelA = dt.Rows[i]["ModelA"].ToString();
            line_.modelB = dt.Rows[i]["ModelB"].ToString();
            line_.modelC = dt.Rows[i]["ModelC"].ToString();
            line_.rs = bool.Parse(dt.Rows[i]["RS"].ToString());
            line_.planed_woker = common.ConvertInt(dt.Rows[i]["Planed_Worker"].ToString());
            line_.actual_woker = common.ConvertInt(dt.Rows[i]["Actual_Worker"].ToString());
            line_.plan = common.ConvertInt(dt.Rows[i]["Plan"].ToString());
            float a = 0;
            if (float.TryParse(dt.Rows[i]["Tact_Time"].ToString(), out a))
            {
                line_.tact_time = a;
            }
            else
            {
                line_.tact_time = a;
            }
            line_.total_min = common.ConvertInt(dt.Rows[i]["Total_Minute"].ToString());
            line_.from1 = dt.Rows[i]["From1"].ToString();
            line_.to1 = dt.Rows[i]["To1"].ToString();
            line_.from2 = dt.Rows[i]["From2"].ToString();
            line_.to2 = dt.Rows[i]["To2"].ToString();
            line_.from3 = dt.Rows[i]["From3"].ToString();
            line_.to3 = dt.Rows[i]["To3"].ToString();
            line_.from4 = dt.Rows[i]["From4"].ToString();
            line_.to4 = dt.Rows[i]["To4"].ToString();
            line_.from5 = dt.Rows[i]["From5"].ToString();
            line_.to5 = dt.Rows[i]["To5"].ToString();
            line_.from6 = dt.Rows[i]["From6"].ToString();
            line_.to6 = dt.Rows[i]["To6"].ToString();
            line_.rank = dt.Rows[i]["Rank"].ToString();
            line_.comment = dt.Rows[i]["Comments"].ToString();
            line_.status = "-";
            inputNight.LineNightInsert(line_);
            colorNight.LineColor_Insert(lineName, plan_BLL.findPlanIdByDateTime(datepickChoose));
        }

        //Tạo kế hoạch mới
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            DateTime datepickChoose = DateTime.ParseExact(datepicker.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            int planIdCurrent = plan_BLL.findPlanIdByDateTime(datepickChoose);
            if (planIdCurrent != 0) return;
            int planidPast = 0;
           
            if (plan_BLL.PlanDate_createNewPlan(datepickChoose))
            {
                // Nếu createNewPlan thành công
                // Tìm ID của kế hoạch gần nhất
                // limitDay: Giới hạn tìm kiếm trong 183 ngày gần nhất
                int limitDay = 183;
                while (planidPast == 0 && limitDay > 0)
                {
                    limitDay--;
                    int a = datepickChoose.Day;
                    datepickChoose = datepickChoose.AddDays(-1);
                    int b = datepickChoose.Day;
                    planidPast = plan_BLL.findPlanIdByDateTime(datepickChoose);
                }

                if (planidPast == 0)
                {
                    //Nếu không có kế hoạch gần nhất, tạo các line mới có giá trị mặc định là 0
                    for (int i = 0; i < sumLine; i++)
                    {
                        // Thêm ca ngày
                        insertLineDayNoData(i + 1);  //Thêm line ca ngày

                        // Thêm ca tối
                        insertLineNightNoData(i + 1);
                    }
                }
                else
                {
                    // Nếu tìm thấy kế hoạch gần nhất, lấy các giá trị của kế hoạch cũ để tạo kế hoạch mới
                    dt = inputDay.LineDaySelectAll(planidPast);
                    int numberOfRow = 0;    // Lưu số dòng sẽ lấy lại dữ liệu từ bản kế hoạch cũ

                    string script = "alert(\"Number of row" + dt.Rows.Count.ToString() + " \");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                    if (dt.Rows.Count < sumLine)
                    {
                        // Nếu kế hoạch mới có tổng line nhiều hơn kế hoạch cũ (VD: 47>39). Copy tất cả các line của kế hoạch cũ, trừ line Stocking
                        numberOfRow = dt.Rows.Count;
                    }
                    else numberOfRow = sumLine;
                    //Nếu không, số line cần lấy bằng số line của kế hoạch mới

                    for (int i = 0; i < numberOfRow - 1; i++)
                    {
                        insertLineDay(i, i + 1);
                    }

                    // Nếu số lượng line cần thêm nhiều hơn số line của kế hoạch cũ
                    for (int i = numberOfRow - 1; i < sumLine - 1; i++)
                    {
                        insertLineDayNoData(i + 1);
                    }
                    //Insert Stocking
                    insertLineDay(numberOfRow - 1, sumLine);

                    //NIGHT
                    dt = inputNight.LineNightSelectAll(planidPast);
                    for (int i = 0; i < numberOfRow - 1; i++)
                    {
                        insertLineNight(i, i + 1);
                    }

                    // Nếu số lượng line cần thêm nhiều hơn số line của kế hoạch cũ
                    for (int i = numberOfRow - 1; i < sumLine - 1; i++)
                    {
                        insertLineNightNoData(i + 1);
                    }
                    //Insert Stocking
                    insertLineNight(numberOfRow - 1, sumLine);
                }


                datepickChoose = DateTime.ParseExact(datepicker.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                planid = plan_BLL.findPlanIdByDateTime(datepickChoose);
                statusPage(false);
                loadGridView();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error: Fail create new day, try again with other day');", true);
            }
        }

       
    }
}