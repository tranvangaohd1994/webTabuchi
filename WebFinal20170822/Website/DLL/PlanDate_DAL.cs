using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class PlanDate_DAL : Connect
    {
        public int PlanDate_findIdByDateTime(DateTime date)
        {
            DataTable result = new DataTable();
            int planId = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("SELECT PlanId FROM  PlanDate Where PlanName = @PlanName", openConnection()))
                {
                    command.Parameters.Add(new SqlParameter("@PlanName", date.Date));
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(result);
                    
                }
            }
            catch (System.Exception) { 
            }
            this.closeConnection();
            if (result.Rows.Count > 0)
            {
                planId = int.Parse(result.Rows[0][0].ToString());
            }
            return planId;
        }

        public int PlanDate_findIdByDateTimeNextDay(DateTime date)
        {
            DataTable result = new DataTable();
            int planId = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("SELECT PlanId FROM  PlanDate Where PlanName = @PlanName", openConnection()))
                {
                    command.Parameters.Add(new SqlParameter("@PlanName", date.Date));
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(result);
                    this.closeConnection();
                    if (result.Rows.Count > 0)
                    {
                        planId = int.Parse(result.Rows[0][0].ToString());
                    }

                    if (date.Hour < 7)
                    {
                        date = date.AddDays(-1);
                        date = date.Date;
                        PlanDate_DAL plandate = new PlanDate_DAL();
                        planId = plandate.PlanDate_findIdByDateTime(date);
                    }
                    
                }
            }
            catch (System.Exception) { 
            }
            this.closeConnection();
            return planId;
        }

        public bool PlanDate_createNewPlan(DateTime date)
        {
            int isNull = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("Insert into PlanDate(PlanName) values (@PlanName) ", openConnection()))
                {
                    command.Parameters.Add(new SqlParameter("@PlanName", date.Date));
                    isNull = command.ExecuteNonQuery();
                    
                }
            }
            catch (System.Exception) { 
            }
            this.closeConnection();
            return isNull > 0;

        }

    }
}
