using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Data;
using System.Drawing;
using Common;
using System.IO;
namespace Website
{
    public partial class Default : System.Web.UI.Page
    {
        CommonFuntion common = new CommonFuntion();
        LineInput_BLL_base input = new LineInput_BLL_base();
        LineInput_BLL input_BLL = new LineInput_BLL();
        PlanDate_BLL plan_BLL = new PlanDate_BLL();
        DataTable dt;
        private int totalPl = 0;
        private int totalAC = 0;
        private int totalDiff = 0;
        private int totalPW = 0;
        private int totalAW = 0;
        private int total7 = 0;
        private int total8 = 0;
        private int total9 = 0;
        private int total10 = 0;
        private int total11 = 0;
        private int total12 = 0;
        private int total13 = 0;
        private int total14 = 0;
        private int total15 = 0;
        private int total16 = 0;
        private int total17 = 0;
        private int total18 = 0;
        private int totalTarget = 0;
        private int stockingPosition = 0;   //Vị trí của line stocking.

        protected void Page_Load(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour > 18 || DateTime.Now.Hour < 7) {
                Response.Redirect("OutputNight.aspx");
            }
            planid = plan_BLL.findPlanIdByDateTime(DateTime.Now);
            if (planid > 0)
            {
                loadGridView();
                loadFooterGridView();
            }
        }
        private static int planid = 0;

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string color;
            LineColorDay_BLL colorLine = new LineColorDay_BLL();
            LineInputDay lineStocking = new LineInputDay();
            lineStocking = input_BLL.InputDay_GetStocking(planid);
            stockingPosition = lineStocking.line;

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                int index = GridView1.Rows.Count;
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Normal);
                TableCell cell = new TableCell();
                cell.Text = "Stocking:";
                cell.ColumnSpan = 4;
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = "-";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = "-";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.plan.ToString();
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.actual.ToString();
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.diff.ToString();
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.target.ToString();
                row.Cells.Add(cell);
                cell = new TableCell();
                float actualrateStocking = 0;
                if (lineStocking.target != 0)
                {
                    actualrateStocking = (float)lineStocking.actual / lineStocking.target * 100;
                }
                cell.Text = actualrateStocking.ToString("F1") + "%";
                row.Cells.Add(cell);
                cell = new TableCell();

                cell.Text = lineStocking.h07.ToString();
                cell.BackColor = setColor(colorLine.getColorDayByColum("Color07H", stockingPosition, planid));
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.h08.ToString();
                cell.BackColor = setColor(colorLine.getColorDayByColum("Color08H", stockingPosition, planid));
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.h09.ToString();
                cell.BackColor = setColor(colorLine.getColorDayByColum("Color09H", stockingPosition, planid));
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.h10.ToString();
                cell.BackColor = setColor(colorLine.getColorDayByColum("Color10H", stockingPosition, planid));
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.h11.ToString();
                cell.BackColor = setColor(colorLine.getColorDayByColum("Color11H", stockingPosition, planid));
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.h12.ToString();
                cell.BackColor = setColor(colorLine.getColorDayByColum("Color12H", stockingPosition, planid));
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.h13.ToString();
                cell.BackColor = setColor(colorLine.getColorDayByColum("Color13H", stockingPosition, planid));
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.h14.ToString();
                cell.BackColor = setColor(colorLine.getColorDayByColum("Color14H", stockingPosition, planid));
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.h15.ToString();
                cell.BackColor = setColor(colorLine.getColorDayByColum("Color15H", stockingPosition, planid));
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.h16.ToString();
                cell.BackColor = setColor(colorLine.getColorDayByColum("Color16H", stockingPosition, planid));
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.h17.ToString();
                cell.BackColor = setColor(colorLine.getColorDayByColum("Color17H", stockingPosition, planid));
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.h18.ToString();
                cell.BackColor = setColor(colorLine.getColorDayByColum("Color18H", stockingPosition, planid));
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.comment.ToString();
                row.Cells.Add(cell);
                GridView1.Controls[0].Controls.Add(row);
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int line = int.Parse(e.Row.Cells[0].Text);
                int lineNew = line + 7;
                if (line >= 44) e.Row.Cells[0].Text = lineNew.ToString();
                if (input_BLL.InputDay_CheckRSbyLine(line, planid))
                {
                    
                    if (!e.Row.Cells[4].Text.Equals(""))
                    {
                        totalPW += common.ConvertInt(e.Row.Cells[4].Text);
                    }
                    if (!e.Row.Cells[5].Text.Equals(""))
                    {
                        totalAW += common.ConvertInt(e.Row.Cells[5].Text);
                    }
                    if (!e.Row.Cells[6].Text.Equals(""))
                    {
                        totalPl += common.ConvertInt(e.Row.Cells[6].Text);
                    }
                    if (!e.Row.Cells[7].Text.Equals(""))
                    {
                        totalAC += common.ConvertInt(e.Row.Cells[7].Text);
                    }
                    if (!e.Row.Cells[8].Text.Equals(""))
                    {
                        totalDiff += common.ConvertInt(e.Row.Cells[8].Text);
                    }
                    if (!e.Row.Cells[9].Text.Equals(""))
                    {
                        totalTarget += common.ConvertInt(e.Row.Cells[9].Text);
                    }
                    if (!e.Row.Cells[11].Text.Equals(""))
                    {
                        color = colorLine.getColorDayByColum("Color07H", line, planid);
                        e.Row.Cells[11].BackColor = setColor(color);
                        total7 += common.ConvertInt(e.Row.Cells[11].Text);
                    }
                    if (!e.Row.Cells[12].Text.Equals(""))
                    {
                        color = colorLine.getColorDayByColum("Color08H", line, planid);
                        e.Row.Cells[12].BackColor = setColor(color);
                        total8 += common.ConvertInt(e.Row.Cells[12].Text);
                    }
                    if (!e.Row.Cells[13].Text.Equals(""))
                    {
                        color = colorLine.getColorDayByColum("Color09H", line, planid);
                        e.Row.Cells[13].BackColor = setColor(color);
                        total9 += common.ConvertInt(e.Row.Cells[13].Text);
                    }
                    if (!e.Row.Cells[14].Text.Equals(""))
                    {
                        color = colorLine.getColorDayByColum("Color10H", line, planid);
                        e.Row.Cells[14].BackColor = setColor(color);
                        total10 += common.ConvertInt(e.Row.Cells[14].Text);
                    }
                    if (!e.Row.Cells[15].Text.Equals(""))
                    {
                        color = colorLine.getColorDayByColum("Color11H", line, planid);
                        e.Row.Cells[15].BackColor = setColor(color);
                        total11 += common.ConvertInt(e.Row.Cells[15].Text);
                    }
                    if (!e.Row.Cells[16].Text.Equals(""))
                    {
                        color = colorLine.getColorDayByColum("Color12H", line, planid);
                        e.Row.Cells[16].BackColor = setColor(color);
                        total12 += common.ConvertInt(e.Row.Cells[16].Text);
                    }
                    if (!e.Row.Cells[17].Text.Equals(""))
                    {
                        color = colorLine.getColorDayByColum("Color13H", line, planid);
                        e.Row.Cells[17].BackColor = setColor(color);
                        total13 += common.ConvertInt(e.Row.Cells[17].Text);
                    }
                    if (!e.Row.Cells[18].Text.Equals(""))
                    {
                        color = colorLine.getColorDayByColum("Color14H", line, planid);
                        e.Row.Cells[18].BackColor = setColor(color);
                        total14 += common.ConvertInt(e.Row.Cells[18].Text);
                    }
                    if (!e.Row.Cells[19].Text.Equals(""))
                    {
                        color = colorLine.getColorDayByColum("Color15H", line, planid);
                        e.Row.Cells[19].BackColor = setColor(color);
                        total15 += common.ConvertInt(e.Row.Cells[19].Text);
                    }
                    if (!e.Row.Cells[20].Text.Equals(""))
                    {
                        color = colorLine.getColorDayByColum("Color16H", line, planid);
                        e.Row.Cells[20].BackColor = setColor(color);
                        total16 += common.ConvertInt(e.Row.Cells[20].Text);
                    }
                    if (!e.Row.Cells[21].Text.Equals(""))
                    {
                        color = colorLine.getColorDayByColum("Color17H", line, planid);
                        e.Row.Cells[21].BackColor = setColor(color);
                        total17 += common.ConvertInt(e.Row.Cells[21].Text);
                    }
                    if (!e.Row.Cells[22].Text.Equals(""))
                    {
                        color = colorLine.getColorDayByColum("Color18H", line, planid);
                        e.Row.Cells[22].BackColor = setColor(color);
                        total18 += common.ConvertInt(e.Row.Cells[22].Text);
                    }

                    if (e.Row.Cells[23].Text.Trim().Equals("Run"))
                    {
                        e.Row.Cells[23].Text = "R";
                        e.Row.Cells[23].BackColor = Color.FromArgb(0, 204, 0);
                    }
                    else if (e.Row.Cells[23].Text.Trim().Equals("Stop"))
                    {
                        e.Row.Cells[23].Text = "S";
                        e.Row.Cells[23].BackColor = Color.Red;
                    }
                }
                else
                {
                    for (int i = 1; i < 23; i++)
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[23].Text = "-";
                }
            }
        }

        // Load gridview
        public void loadGridView()
        {
            dt = new DataTable();
            dt = input_BLL.InputDay_GetAllLines(planid);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        public void loadFooterGridView()
        {
            GridView1.FooterRow.Cells[2].Text = "Total";
            GridView1.FooterRow.Cells[4].Text = totalPW.ToString();
            GridView1.FooterRow.Cells[5].Text = totalAW.ToString();
            GridView1.FooterRow.Cells[6].Text = totalPl.ToString();
            GridView1.FooterRow.Cells[7].Text = totalAC.ToString();
            GridView1.FooterRow.Cells[8].Text = totalDiff.ToString();
            GridView1.FooterRow.Cells[9].Text = totalTarget.ToString();
            double totalActualRate = 0;
            if (totalTarget != 0)
            {
                totalActualRate = (double)totalAC / totalTarget * 100;
            }

            GridView1.FooterRow.Cells[10].Text = totalActualRate.ToString("F1") + "%";
            GridView1.FooterRow.Cells[11].Text = total7.ToString();
            GridView1.FooterRow.Cells[12].Text = total8.ToString();
            GridView1.FooterRow.Cells[13].Text = total9.ToString();
            GridView1.FooterRow.Cells[14].Text = total10.ToString();
            GridView1.FooterRow.Cells[15].Text = total11.ToString();
            GridView1.FooterRow.Cells[16].Text = total12.ToString();
            GridView1.FooterRow.Cells[17].Text = total13.ToString();
            GridView1.FooterRow.Cells[18].Text = total14.ToString();
            GridView1.FooterRow.Cells[19].Text = total15.ToString();
            GridView1.FooterRow.Cells[20].Text = total16.ToString();
            GridView1.FooterRow.Cells[21].Text = total17.ToString();
            GridView1.FooterRow.Cells[22].Text = total18.ToString();
        }

        protected void lbtInputForm_Click(object sender, EventArgs e)
        {
            if (ddlShift.SelectedValue.Equals("Day"))
            {
                Response.Redirect("InputForm.aspx");
            }
            else
            {
                Response.Redirect("InputFormNight.aspx");
            }
        }

        protected void lbtnExport_Click(object sender, EventArgs e)
        {
            string nameFile = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "-Output-Day ";
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + nameFile + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridView1.RenderControl(hw);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void ddlShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlShift.SelectedValue.Equals("Day"))
                Response.Redirect("Default.aspx");
            else
                Response.Redirect("OutputNight.aspx");
        }

        private Color setColor(String strColor)
        {
            Color color = new Color();
            if (strColor.Equals("GreenYellow"))
            {
                color = Color.FromArgb(0, 204, 0);
            }
            else if (strColor.Equals("Yellow"))
            {
                color = Color.Yellow;
            }
            else if (strColor.Equals("Red"))
            {
                color = Color.Red;
            }
            else
            {
                color = Color.White;
            }
            return color;
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void lbtnHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("History.aspx");
        }
    }
}