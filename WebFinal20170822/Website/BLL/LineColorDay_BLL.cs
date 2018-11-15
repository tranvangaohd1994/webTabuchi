using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public class LineColorDay_BLL
    {
        LineColorDay_DAL line_DAL = new LineColorDay_DAL();
        #region getColorDayByColum
        public string getColorDayByColum(string nameColum, int line, int planid)
        {
            return line_DAL.getColorByColumn(nameColum, line, planid);
        }
        #endregion
    }
}
