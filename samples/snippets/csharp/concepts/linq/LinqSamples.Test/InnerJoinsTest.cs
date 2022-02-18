using Xunit;
using static LinqSamples.Test.Shared;

namespace LinqSamples.Test;

public class InnerJoinsTest
{
    [Fact]
    public void BasicTest()
    {
        var sw = InitTest();

        InnerJoins.Basic();
        Assert.Equal(
@"""Daisy"" is owned by Magnus
""Barley"" is owned by Terry
""Boots"" is owned by Terry
""Whiskers"" is owned by Charlotte
""Blue Moon"" is owned by Rui
", sw.ToString());
    }

    [Fact]
    public void CompositeKeyTest()
    {
        var sw = InitTest();

        InnerJoins.CompositeKey();
        Assert.Equal(
@"The following people are both employees and students:
Terry Adams
Vernette Price
", sw.ToString());
    }

    [Fact]
    public void MultipleJoinTest()
    {
        var sw = InitTest();

        InnerJoins.MultipleJoin();
        Assert.Equal(
@"The cat ""Daisy"" shares a house, and the first letter of their name, with ""Duke"".
The cat ""Whiskers"" shares a house, and the first letter of their name, with ""Wiley"".
", sw.ToString());
    }

    [Fact]
    public void InnerGroupJoinTest()
    {
        var sw = InitTest();

        InnerJoins.InnerGroupJoin();
        Assert.Equal(
@"Inner join using GroupJoin():
Magnus - Daisy
Terry - Barley
Terry - Boots
Terry - Blue Moon
Charlotte - Whiskers

The equivalent operation using Join():
Magnus - Daisy
Terry - Barley
Terry - Boots
Terry - Blue Moon
Charlotte - Whiskers
", sw.ToString());
    }
}
