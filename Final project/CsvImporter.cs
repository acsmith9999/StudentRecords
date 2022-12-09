using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project
{
    /// <summary>
    /// class contains methods to read csv and store data in list based on number of columns
    /// </summary>
    public class CsvImporter
    {
        /// <summary>
        /// method to read csv file line by line, compiles data based on ID number, returns list
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static List<PayRecord> ImportPayRecords(string file)
        {
            List<PayRecord> payRecords = new List<PayRecord>();

            string line;

            List<double> hours = new List<double>();
            List<double> rates = new List<double>();

            string visa = "";
            string yearToDate = "";

            string[] payRecordLine;

            int currentId;

            int previousId = -1;


            StreamReader inputFile = new StreamReader(file);

            line = inputFile.ReadLine(); // the first line of data

            line = inputFile.ReadLine(); //the second line of data

            while (line != null)
            {
                //do something with the data inside the line

                payRecordLine = line.Split(',');

                currentId = int.Parse(payRecordLine[0]);

                if (previousId != currentId && previousId != -1)
                {
                    //Add payRecords.Add

                    payRecords.Add(CreatePayRecord(previousId, hours.ToArray(), rates.ToArray(), visa, yearToDate));
                    hours.Clear();
                    rates.Clear();

                    previousId = int.Parse(payRecordLine[0]);
                    
                }

                //for first employee
                if (previousId == -1)
                {
                    previousId = int.Parse(payRecordLine[0]);
                }

                hours.Add(double.Parse(payRecordLine[1]));
                rates.Add(double.Parse(payRecordLine[2]));

                visa = payRecordLine[3];

                if (visa != "")
                {
                    yearToDate = payRecordLine[4];
                }

                line = inputFile.ReadLine();
            }

            //this is for creating the last employee record
            if (previousId != -1)
            {
                payRecords.Add(CreatePayRecord(previousId, hours.ToArray(), rates.ToArray(), visa, yearToDate));
            }

            return payRecords;

        }

        /// <summary>
        /// method to create object based on class of employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hours"></param>
        /// <param name="rates"></param>
        /// <param name="visa"></param>
        /// <param name="yearToDate"></param>
        /// <returns></returns>
        public static PayRecord CreatePayRecord(int id, double[] hours, double[] rates, string visa, string yearToDate)
        {

            if(visa == "" || visa == null)
            {
                ResidentPayRecord residentRecord = new ResidentPayRecord(id, hours, rates);
                return residentRecord;
            }

            else
            {
                WorkingHolidayPayRecord workingHolidayRecord = new WorkingHolidayPayRecord(id, hours, rates, Convert.ToInt32(visa), Convert.ToInt32(yearToDate));
                return workingHolidayRecord;
            }
        }
    }
}
