using System;
using System.Collections.Generic;
using System.Text;

namespace Final_project
{
    /// <summary>
    /// child class of PayRecord, contains constructor and method to write details with additional parameters
    /// </summary>
    public class WorkingHolidayPayRecord : PayRecord
    {
        /// <summary>
        /// child class requires 2 additional properties, read from csv file
        /// </summary>
        private int _visa;
        private int _yearToDate;

        /// <summary>
        /// property to read visa from csv and store it to private variable
        /// </summary>
        public int Visa
        {
            get
            {
                return _visa;
            }

            private set
            {
                _visa = value;
            }
        }

        /// <summary>
        /// property to read yearToDate from csv and store it to private variable
        /// </summary>
        public int YearToDate
        {
            get 
            {
                return (int)(_yearToDate + Gross);
            }

            private set
            {
                _yearToDate = value;
            }

        }

        /// <summary>
        /// inherits from PayRecord, overrides abstract property Tax an calls appropriate method from TaxCalculator
        /// </summary>
        public override double Tax
        {
            get
            {
                double tax;

                tax = TaxCalculator.CalculateWorkingHolidayTax(Gross, YearToDate);

                return tax;
            }
        }

        /// <summary>
        /// constructor contains additional arguments _visa and _yearToDate
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hours"></param>
        /// <param name="rates"></param>
        /// <param name="visa"></param>
        /// <param name="yearToDate"></param>
        public WorkingHolidayPayRecord(int id, double[] hours, double[] rates, int visa, int yearToDate): base(id,hours, rates)
        {
            Visa = visa;
            _yearToDate = yearToDate;
        }

        /// <summary>
        /// method to write calculated amounts to console with visa details
        /// </summary>
        /// <returns></returns>
        public override string GetDetails()
        {
            string details = base.GetDetails();

            details += "VISA:\t " + Visa.ToString("N") + "\n";
            details += "YTD:\t $" + YearToDate.ToString("N") + "\n";

            return details;
        }

    }
}
