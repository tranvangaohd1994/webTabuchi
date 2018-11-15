using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class LinetNight_BLL_base
    {
        LineInputNight_DAL_base obj = new LineInputNight_DAL_base();

        #region LineInput By Night Select All
        public DataTable LineNightSelectAll(int planid)
        {
            return obj.LineInputNightSelectAll(planid);
        }
        #endregion

        #region Line Night Select by Line
        public LineInputNight LineNightByLine(int line, int planid)
        {
            return obj.LineInputSelectNightByLine(line,planid);
        }
        #endregion

        #region Line Night Insert
        public bool LineNightInsert(LineInputNight line)
        {
            return obj.LineInputNightInsert(line);
        }
        #endregion

        #region Line Night Update
        public bool LineNightUpdate(LineInputNight line)
        {
            return obj.LineInputNightUpdate(line);
        }
        #endregion

        #region Line Night Delete
        public bool LineNightDelete(int line)
        {
            return obj.LineInputNightDelete(line);
        }
        #endregion
    }
}
