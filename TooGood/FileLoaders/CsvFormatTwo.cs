using System.Collections.Generic;
using System.IO;
using System.Linq;
using TooGood.Model;

namespace TooGood.FileLoaders
{
    public class CsvFormatTwo : ICsvFileLoader
    {
        private readonly List<string> lines = new List<string>();
        public List<string> ReadFile(string path)
        {
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    lines.Add(line);
                }
            }

            return lines;
        }

        public StandardAccount Transform()
        {
            var standardAccount = new StandardAccount();

            foreach (var line in lines.Skip(1))
            {
                var columns = line.Split(',').ToArray();

                standardAccount.Name = columns[0];
                standardAccount.Type = (AccountType)(int.Parse(columns[1]));
                switch (columns[2])
                {
                    case "C":
                        standardAccount.Currency = "CAD";
                        break;
                    case "U":
                        standardAccount.Currency = "USD";
                        break;
                }
                standardAccount.AccountCode = columns[3];
            }

            return standardAccount;
        }
    }
}