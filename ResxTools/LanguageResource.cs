using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Collections;
using System.ComponentModel.Design;

namespace ResxTools
{
    public class LanguageResource
    {
        private ResXResourceReader resXResourceReader;

        public LanguageResource(ResXResourceReader resXResourceReader)
        {
            this.resXResourceReader = resXResourceReader;
        }

        public IEnumerable<string> ResourceKeys
        {
            get
            {
                IEnumerable<DictionaryEntry> enumerator = resXResourceReader.OfType<DictionaryEntry>();
                return enumerator.Select(o => o.Key as string);
            }
        }

        public IEnumerable<ResourceData> Resources
        {
            get
            {
                IEnumerable<DictionaryEntry> enumerator = resXResourceReader.OfType<DictionaryEntry>();
                return enumerator.Select(r => {
                    ITypeResolutionService resolutionService = null;
                    var dataNode = (ResXDataNode)r.Value;
                    return new ResourceData()
                    {
                        Key = r.Key as string,
                        Value = dataNode.GetValue(resolutionService) as string,
                        Comment = dataNode.Comment as string,
                        MaxLength = ParseCommentForMaxLength(dataNode.Comment)
                    };
                });
            }
        }

        private int ParseCommentForMaxLength(string comment)
        {
            var comments = comment.Split(':');
            var maxLengthString = comments.Where(c => c.StartsWith("maxlength", StringComparison.OrdinalIgnoreCase));
            var a = maxLengthString.Select(c => c.Split('=').Skip(1).Take(1).FirstOrDefault()).FirstOrDefault();

            if (int.TryParse(a, out int maxLength))
                return maxLength;
            else return -1;

        }

        public static LanguageResource ReadFromResourceFile(string fileName)
        {
            ResXResourceReader resXResourceReader = new ResXResourceReader(fileName) { UseResXDataNodes = true };
            return new LanguageResource(resXResourceReader);
        }
    }
}
