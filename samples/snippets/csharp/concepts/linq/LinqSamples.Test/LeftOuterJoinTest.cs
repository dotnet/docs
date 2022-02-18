using Xunit;
using static LinqSamples.Test.Shared;

namespace LinqSamples.Test;

public class LeftOuterJoinTest
{
    [Fact]
    public void LeftOuterJoin1Test()
    {
        var sw = InitTest();

        LeftOuterJoin.LeftOuterJoin1();
        Assert.Equal(
@"Magnus:        Daisy
Terry:         Barley
Terry:         Boots
Terry:         Blue Moon
Charlotte:     Whiskers
Arlene:        
", sw.ToString());
    }
}
