using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Entity;
using System.Data;
using System.Data.SqlClient;
namespace BLL
{
    public class LineInput_BLL_base
    {
        LineInput_DAL_base obj = new LineInput_DAL_base();

        #region LineInput By Day Select All
        public DataTable LineDaySelectAll(int planid)
        {
            return obj.LineInputSelectAll(planid);
        }
        #endregion

        #region Line Day Select by Line
        public LineInputDay LineDayByLine(int linename,int planid)
        {
            /*
            LineInputDay objLine = new LineInputDay();
            DataTable dt = new DataTable(); 
            dt = obj.LineInputSelectByLine(line);
            foreach (DataRow dr in dt.Rows)
            {
                objLine.line = Int32.Parse(dr["Line"].ToString());
                objLine.model = dr["Model"].ToString();
                objLine.rs = Int32.Parse(dr["RS"].ToString());
                objLine.planed_woker = Int32.Parse(dr["Planed_Worker"].ToString());
                objLine.actual_woker = Int32.Parse(dr["Actual_Worker"].ToString());
                objLine.plan = Int32.Parse(dr["Plan"].ToString());
                objLine.tact_time = float.Parse(dr["Tact_Time"].ToString());
                objLine.total_min = Int32.Parse(dr["Total_Minute"].ToString());
                objLine.from1 = dr["From1"].ToString();
                objLine.to1 = dr["To1"].ToString();
                objLine.from2 = dr["From2"].ToString();
                objLine.to2 = dr["To2"].ToString();
                objLine.from3 = dr["From3"].ToString();
                objLine.to3 = dr["To3"].ToString();
                objLine.from4 = dr["From4"].ToString();
                objLine.to4 = dr["To4"].ToString();
                objLine.from5 = dr["From5"].ToString();
                objLine.to5 = dr["To5"].ToString();
                objLine.from6 = dr["From6"].ToString();
                objLine.to6 = dr["To6"].ToString();
            }
            return objLine;
             */
            return obj.LineInputSelectByLine(linename,planid);
        }
        #endregion

        #region Line Day Insert
        public bool LineDayInsert(LineInputDay line)
        {
            return obj.LineInputInsert(line);
        }
        #endregion

        #region Line Day Update
        public bool LineDayUpdate(LineInputDay line)
        {
            return obj.LineInputUpdate(line);
        }
        #endregion

        #region Line Day Delete
        public bool LineDayDelete(int line)
        {
            return obj.LineInputDelete(line);
        }
        #endregion

    }
}
