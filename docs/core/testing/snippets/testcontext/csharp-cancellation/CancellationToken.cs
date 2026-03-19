using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TestClassCancellationToken
{
    // MSTest automatically sets the TestContext property before each test runs.
    // MSTest.Analyzers includes a diagnostic suppressor that removes CS8618
    // (non-nullable property uninitialized) for this property.
    public TestContext TestContext { get; set; }

    [TestMethod]
    [Timeout(5000, CooperativeCancellation = true)]
    public async Task MyAsyncTest()
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(
            "https://example.com", TestContext.CancellationToken);

        Assert.IsTrue(response.IsSuccessStatusCode);
    }
}
