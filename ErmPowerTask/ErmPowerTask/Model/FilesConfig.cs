using System.Collections.Generic;

namespace ErmPowerTask.Model
{
    public class FilesConfigs
    {
        public List<FilesConfig> FilesConfig { get; set; }
    }

    public class FilesConfig
    {
        public string Prefix { get; set; }
        public string FileType { get; set; }
        public string Location { get; set; }
        public decimal DevianceThresholdPercentage { get; set; }
    }
}
