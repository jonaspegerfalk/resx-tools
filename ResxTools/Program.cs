using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResxTools
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine($"Usage:");
                Console.WriteLine($" {System.AppDomain.CurrentDomain.FriendlyName} resorucefilename");
                return;
            }
            string filename = args[0];
            var resources = LanguageResource.ReadFromResourceFile(filename);

            resources.ResourceKeys.ToList().ForEach(r => Console.WriteLine(r));


            Console.ReadKey();

        }
    }
}
