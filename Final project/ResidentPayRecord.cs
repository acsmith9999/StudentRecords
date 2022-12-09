using System;
using System.Collections.Generic;
using System.Text;

namespace Final_project
{
    /// <summary>
    /// child class from PayRecord, contains property Tax to calculate total tax paid
    /// </summary>
    public class ResidentPayRecord : PayRecord
    {
        /// <summary>
        /// inherits from PayRecord, overrides abstract property Tax an calls appropriate method from TaxCalculator
        /// </summary>
        public override double Tax
        {
            get
            {
                double tax;

                tax = TaxCalculator.CalculateResidentialTax(Gross);

                return tax;
            }
        }

        /// <summary>
        /// constructor calls base constructor, id, hours, rates
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hours"></param>
        /// <param name="rates"></param>
        public ResidentPayRecord(int id, double[] hours, double[] rates): base(id, hours, rates)
        {

        }
    }
}
