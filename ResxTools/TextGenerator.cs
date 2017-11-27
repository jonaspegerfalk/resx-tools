using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResxTools
{
    public class TextGenerator
    {
        private static Random random = new Random();
     
        public static string Generate(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            var result = Enumerable
                .Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)])
                .ToArray();

            for (var i = 1; i< result.Length; i++)
            {
                if (random.NextDouble() < .3 && result[i-1] != ' ') result[i] = ' ';
            }
            return new String(result);
        }
    }
}
