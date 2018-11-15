using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class LineColorDay_BLL_base
    {
        LineColorDay_DAL_base lineColor = new LineColorDay_DAL_base();
        public bool LineColor_Insert(int line,int planid)
        {
            return lineColor.LineInputInsert(line, planid);
        }
    }
}
