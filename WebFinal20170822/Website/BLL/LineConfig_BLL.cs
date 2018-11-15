using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class LineConfig_BLL
    {
        LineConfig_DAL lineConfig = new LineConfig_DAL();

        #region getSumLine
        public int getSumLine()
        {
            return lineConfig.getSumLine();
        }
        #endregion
    }
}
