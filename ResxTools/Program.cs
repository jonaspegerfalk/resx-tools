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
            var a = Directory.GetCurrentDirectory();
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
            var outputStream = new FileStream(Path.Combine(outputFolder, @"output.resx"), FileMode.OpenOrCreate, FileAccess.Write);

            ResourceGenerator
                .CreateGenerator(resources.Resources)
                .MapValues(data => TextGenerator.Generate(data.MaxLength))
                .WriteToStream(outputStream);

            Console.WriteLine($"Resources written to {outputFolder}");
            Console.ReadKey();

        }
    }
}
