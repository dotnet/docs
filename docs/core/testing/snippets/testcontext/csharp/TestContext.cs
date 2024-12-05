using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class MyTestClassTestContext
{
    public TestContext TestContext { get; set; }

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
