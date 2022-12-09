using System;
using System.Collections.Generic;
using System.Text;

namespace Final_project
{
    /// <summary>
    /// parent class containing properties to store hours and rates, calculate gross, net and tax; constructor for each payRecord; method to write details to console
    /// </summary>
    public abstract class PayRecord
    {
        /// <summary>
        /// array to store hours for each line in csv file
        /// </summary>
        protected double[] _hours;
        /// <summary>
        /// array to store rates for each line in csv file
        /// </summary>
        protected double[] _rates;

        /// <summary>
        /// property Id read from csv file
        /// </summary>
        public int Id
        {
            get;
            private set;
        }

        /// <summary>
        /// property of PayRecord parent class, calculates gross earnings from parallel arrays _hours and _rates
        /// </summary>
        public double Gross
        {
            get
            {
                double calculatedGross = 0;
                for (int i=0; i<_hours.Length; i++)
                {
                    calculatedGross += _hours[i] * _rates[i];
                }

                return Math.Round(calculatedGross,2);
            }
        }

        
        /// <summary>
        /// property of PayRecord parent class, calculates net earnings
        /// </summary>
        public double Net
        {
            get
            {
                double calculateNet;
                calculateNet = Gross - Tax;
                return Math.Round(calculateNet,2);
            }
        }

        /// <summary>
        /// property tax, value is calculated from TaxCalculator class based on type of pay record (resident or whv)
        /// </summary>
        public virtual double Tax
        {
            get;
        }

        /// <summary>
        /// constructor for PayRecord accepting id, hours, rates
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hours"></param>
        /// <param name="rates"></param>
        public PayRecord(int id, double[] hours, double[] rates)
        {
            Id = id;
            _hours = hours;
            _rates = rates;
        }

        /// <summary>
        /// method to write calculated amounts to console
        /// </summary>
        /// <returns></returns>
        public virtual string GetDetails()
        {
            string details = "";
            details += "Employee ID: " + Id + "\n";
            details += "GROSS:\t $" + Gross.ToString("N") + "\n";
            details += "NET:\t $" + Net.ToString("N") + "\n";
            details += "TAX:\t $" + Tax.ToString("N") + "\n";

            return details;
        }

    }
}
