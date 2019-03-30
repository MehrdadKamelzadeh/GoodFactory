using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using TooGood.Model;

namespace TooGood.FileLoaders
{
    public class CsvFormatOne : ICsvFileLoader
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

            foreach (var line in lines)
            {
                var columns = line.Split(',').ToArray();

                standardAccount.AccountCode = columns[0].Split('|')[1];
                standardAccount.Name = columns[1];
                standardAccount.Type = (AccountType)(int.Parse(columns[2]));
                standardAccount.Opened = DateTime.ParseExact(columns[3], "yyyy-mm-dd", CultureInfo.InvariantCulture).ToString("yyyy-mm-dd");
                switch (columns[4])
                {
                    case "CD":
                        standardAccount.Currency = "CAD";
                        break;
                    case "US":
                        standardAccount.Currency = "USD";
                        break;
                }
            }

            return standardAccount;
        }
    }
}