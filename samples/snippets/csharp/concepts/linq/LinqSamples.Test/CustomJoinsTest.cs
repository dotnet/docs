using Xunit;
using static LinqSamples.Test.Shared;

namespace LinqSamples.Test;

public class CustomJoinsTest
{
    [Fact]
    public void CustomJoins1Test()
    {
        var sw = InitTest();

        CustomJoins.CustomJoins1();
        Assert.Equal(
@"Cross Join Query:
1    Tea
1    Mustard
1    Pickles
1    Carrots
1    Bok Choy
1    Peaches
1    Melons
1    Ice Cream
1    Mackerel
2    Tea
2    Mustard
2    Pickles
2    Carrots
2    Bok Choy
2    Peaches
2    Melons
2    Ice Cream
2    Mackerel
3    Tea
3    Mustard
3    Pickles
3    Carrots
3    Bok Choy
3    Peaches
3    Melons
3    Ice Cream
3    Mackerel
Non-equijoin query:
1    Tea
2    Mustard
2    Pickles
3    Carrots
3    Bok Choy
", sw.ToString());
    }

    [Fact]
    public void MergeCsvFilesTest()
    {
        var sw = InitTest();

        CustomJoins.MergeCsvFiles();
        Assert.Equal(
@"The average score of Omelchenko Svetlana is 82.5.
The average score of O'Donnell Claire is 72.25.
The average score of Mortensen Sven is 84.5.
The average score of Garcia Cesar is 88.25.
The average score of Garcia Debra is 67.
The average score of Fakhouri Fadi is 92.25.
The average score of Feng Hanying is 88.
The average score of Garcia Hugo is 85.75.
The average score of Tucker Lance is 81.75.
The average score of Adams Terry is 85.25.
The average score of Zabokritski Eugene is 83.
The average score of Tucker Michael is 92.
", sw.ToString());
    }
}
