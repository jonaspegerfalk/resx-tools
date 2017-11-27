using System;
using Xunit;
using ResxTools;
using System.IO;
using System.Linq;

namespace UnitTests
{
    public class LanguageResourceTests
    {
        [Fact]
        public void ReadResources_ShouldReadAllResources()
        {
            var resources = LanguageResource.ReadFromResourceFile(@"..\..\TestResources\ResourceWithOneString.resx");
            var resourceKeys = resources.ResourceKeys.ToList();
            Assert.Single(resourceKeys);
            Assert.Equal("String1", resourceKeys[0]);
        }

        [Fact]
        public void ReadResources_ShouldGetAllData()
        {
            var resources = LanguageResource.ReadFromResourceFile(@"..\..\TestResources\ResourceWithOneString.resx");
            var firstResource = resources.Resources.First();

            Assert.Equal("String1", firstResource.Key);
            Assert.Equal("Value", firstResource.Value);
            Assert.Equal(10, firstResource.MaxLength);
            Assert.Equal("MaxLength=10", firstResource.Comment);



        }

    }
}
