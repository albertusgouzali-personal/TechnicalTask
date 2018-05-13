using System;
using System.IO;
using ErmPowerTask.Helper;
using ErmPowerTask.Model;
using ErmPowerTask.Service;
using Microsoft.Extensions.Configuration;

namespace ErmPowerTask
{
    public class Program
    {
        private readonly IConfiguration _config;

        public Program()
        {
            _config = ConfigHelper.LoadConfig();
        }

        public Program(IConfiguration config)
        {
            _config = config;
        }

        public static void Main(string[] args)
        {
            Program p = new Program();

            p.Run();

            Console.WriteLine();

            Console.ReadLine();
        }

        public void Run()
        {
            var files = _config.Get<FilesConfigs>();

            try
            {
                foreach (var fileConfig in files.FilesConfig)
                {
                    if (Directory.Exists(fileConfig.Location))
                    {
                        var fileList = Directory.GetFiles(fileConfig.Location, $"{fileConfig.Prefix}*.csv");

                        foreach (var filePath in fileList)
                        {
                            FileProcessor processor = new FileProcessor();
                            Console.WriteLine(processor.ProcessFile(filePath, fileConfig));
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Directory {fileConfig.Location} does not exists");
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
