namespace TUnit.Project;

public class ByDependency
{
    public static bool Test1Called;
    public static bool Test2Called;

    [Test]
    public async Task Test1()
    {
        Test1Called = true;

        await Assert.That(Test2Called).IsFalse();
    }

    [Test]
    [DependsOn(nameof(Test1))]
    public async Task Test2()
    {
        Test2Called = true;

        await Assert.That(Test1Called).IsTrue();
    }

    [Test]
    [DependsOn(nameof(Test1))]
    [DependsOn(nameof(Test2))]
    public async Task Test3()
    {
        await Assert.That(Test1Called).IsTrue();
        await Assert.That(Test2Called).IsTrue();
    }
}
