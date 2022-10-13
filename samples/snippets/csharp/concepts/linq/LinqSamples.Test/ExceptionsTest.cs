using Xunit;
using static LinqSamples.Test.Shared;

namespace LinqSamples.Test;

public class ExceptionsTest
{
    [Fact]
    public void Exceptions2Test()
    {
        var sw = InitTest();

        Exceptions.Exceptions2();
        Assert.Equal(
@"Processing C:\newFolder\fileA.txt
Processing C:\newFolder\fileB.txt
Operation is not valid due to the current state of the object.
", sw.ToString());
    }
}
