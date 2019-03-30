using System.Collections.Generic;
using TooGood.Model;

namespace TooGood.FileLoaders
{
    public interface ICsvFileLoader
    {
        List<string> ReadFile(string path);
        StandardAccount Transform();
    }
}