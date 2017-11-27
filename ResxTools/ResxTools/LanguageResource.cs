using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Collections;

namespace ResxTools
{
    class LanguageResource
    {
        private ResXResourceReader resXResourceReader;

        public LanguageResource(ResXResourceReader resXResourceReader)
        {
            this.resXResourceReader = resXResourceReader;
        }

        public IEnumerable<string> ResourceNames
        {
            get
            {
                IEnumerable<DictionaryEntry> enumerator = resXResourceReader.OfType<DictionaryEntry>();
                return enumerator.Select(o => o.Key as string);
            }
        }

        public static LanguageResource ReadFromResourceFile(string fileName)
        {
            ResXResourceReader resXResourceReader = new ResXResourceReader(fileName) { UseResXDataNodes = true };
            return new LanguageResource(resXResourceReader);
        }
    }
}
