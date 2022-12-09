using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Final_project;
using NUnit.Framework;

namespace NUnitTestProject1
{

    public class Tests
    {
        List<PayRecord> records;
        [SetUp]
        public void SetUp()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            path = path.Replace(@"\bin\Debug\netcoreapp3.1", "");

            string filePath = path + "\\import\\employee-payroll-data.csv";

            records = CsvImporter.ImportPayRecords(filePath);
        }


        [Test]
        public void TestImport()
        {
            Assert.IsNotNull(records);
            Assert.IsNotEmpty(records);
            Assert.AreEqual(records.Count, 5);
        }

        [Test]
        public void TestGross()
        {
            //first employee
            double expected = Math.Round(records[0].Gross, 2);
            double actual = 652;

            Assert.AreEqual(expected, actual);

            //second employee
            expected = Math.Round(records[1].Gross, 2);
            actual = 418;

            Assert.AreEqual(expected, actual);

            //third employee
            expected = Math.Round(records[2].Gross, 2);
            actual = 2202;

            Assert.AreEqual(expected, actual);

            //fourth employee
            expected = Math.Round(records[3].Gross, 2);
            actual = 1104;

            Assert.AreEqual(expected, actual);

            //fifth employee
            expected = Math.Round(records[4].Gross, 2);
            actual = 1797.45;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestNet()
        {
            //first employee
            double expected = Math.Round(records[0].Net, 2);
            double actual = 469.55;

            Assert.AreEqual(expected, actual);

            //second employee
            expected = Math.Round(records[1].Net, 2);
            actual = 284.24;

            Assert.AreEqual(expected, actual);

            //third employee
            expected = Math.Round(records[2].Net, 2);
            actual = 1447.09;

            Assert.AreEqual(expected, actual);

            //fourth employee
            expected = Math.Round(records[3].Net, 2);
            actual = 938.4;

            Assert.AreEqual(expected, actual);

            //fifth employee
            expected = Math.Round(records[4].Net, 2);
            actual = 1200.31;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestTax()
        {
            //first employee
            double expected = Math.Round(records[0].Tax, 2);
            double actual = 182.45;

            Assert.AreEqual(expected, actual);

            //second employee
            expected = Math.Round(records[1].Tax, 2);
            actual = 133.76;

            Assert.AreEqual(expected, actual);

            //third employee
            expected = Math.Round(records[2].Tax, 2);
            actual = 754.91;

            Assert.AreEqual(expected, actual);

            //fourth employee
            expected = Math.Round(records[3].Tax, 2);
            actual = 165.6;

            Assert.AreEqual(expected, actual);

            //fifth employee
            expected = Math.Round(records[4].Tax, 2);
            actual = 597.14;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestExport()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            path = path.Replace(@"\bin\Debug\netcoreapp3.1", "");

            string exportFile = (DateTime.Now.Ticks).ToString() + "-records.csv";

            string exportPath = path + "\\export\\" + exportFile;

            PayRecordWriter.Write(exportPath, records, true);

            bool fileExists = File.Exists(exportPath);
            Assert.IsTrue(fileExists);
        }
    }
}
