using System.Collections.Generic;
using System.Text;
using ErmPowerTask.Model;

namespace ErmPowerTask.Interface
{
    public interface IFileProcessor
    {
        string ProcessFile(string fileName, FilesConfig fileConfig);

        StringBuilder ReportOutlier(List<Records> recordsToCalculate, string fileName, decimal threshold,
            ref int totalReportedInFile);
    }
}
