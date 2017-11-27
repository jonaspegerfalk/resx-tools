using System;
using Xunit;
using ResxTools;
using System.IO;
using System.Linq;

namespace UnitTests
{
    public class TextGeneratorUnitTests
    {
        [Fact]
        public void GenerateText_ShouldBeCorrectLength()
        {
            string t = TextGenerator.Generate(20);
            Assert.Equal(20, t.Length);
        }


    }
}
