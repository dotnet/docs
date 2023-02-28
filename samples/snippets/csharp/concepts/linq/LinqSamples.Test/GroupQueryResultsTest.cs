using Xunit;
using static LinqSamples.Test.Shared;

namespace LinqSamples.Test;

public class GroupQueryResultsTest
{
    [Fact]
    public void GroupQueryResults1Test()
    {
        var sw = InitTest();

        GroupQueryResults.GroupQueryResults1();
        Assert.Equal(
@"Key: Adams
    Adams, Terry
Key: Fakhouri
    Fakhouri, Fadi
Key: Feng
    Feng, Hanying
Key: Garcia
    Garcia, Cesar
    Garcia, Debra
    Garcia, Hugo
Key: Mortensen
    Mortensen, Sven
Key: O'Donnell
    O'Donnell, Claire
Key: Omelchenko
    Omelchenko, Svetlana
Key: Tucker
    Tucker, Lance
    Tucker, Michael
Key: Zabokritski
    Zabokritski, Eugene
", sw.ToString().Replace("\t","    "));
    }

    [Fact]
    public void GroupQueryResults2Test()
    {
        var sw = InitTest();

        GroupQueryResults.GroupQueryResults2();
        Assert.Equal(
@"Key: A
    Adams, Terry
Key: F
    Fakhouri, Fadi
    Feng, Hanying
Key: G
    Garcia, Cesar
    Garcia, Debra
    Garcia, Hugo
Key: M
    Mortensen, Sven
Key: O
    O'Donnell, Claire
    Omelchenko, Svetlana
Key: T
    Tucker, Lance
    Tucker, Michael
Key: Z
    Zabokritski, Eugene
", sw.ToString().Replace("\t", "    "));
    }

    [Fact]
    public void GroupQueryResults3Test()
    {
        var sw= InitTest();

        GroupQueryResults.GroupQueryResults3();
        Assert.Equal(
@"Key: 60
    Garcia, Debra
Key: 70
    O'Donnell, Claire
Key: 80
    Adams, Terry
    Feng, Hanying
    Garcia, Cesar
    Garcia, Hugo
    Mortensen, Sven
    Omelchenko, Svetlana
    Tucker, Lance
    Zabokritski, Eugene
Key: 90
    Fakhouri, Fadi
    Tucker, Michael
", sw.ToString().Replace("\t", "    "));
    }

    [Fact]
    public void GroupQueryResults4Test()
    {
        var sw = InitTest();

        GroupQueryResults.GroupQueryResults4();
        Assert.Equal(
@"Key: True
    Terry Adams
    Fadi Fakhouri
    Hanying Feng
    Cesar Garcia
    Hugo Garcia
    Sven Mortensen
    Svetlana Omelchenko
    Lance Tucker
    Michael Tucker
    Eugene Zabokritski
Key: False
    Debra Garcia
    Claire O'Donnell
", sw.ToString().Replace("\t", "    "));
    }

    [Fact]
    public void GroupQueryResults5Test()
    {
        var sw = InitTest();

        GroupQueryResults.GroupQueryResults5();
        Assert.Equal(
@"Name starts with A who scored more than 85
    Terry Adams
Name starts with F who scored more than 85
    Fadi Fakhouri
    Hanying Feng
Name starts with G who scored more than 85
    Cesar Garcia
    Hugo Garcia
Name starts with G who scored less than 85
    Debra Garcia
Name starts with M who scored more than 85
    Sven Mortensen
Name starts with O who scored less than 85
    Claire O'Donnell
Name starts with O who scored more than 85
    Svetlana Omelchenko
Name starts with T who scored less than 85
    Lance Tucker
Name starts with T who scored more than 85
    Michael Tucker
Name starts with Z who scored more than 85
    Eugene Zabokritski
", sw.ToString().Replace("\t", "    "));
    }
}
