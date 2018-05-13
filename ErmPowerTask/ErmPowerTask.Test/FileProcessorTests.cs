using System;
using System.Collections.Generic;
using ErmPowerTask.Model;
using ErmPowerTask.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErmPowerTask.Test
{
    [TestClass]
    public class FileProcessorTests
    {
        [TestMethod]
        public void ReportOutlier_7Records_50percentthreshold_2Outlier_Valid()
        {
            var recordsToCalculate = new List<Records>
            {
                new Records(10, new DateTime(2018,05,11,09,00,00)),
                new Records(20, new DateTime(2018,05,11,09,30,00)),
                new Records(30, new DateTime(2018,05,11,10,00,00)),
                new Records(40, new DateTime(2018,05,11,10,30,00)),
                new Records(50, new DateTime(2018,05,11,11,00,00)),
                new Records(60, new DateTime(2018,05,11,11,30,00)),
                new Records(70, new DateTime(2018,05,11,12,00,00))
            };
            string fileName = "TestFile.csv";
            int totalReportedInFile = 0;
            FileProcessor processor = new FileProcessor();
            var sb = processor.ReportOutlier(recordsToCalculate, fileName, 50, ref totalReportedInFile);
            var hoho = sb.ToString();
            var exceptedOutput = "TestFile.csv 11/05/2018 9:00:00 AM 10 40\r\nTestFile.csv 11/05/2018 12:00:00 PM 70 40\r\n";
            Assert.AreEqual(exceptedOutput, sb.ToString());
            Assert.AreEqual(2, totalReportedInFile);

        }

    }
}
