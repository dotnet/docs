using Xunit;
using static LinqSamples.Test.Shared;

namespace LinqSamples.Test;

public class RuntimeFilteringTest
{
    [Fact]
    public void RuntimeFiltering1Test()
    {
        var sw = InitTest();

        RuntimeFiltering.RuntimeFiltering1();
        Assert.Equal(
@"Garcia: 114
O'Donnell: 112
Omelchenko: 111
Adams: 120
Feng: 117
Garcia: 115
Tucker: 122
", sw.ToString());
    }

    [Fact]
    public void RuntimeFiltering2Test()
    {
        var sw = InitTest();

        RuntimeFiltering.RuntimeFiltering2();
        Assert.Equal(
@"The following students are at an odd year level:
Fakhouri: 116
Feng: 117
Garcia: 115
Mortensen: 113
Tucker: 119
Tucker: 122
The following students are at an even year level:
Adams: 120
Garcia: 114
Garcia: 118
O'Donnell: 112
Omelchenko: 111
Zabokritski: 121
", sw.ToString());
    }
}
