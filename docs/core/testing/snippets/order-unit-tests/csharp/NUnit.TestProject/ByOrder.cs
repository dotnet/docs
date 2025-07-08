using NUnit.Framework;

namespace NUnit.Project;

public class ByOrder
{
    public static bool Test1Called;
    public static bool Test2ACalled;
    public static bool Test2BCalled;
    public static bool Test3Called;

    [Test, Order(5)]
    public void Test1()
    {
        Test1Called = true;

        Assert.That(Test2ACalled, Is.False);
        Assert.That(Test2BCalled, Is.True);
        Assert.That(Test3Called, Is.True);
    }

    [Test, Order(0)]
    public void Test2B()
    {
        Test2BCalled = true;

        Assert.That(Test1Called, Is.False);
        Assert.That(Test2ACalled, Is.False);
        Assert.That(Test3Called, Is.True);
    }

    [Test]
    public void Test2A()
    {
        Test2ACalled = true;

        Assert.That(Test1Called, Is.True);
        Assert.That(Test2BCalled, Is.True);
        Assert.That(Test3Called, Is.True);
    }

    [Test, Order(-5)]
    public void Test3()
    {
        Test3Called = true;

        Assert.That(Test1Called, Is.False);
        Assert.That(Test2ACalled, Is.False);
        Assert.That(Test2BCalled, Is.False);
    }
}
