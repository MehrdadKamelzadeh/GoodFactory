using TooGood.FileLoaders;

namespace TooGood.Factories
{
    public interface ICsvFileLoaderFactory
    {
        ICsvFileLoader GetCsvFileLoader(CsvFileFormat csvFileFormat);
    }
}