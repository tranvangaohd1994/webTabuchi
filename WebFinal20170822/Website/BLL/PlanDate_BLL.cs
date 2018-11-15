using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Entity;

namespace BLL
{
    public class PlanDate_BLL
    {
        PlanDate_DAL planDate_DAL = new PlanDate_DAL();

        #region findPlanIdByDateTime
        public int findPlanIdByDateTime(DateTime date)
        {
            return planDate_DAL.PlanDate_findIdByDateTime(date);
        }
        #endregion

        #region PlanDate_createNewPlan
        public bool PlanDate_createNewPlan(DateTime date)
        {
            return planDate_DAL.PlanDate_createNewPlan(date);
        }
        #endregion

        public int findIdByDateTimeNextDay(DateTime date)
        {
            return planDate_DAL.PlanDate_findIdByDateTimeNextDay(date);
        }
    }
}
