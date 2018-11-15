using DAL;
using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class LineColorNight_BLL_base
    {
        LineColorNight_DAL_base lineColor = new LineColorNight_DAL_base();
        public bool LineColor_Insert(int line, int planid)
        {
            return lineColor.LineInputNightInsert(line, planid);
        }
    }
}
