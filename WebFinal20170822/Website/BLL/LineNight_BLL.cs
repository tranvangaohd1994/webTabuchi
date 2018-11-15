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
    public class LineNight_BLL
    {
        LineInputNight_DAL inputDAL = new LineInputNight_DAL();

        #region LineNight_UpdateChangeModel
        public bool LineNight_UpdateChangeModel(int line, string value)
        {
            return inputDAL.LineNight_UpdateChangeModel(line, value);
        }
        #endregion

        #region LineNight_UpdateRS
        public bool LineNight_UpdateRS(int line, bool value)
        {
            return inputDAL.LineNight_UpdateRS(line, value);
        }
        #endregion

        public DataTable LineNightSelectByRS()
        {
            return inputDAL.LineInputSelectByRS();
        }

        public bool InputNight_CheckRSbyLine(int line,int planId)
        {
            return inputDAL.LineNight_GetRSByLine(line,planId);
        }

        public DataTable InputNight_GetAllLines(int planid)
        {
            return inputDAL.LineNight_GetAllLines(planid);
        }

        public LineInputNight InputNight_GetStocking(int planid)
        {
            return inputDAL.LineNight_GetStocking(planid);
        }

        public DataTable InputNight_ExportExcel(int planid)
        {
            return inputDAL.LineInputNight_ToExportExcel(planid);
        }

        public bool LineInputNight_ChangeActual(int line,bool value,int planid)
        {
            return inputDAL.LineInputNight_ChangeActual(line, value, planid);
        }
    }
}
