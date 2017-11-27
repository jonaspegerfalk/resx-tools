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
        public void ReadFromString_ShouldReadAllResources()
        {
            var resources = LanguageResource.ReadFromResourceFile(@"..\..\TestResources\ResourceWithOneString.resx");
            var resourceKeys = resources.ResourceKeys.ToList();
            Assert.Single(resourceKeys);
            Assert.Equal("String1", resourceKeys[0]);
        }


    }
}
