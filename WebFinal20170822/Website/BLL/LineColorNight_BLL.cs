using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class LineColorNight_BLL
    {
        LineColorNight_DAL line_DAL = new LineColorNight_DAL();
        #region getColorDayByColum
        public string getColorNightByColum(string nameColum, int line, int planid)
        {
            return line_DAL.getColorByColumn(nameColum, line, planid);
        }
        #endregion
    }
}
