using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using TooGood.Factories;
using TooGood.FileLoaders;
using TooGood.Services;

namespace TooGood
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = Register();
            var inputTransformerService = serviceProvider.GetService<IInputTransformerService>();

            Console.WriteLine("What is the FORMAT of the CSV? Type 1 or 2 ");
            var format = Console.ReadLine();

            Console.WriteLine("What is the PATH of the CSV?");
            var path = Console.ReadLine();

            inputTransformerService.TransformToStandard(path, (CsvFileFormat)int.Parse(format));
        }

        private static ServiceProvider Register()
        {
            var collection = new ServiceCollection();

            var csvFormats = new Dictionary<CsvFileFormat, ICsvFileLoader>();
            csvFormats.Add(CsvFileFormat.Format1, new CsvFormatOne());
            csvFormats.Add(CsvFileFormat.Format2, new CsvFormatTwo());
            var csvFileLoaderFactoryObj = new CsvFileLoaderFactory(csvFormats);

            collection.AddSingleton<ICsvFileLoaderFactory>(csvFileLoaderFactoryObj);

            collection.AddScoped<IInputTransformerService, CsvFileTransformerService>();

            var serviceProvider = collection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
