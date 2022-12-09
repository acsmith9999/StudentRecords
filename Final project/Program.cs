using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace Final_project
{
    class Program
    {
        /// <summary>
        /// calls method for writing records to csv and console from PayRecordWriter
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            
            List<PayRecord> records;

            string path = AppDomain.CurrentDomain.BaseDirectory;

            path = path.Replace(@"\bin\Debug\netcoreapp3.1", "");

            string filePath = path + "\\import\\employee-payroll-data.csv";

            records = CsvImporter.ImportPayRecords(filePath);

            string exportFile = (DateTime.Now.Ticks).ToString() + "-records.csv";

            string exportPath = path + "\\export\\" + exportFile;

            PayRecordWriter.Write(exportPath, records, true);

        }
    }
}
