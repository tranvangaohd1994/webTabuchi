using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using System.IO;
using Entity;
namespace Website
{
    public partial class OutputNight : System.Web.UI.Page
    {
        CommonFuntion common = new CommonFuntion();
        LinetNight_BLL_base input = new LinetNight_BLL_base();
        LineNight_BLL input_BLL = new LineNight_BLL();
        PlanDate_BLL plan_BLL = new PlanDate_BLL();
        DataTable dt;
        private int totalPl = 0;
        private int totalAC = 0;
        private int totalDiff = 0;
        private int totalPW = 0;
        private int totalAW = 0;
        private int total19 = 0;
        private int total20 = 0;
        private int total21 = 0;
        private int total22 = 0;
        private int total23 = 0;
        private int total0 = 0;
        private int total1 = 0;
        private int total2 = 0;
        private int total3 = 0;
        private int total4 = 0;
        private int total5 = 0;
        private int total6 = 0;
        private int totalTarget = 0;
        private static int planid;
        private int stockingPosition = 0; //Xac dinh vi tri của lineStocking.


        protected void Page_Load(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour > 6 && DateTime.Now.Hour < 19)
            {
                Response.Redirect("Default.aspx");
            }
            planid = plan_BLL.findIdByDateTimeNextDay(DateTime.Now);
            loadGridView();
            loadFooterGridView();
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
            string nameFile = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "-Output-Night ";
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string color;
            LineColorNight_BLL colorLine = new LineColorNight_BLL();
            LineInputNight lineStocking = new LineInputNight();
            lineStocking = input_BLL.InputNight_GetStocking(planid);
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
                cell.Text = lineStocking.h19.ToString();
                cell.BackColor = setColor(colorLine.getColorNightByColum("Color19H", stockingPosition, planid));
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.h20.ToString();
                cell.BackColor = setColor(colorLine.getColorNightByColum("Color20H", stockingPosition, planid));
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.h21.ToString();
                cell.BackColor = setColor(colorLine.getColorNightByColum("Color21H", stockingPosition, planid));
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.h22.ToString();
                cell.BackColor = setColor(colorLine.getColorNightByColum("Color22H", stockingPosition, planid));
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.h23.ToString();
                cell.BackColor = setColor(colorLine.getColorNightByColum("Color23H", stockingPosition, planid));
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.h00.ToString();
                cell.BackColor = setColor(colorLine.getColorNightByColum("Color00H", stockingPosition, planid));
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.h01.ToString();
                cell.BackColor = setColor(colorLine.getColorNightByColum("Color01H", stockingPosition, planid));
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.h02.ToString();
                cell.BackColor = setColor(colorLine.getColorNightByColum("Color02H", stockingPosition, planid));
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.h03.ToString();
                cell.BackColor = setColor(colorLine.getColorNightByColum("Color03H", stockingPosition, planid));
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.h04.ToString();
                cell.BackColor = setColor(colorLine.getColorNightByColum("Color04H", stockingPosition, planid));
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.h05.ToString();
                cell.BackColor = setColor(colorLine.getColorNightByColum("Color05H", stockingPosition, planid));
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = lineStocking.h06.ToString();
                cell.BackColor = setColor(colorLine.getColorNightByColum("Color06H", stockingPosition, planid));
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
                if (input_BLL.InputNight_CheckRSbyLine(line, planid))
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
                        color = colorLine.getColorNightByColum("Color19H", line, planid);
                        e.Row.Cells[11].BackColor = setColor(color);
                        total19 += common.ConvertInt(e.Row.Cells[11].Text);
                    }
                    if (!e.Row.Cells[12].Text.Equals(""))
                    {
                        color = colorLine.getColorNightByColum("Color20H", line, planid);
                        e.Row.Cells[12].BackColor = setColor(color);
                        total20 += common.ConvertInt(e.Row.Cells[12].Text);
                    }
                    if (!e.Row.Cells[13].Text.Equals(""))
                    {
                        color = colorLine.getColorNightByColum("Color21H", line, planid);
                        e.Row.Cells[13].BackColor = setColor(color);
                        total21 += common.ConvertInt(e.Row.Cells[13].Text);
                    }
                    if (!e.Row.Cells[14].Text.Equals(""))
                    {
                        color = colorLine.getColorNightByColum("Color22H", line, planid);
                        e.Row.Cells[14].BackColor = setColor(color);
                        total22 += common.ConvertInt(e.Row.Cells[14].Text);
                    }
                    if (!e.Row.Cells[15].Text.Equals(""))
                    {
                        color = colorLine.getColorNightByColum("Color23H", line, planid);
                        e.Row.Cells[15].BackColor = setColor(color);
                        total23 += common.ConvertInt(e.Row.Cells[15].Text);
                    }
                    if (!e.Row.Cells[16].Text.Equals(""))
                    {
                        color = colorLine.getColorNightByColum("Color00H", line, planid);
                        e.Row.Cells[16].BackColor = setColor(color);
                        total0 += common.ConvertInt(e.Row.Cells[16].Text);
                    }
                    if (!e.Row.Cells[17].Text.Equals(""))
                    {
                        color = colorLine.getColorNightByColum("Color01H", line, planid);
                        e.Row.Cells[17].BackColor = setColor(color);
                        total1 += common.ConvertInt(e.Row.Cells[17].Text);
                    }
                    if (!e.Row.Cells[18].Text.Equals(""))
                    {
                        color = colorLine.getColorNightByColum("Color02H", line, planid);
                        e.Row.Cells[18].BackColor = setColor(color);
                        total2 += common.ConvertInt(e.Row.Cells[18].Text);
                    }
                    if (!e.Row.Cells[19].Text.Equals(""))
                    {
                        color = colorLine.getColorNightByColum("Color03H", line, planid);
                        e.Row.Cells[19].BackColor = setColor(color);
                        total3 += common.ConvertInt(e.Row.Cells[19].Text);
                    }
                    if (!e.Row.Cells[20].Text.Equals(""))
                    {
                        color = colorLine.getColorNightByColum("Color04H", line, planid);
                        e.Row.Cells[20].BackColor = setColor(color);
                        total4 += common.ConvertInt(e.Row.Cells[20].Text);
                    }
                    if (!e.Row.Cells[21].Text.Equals(""))
                    {
                        color = colorLine.getColorNightByColum("Color05H", line, planid);
                        e.Row.Cells[21].BackColor = setColor(color);
                        total5 += common.ConvertInt(e.Row.Cells[21].Text);
                    }
                    if (!e.Row.Cells[22].Text.Equals(""))
                    {
                        color = colorLine.getColorNightByColum("Color06H", line, planid);
                        e.Row.Cells[22].BackColor = setColor(color);
                        total6 += common.ConvertInt(e.Row.Cells[22].Text);
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

       
        public void loadGridView()
        {
            dt = new DataTable();
            dt = input_BLL.InputNight_GetAllLines(planid);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        private Color setColor(String strColor)
        {
            Color color = new Color();
            if (strColor.Equals("GreenYellow"))
            {
                color = Color.FromArgb(0, 204, 0); ;
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
        public void loadFooterGridView()
        {
            try
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
                GridView1.FooterRow.Cells[11].Text = total19.ToString();
                GridView1.FooterRow.Cells[12].Text = total20.ToString();
                GridView1.FooterRow.Cells[13].Text = total21.ToString();
                GridView1.FooterRow.Cells[14].Text = total22.ToString();
                GridView1.FooterRow.Cells[15].Text = total23.ToString();
                GridView1.FooterRow.Cells[16].Text = total0.ToString();
                GridView1.FooterRow.Cells[17].Text = total1.ToString();
                GridView1.FooterRow.Cells[18].Text = total2.ToString();
                GridView1.FooterRow.Cells[19].Text = total3.ToString();
                GridView1.FooterRow.Cells[20].Text = total4.ToString();
                GridView1.FooterRow.Cells[21].Text = total5.ToString();
                GridView1.FooterRow.Cells[22].Text = total6.ToString();
            }catch (NullReferenceException){
            }
            
        }

        protected void ddlShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlShift.SelectedValue.Equals("Day"))
                Response.Redirect("Default.aspx");
            else
                Response.Redirect("OutputNight.aspx");
        }

        protected void lbtnHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("History.aspx");
        }
    }
}