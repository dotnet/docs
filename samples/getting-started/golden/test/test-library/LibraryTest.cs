using Library;
using Xunit;

namespace TestApp
{
    public class LibraryTests
    {
        [Fact]
        public void TestThing()
        {
            Assert.Equal(42, new Thing().Get(19, 23));
        }
    }
}
