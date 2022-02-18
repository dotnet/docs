using Xunit;
using static LinqSamples.Test.Shared;

namespace LinqSamples.Test;

public class IndexTest
{
    [Fact]
    public void IntroTest()
    {
        var sw = InitTest();

        Index.Intro();
        Assert.Equal("97 92 81 ", sw.ToString());
    }
}
