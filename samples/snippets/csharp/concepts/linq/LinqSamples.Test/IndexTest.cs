using System;
using System.IO;
using Xunit;

namespace LinqSamples.Test
{
    public class IndexTest
    {
        StringWriter sw = new StringWriter();
        public IndexTest() => Console.SetOut(sw);

        [Fact]
        public void IntroTest()
        {
            Index.Intro();
            Assert.Equal("97 92 81 ", sw.ToString());
        }
    }
}
