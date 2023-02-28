using Xunit;
using static LinqSamples.Test.Shared;

namespace LinqSamples.Test;

public class BasicsTest
{
    [Fact]
    public void Basics5Test()
    {
        var sw = InitTest();

        Basics.Basics5();
        Assert.Equal(
@"93
90
82
82
", sw.ToString());
    }

    [Fact]
    public void Basics18Test()
    {
        var sw = InitTest();

        Basics.Basics18();
        Assert.Equal("Svetlana Claire Sven Cesar ", sw.ToString());
    }
}
