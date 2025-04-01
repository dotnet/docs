using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class MyTestClassTestContextThroughCtor
{
    private readonly TestContext _testContext;

    public MyTestClassTestContextThroughCtor(TestContext testContext)
    {
        _testContext = testContext;
    }

    [AssemblyInitialize]
    public static void AssemblyInitialize(TestContext context)
    {
        // Access TestContext properties and methods here. The properties related to the test run are not available.
    }

    [ClassInitialize]
    public static void ClassInitialize(TestContext context)
    {
        // Access TestContext properties and methods here. The properties related to the test run are not available.
    }

    [TestMethod]
    public void MyTestMethod()
    {
        // Access TestContext properties and methods here
    }
}
