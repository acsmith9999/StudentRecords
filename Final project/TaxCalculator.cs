using System;
using System.Collections.Generic;
using System.Text;

namespace Final_project
{
    /// <summary>
    /// class contains methods forcalculating tax based on class of employee
    /// </summary>
    public class TaxCalculator
    {
        /// <summary>
        /// method to calculate tax for residents, returns double
        /// </summary>
        /// <param name="gross"></param>
        /// <returns></returns>
        public static double CalculateResidentialTax(double gross)
        {
            if (gross > -1 && gross <= 72)
            {
                return Math.Round((gross * 0.19 - 0.19),2);
            }
            else if (gross > 72 && gross <= 361)
            {
                return Math.Round((gross * 0.2342 - 3.213),2);
            }
            else if (gross > 361 && gross <= 932)
            {
                return Math.Round((gross * 0.3477 - 44.2476),2);
            }
            else if (gross > 932 && gross <= 1380)
            {
                return Math.Round((gross * 0.345 - 41.7311),2);
            }
            else if (gross > 1380 && gross <= 3111)
            {
                return Math.Round((gross * 0.39 - 103.8657),2);
            }
            else if (gross > 3111 && gross <= 999999)
            {
                return Math.Round((gross * 0.47 - 352.7888),2);
            }
            else return 0;
        }


        /// <summary>
        /// method to return tax for working holiday visa, returns double
        /// </summary>
        /// <param name="gross"></param>
        /// <param name="yearToDate"></param>
        /// <returns></returns>
        public static double CalculateWorkingHolidayTax(double gross, double yearToDate)
        {
            double TotalGross = gross + yearToDate;
            if (TotalGross > -1 && TotalGross <= 37000)
            {
                return Math.Round((gross * 0.15),2);
            }
            else if (TotalGross > 37000 && TotalGross <= 90000)
            {
                return Math.Round((gross * 0.32),2);
            }
            else if (TotalGross > 90000 && TotalGross <= 180000)
            {
                return Math.Round((gross * 0.37),2);
            }
            else if (TotalGross > 180000 && TotalGross <= 9999999)
            {
                return Math.Round((gross * 0.45),2);
            }
            else return 0;
        }

    }
}
