namespace TUnit.Project;

public class ByOverloadedDependency
{
    [Test]
    public void Setup()
    {
    }

    [Test]
    [Arguments("value", 1)]
    public void Setup(string text, int number)
    {
    }

    [Test]
    [DependsOn(nameof(Setup), [typeof(string), typeof(int)])]
    public void DependentTest()
    {
    }
}
