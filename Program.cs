using System;
using System.IO;

namespace FileToResx
{
    public class Program
    {
        private const string TempPath = @"C:\temp\Translations\";
        private const string FileType = @".resx";

        private static void Main()
        {
            var languageFileReader = new LanguageFileReader();
            var resxBuilder = new ResxBuilder();

            try
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                Console.Write("Csv location: ");
                var languageFileLocation = Console.ReadLine();

                Console.Write("Resx file name:");
                var resxFileName = Console.ReadLine();

                if (!resxFileName.EndsWith(FileType))
                {
                    resxFileName += FileType;
                }

                var languageDictionary = languageFileReader.ReadFile(languageFileLocation);
                var newFilePath = $"{TempPath}{resxFileName}";

                resxBuilder.BuildResx(languageDictionary, newFilePath);

                Console.WriteLine(File.Exists(newFilePath)
                    ? "New resx file was created!"
                    : "New resx file was not created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadKey();
        }
    }
}