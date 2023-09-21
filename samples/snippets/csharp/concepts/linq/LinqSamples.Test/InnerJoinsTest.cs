using Xunit;
using static LinqSamples.Test.Shared;

namespace LinqSamples.Test;

public class InnerJoinsTest
{
    [Fact]
    public void BasicTest()
    {
        const string expectedOutput =
@"""Daisy"" is owned by Magnus
""Barley"" is owned by Terry
""Boots"" is owned by Terry
""Whiskers"" is owned by Charlotte
""Blue Moon"" is owned by Rui
";

        var querySyntaxResult = InnerJoins.Basic();
        Assert.Equal(expectedOutput, querySyntaxResult);

        var methodSyntaxResult = InnerJoins.BasicMethodSyntax();
        Assert.Equal(methodSyntaxResult, querySyntaxResult);
    }

    [Fact]
    public void CompositeKeyTest()
    {
        const string expectedOutput =
@"The following people are both employees and students:
Terry Adams
Vernette Price
";
        var querySyntaxResult = InnerJoins.CompositeKey();
        Assert.Equal(expectedOutput, querySyntaxResult);

        var methodSyntaxResult = InnerJoins.CompositeKeyMethodSyntax();
        Assert.Equal(methodSyntaxResult, querySyntaxResult);
    }

    [Fact]
    public void MultipleJoinTest()
    {
        const string expectedOutput =
@"The cat ""Daisy"" shares a house, and the first letter of their name, with ""Duke"".
The cat ""Whiskers"" shares a house, and the first letter of their name, with ""Wiley"".
";
        var querySyntaxResult = InnerJoins.MultipleJoin();
        Assert.Equal(expectedOutput, querySyntaxResult);

        var methodSyntaxResult = InnerJoins.MultipleJoinMethodSyntax();
        Assert.Equal(methodSyntaxResult, querySyntaxResult);
    }

    [Fact]
    public void InnerGroupJoinTest()
    {
        const string expectedOutput =
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
";
        var querySyntaxResult = InnerJoins.InnerGroupJoin();
        Assert.Equal(expectedOutput, querySyntaxResult);

        var methodSyntaxResult = InnerJoins.InnerGroupJoinMethodSyntax();
        Assert.Equal(methodSyntaxResult, querySyntaxResult);
    }
}
