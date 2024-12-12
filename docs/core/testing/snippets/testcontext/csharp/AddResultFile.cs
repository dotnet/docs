using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TestClassResultFile
{
    public TestContext TestContext { get; set; }

    [TestMethod]
    public void TestMethodWithResultFile()
    {
        // Simulate creating a log file for this test
        string logFilePath = Path.Combine(TestContext.TestRunDirectory, "TestLog.txt");
        File.WriteAllText(logFilePath, "This is a sample log entry for the test.");

        // Add the log file to the test result
        TestContext.AddResultFile(logFilePath);

        // Perform some assertions (example only)
        Assert.IsTrue(File.Exists(logFilePath), "The log file was not created.");
        Assert.IsTrue(new FileInfo(logFilePath).Length > 0, "The log file is empty.");
    }
}
