using System;
using Xunit;
using ResxTools;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace UnitTests
{
    public class ResourceGeneratorUnitTests
    {
        [Fact]
        public void WriteToString_ShouldGenerateResourceFile()
        {
            var resources = new List<ResourceData>() {
                new ResourceData() { Key = "KeyString1", Value = "Value1", Comment = "MaxLength=20" },
                new ResourceData() { Key = "KeyString2", Value = "Value2", Comment = "MaxLength=20" }};

            var generator = ResourceGenerator.CreateGenerator(resources);
            var generatedResourceData = generator.WriteToString();

            Assert.NotEmpty(generatedResourceData);
            Assert.Contains("KeyString1", generatedResourceData);
            Assert.Contains("MaxLength", generatedResourceData);
        }


        [Fact]
        public void WriteToStream_ShouldGenerateResourceFile()
        {
            var resources = new List<ResourceData>() {
                new ResourceData() { Key = "KeyString1", Value = "Value1", Comment = "MaxLength=20" },
                new ResourceData() { Key = "KeyString2", Value = "Value2", Comment = "MaxLength=20" }};

            var stream = new MemoryStream();
            ResourceGenerator.CreateGenerator(resources).WriteToStream(stream);

            var sr = new StreamReader(stream);
            var s = sr.ReadToEnd();
            Assert.NotEmpty(s);
            Assert.Contains("KeyString1", s);
            Assert.Contains("MaxLength", s);
        }


    }
}
