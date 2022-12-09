using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Threading.Tasks;
using System.Linq;

namespace Final_project
{
    /// <summary>
    /// class contains method for writing to csv and console
    /// </summary>
    public class PayRecordWriter
    {
        /// <summary>
        /// static method for writing calculated pay records to csv file and optionally console
        /// </summary>
        /// <param name="file"></param>
        /// <param name="records"></param>
        /// <param name="writeToConsole"></param>
        public static void Write(string file, List<PayRecord> records, bool writeToConsole)
        {
            using (var writer = new StreamWriter(file))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(records);

                    csv.Dispose();
                }
            }

            if (writeToConsole)
            {
                foreach (PayRecord record in records)
                {
                    Console.WriteLine((record.GetDetails()));
                }
            }
        }
    }
}
