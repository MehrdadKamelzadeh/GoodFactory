using TooGood.Factories;
using TooGood.FileLoaders;
using TooGood.Model;

namespace TooGood.Services
{
    public class CsvFileTransformerService : IInputTransformerService
    {
        private readonly ICsvFileLoaderFactory _csvFileLoaderFactory;

        public CsvFileTransformerService(ICsvFileLoaderFactory csvFileLoaderFactory)
        {
            _csvFileLoaderFactory = csvFileLoaderFactory;
        }

        public StandardAccount TransformToStandard(string path, CsvFileFormat csvFileFormat)
        {
            var fileLoader = _csvFileLoaderFactory.GetCsvFileLoader(csvFileFormat);
            fileLoader.ReadFile(path);
            var transformed = fileLoader.Transform();
            return transformed;
        }


    }
}