using TooGood.FileLoaders;
using TooGood.Model;

namespace TooGood.Services
{
    public interface IInputTransformerService
    {
        StandardAccount TransformToStandard(string path, CsvFileFormat csvFileFormat);
    }
}