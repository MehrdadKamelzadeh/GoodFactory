using System.Collections.Generic;
using TooGood.FileLoaders;

namespace TooGood.Factories
{
    public class CsvFileLoaderFactory : ICsvFileLoaderFactory
    {
        private readonly IDictionary<CsvFileFormat, ICsvFileLoader> _csvFileTypes;

        public CsvFileLoaderFactory(IDictionary<CsvFileFormat, ICsvFileLoader> csvFileTypes)
        {
            _csvFileTypes = csvFileTypes;
        }
        public ICsvFileLoader GetCsvFileLoader(CsvFileFormat csvFileFormat)
        {
            return this._csvFileTypes[csvFileFormat];
        }
    }
}