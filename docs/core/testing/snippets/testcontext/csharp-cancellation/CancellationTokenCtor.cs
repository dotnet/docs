using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TestClassCancellationTokenCtor
{
    private readonly TestContext _testContext;

    public TestClassCancellationTokenCtor(TestContext testContext)
    {
        _testContext = testContext;
    }

    [TestMethod]
    [Timeout(5000, CooperativeCancellation = true)]
    public async Task MyAsyncTest()
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(
            "https://example.com", _testContext.CancellationToken);

        Assert.IsTrue(response.IsSuccessStatusCode);
    }
}
