using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResxTools
{
    class Program
    {
        static void Main(string[] args)
        {

            var languages = new List<string>() { "ar", "da-DK", "de", "el-GR", "es",  "fr", "he-IL", "hi", "it", "ja-JP", "ko-KR",  "pl-PL", "Pt", "ru-RU", "zh-Hans"};

            if (args.Length == 0)
            {
                Console.WriteLine($"Usage:");
                Console.WriteLine($" {System.AppDomain.CurrentDomain.FriendlyName} resorucefilename");
                return;
            }
            string filename = args[0];

            string fullFileName = Path.Combine(Directory.GetCurrentDirectory(), filename);
            var resources = LanguageResource.ReadFromResourceFile(fullFileName);

            var outputFolder = Path.GetDirectoryName(fullFileName);
            foreach (var lang in languages)
            {
                Console.Write($"Translating to {lang} ");
                var outputStream = new FileStream(Path.Combine(outputFolder, $"LanguageResource.{lang}.resx"), FileMode.OpenOrCreate, FileAccess.Write);

                TranslationService translationService = TranslationService.CreateTranslationService(lang.Substring(0,2));
                ResourceGenerator
                    .CreateGenerator(resources.Resources)
                    //.MapValues(data => TextGenerator.Generate(data.MaxLength))
                    .MapValues(data => translationService.TranslateText(data.Value))
                    .WriteToStream(outputStream);
                Console.WriteLine($"");
            }

            Console.WriteLine($"Resources written to {outputFolder}");
            Console.ReadKey();

        }
    }
}
