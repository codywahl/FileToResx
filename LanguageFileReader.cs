using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileToResx
{
    public class LanguageFileReader
    {
        private const int ItemsInRow = 3;
        private const int KeyIndex = 0;
        private const int ValueIndex = 2;

        public Dictionary<string, string> ReadFile(string fileLocation)
        {
            if (!File.Exists(fileLocation))
            {
                throw new InvalidOperationException($"File did not exist at location: {fileLocation}");
            }

            var csvDict = new Dictionary<string, string>();

            using (var reader = new StreamReader(fileLocation, System.Text.Encoding.UTF8))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        var values = line.Split('\t');

                        if (values.Count() != ItemsInRow)
                        {
                            throw new InvalidOperationException($"FILE READER: Should have {ItemsInRow} items per line and did not. Count: {values.Count()}");
                        }

                        csvDict.Add(values[KeyIndex], values[ValueIndex]);
                    }
                }
            }

            return csvDict;
        }
    }
}