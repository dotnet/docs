using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TestClassCancellationToken
{
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
