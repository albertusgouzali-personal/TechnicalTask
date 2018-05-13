using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ErmPowerTask.Helper;
using ErmPowerTask.Interface;
using ErmPowerTask.Model;
using FileHelpers;

namespace ErmPowerTask.Service
{
    public class FileProcessor : IFileProcessor
    {
        public string ProcessFile(string filePath, FilesConfig fileConfig)
        {
            StringBuilder sb = new StringBuilder();
            var fileName = Path.GetFileName(filePath);
            int totalReportedInFile = 0;

            switch (fileConfig.FileType)
            {
                case "TOUFile":
                    var touEngine = new FileHelperEngine<TOUFile>();
                    var touRecords = touEngine.ReadFile(filePath);
                    var dataTypeInFile = touRecords.Select(tou => tou.DataType).Distinct();
                    foreach (var dataType in dataTypeInFile)
                    {
                        var matchingrecords = touRecords.Where(tou => tou.DataType == dataType && tou.Energy != null)
                            .ToList();
                        var recordsToCalculate = new List<Records>();

                        foreach (var record in matchingrecords)
                        {
                            recordsToCalculate.Add(new Records(record.Energy.Value, record.DateTime));
                        }

                        sb.Append(ReportOutlier(recordsToCalculate, fileName,
                            fileConfig.DevianceThresholdPercentage,
                            ref totalReportedInFile));
                    }

                    break;

                case "LPFile":
                    var lpEngine = new FileHelperEngine<LPFile>();
                    var lpRecords = lpEngine.ReadFile(filePath);
                    var lpdataTypeInFile = lpRecords.Select(lp => lp.DataType).Distinct();

                    foreach (var dataType in lpdataTypeInFile)
                    {
                        var matchingrecords = lpRecords.Where(lp => lp.DataType == dataType && lp.DataValue != null)
                            .ToList();
                        var recordsToCalculate = new List<Records>();
                        foreach (var record in matchingrecords)
                        {
                            recordsToCalculate.Add(new Records(record.DataValue.Value, record.DateTime));
                        }

                        sb.Append(ReportOutlier(recordsToCalculate, fileName,
                            fileConfig.DevianceThresholdPercentage,
                            ref totalReportedInFile));
                    }

                    break;

                default:
                    throw new NotImplementedException($"{fileConfig.FileType} File Type has not been implemented");
            }

            if (totalReportedInFile > 0)
            {
                sb.AppendLine($"Total Reported in File {totalReportedInFile}");
            }

            return sb.ToString();
        }

        public StringBuilder ReportOutlier(List<Records> recordsToCalculate, string fileName, decimal threshold, ref int totalReportedInFile)
        {
            StringBuilder sb = new StringBuilder();
            decimal[] values = new decimal[recordsToCalculate.Count];
            int index = 0;

            foreach (var record in recordsToCalculate)
            {
                values[index] = record.Value;
                index++;
            }

            decimal median = values.Median();
            var lowerlimit = median.LowerLimit(threshold);
            var upperlimit = median.UpperLimit(threshold);

            var recordToBeReported = recordsToCalculate.Where(rec => rec.Value > upperlimit || rec.Value < lowerlimit);

            foreach (var outlier in recordToBeReported)
            {
                sb.AppendLine($"{fileName} {outlier.Datetime} {outlier.Value} {median}");
                totalReportedInFile++;
            }

            return sb;
        }
    }
}
