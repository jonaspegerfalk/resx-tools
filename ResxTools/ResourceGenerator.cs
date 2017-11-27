using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ResxTools
{
    public class ResourceGenerator
    {
        private IEnumerable<ResourceData> data;

        public ResourceGenerator(IEnumerable<ResourceData> data)
        {
            this.data = data;
        }
        public static ResourceGenerator CreateGenerator(IEnumerable<ResourceData> data)
        {
            return new ResourceGenerator(data);
        }

        public string WriteToString()
        {
            MemoryStream stream = new MemoryStream();
            WriteToStream(stream);
            var streamReader = new StreamReader(stream);
            return streamReader.ReadToEnd() ;
        }

        public void WriteToStream(MemoryStream stream) {
            ResXResourceWriter writer = new ResXResourceWriter(stream);
            data.ToList().ForEach(d => writer.AddResource(new ResXDataNode(d.Key, d.Value) { Comment = d.Comment }));
            writer.Generate();
            stream.Position = 0;
        }
    }
}
