using System.IO;
using Microsoft.Extensions.Configuration;

namespace ErmPowerTask.Helper
{
    public static class ConfigHelper
    {
        public static IConfiguration LoadConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);

            IConfigurationRoot configuration = builder.Build();

            return configuration;
        }
    }
}
