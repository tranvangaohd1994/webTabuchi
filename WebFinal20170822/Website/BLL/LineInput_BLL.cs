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
    public class LineInput_BLL
    {
        LineInput_DAL inputDAL = new LineInput_DAL();

        #region LineDay_UpdateChangeModel
        public bool LineDay_UpdateChangeModel(int line, string value)
        {
            return inputDAL.LineDay_UpdateChangeModel(line,value);
        }
        #endregion

        #region LineDay_UpdateRS
        public bool LineDay_UpdateRS(int line, bool value)
        {
            return inputDAL.LineDay_UpdateRS(line, value);
        }
        #endregion

        public DataTable SelectInputDayByRS()
        {
            return inputDAL.LineInputSelectByRS();
        }

        public bool InputDay_CheckRSbyLine(int line,int planid)
        {
            return inputDAL.LineInput_GetRSByLine(line,planid);
        }

        public DataTable InputDay_GetAllLines(int planid)
        {
            return inputDAL.LineInput_GetAllLines(planid);
        }

        public LineInputDay InputDay_GetStocking(int planId)
        {
            return inputDAL.LineInput_GetStocking(planId);
        }

        public DataTable InputDay_ExportExcel(int planid)
        {
            return inputDAL.LineInput_ToExportExcel(planid);
        }

        public bool LineInput_UpdateChangeActual(int line, bool isChange, int planid)
        {
            return inputDAL.LineInput_ChangeActual(line, isChange, planid);
        }
    }
}
