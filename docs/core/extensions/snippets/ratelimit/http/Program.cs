var options = new TokenBucketRateLimiterOptions(
    tokenLimit: 8, 
    queueProcessingOrder: QueueProcessingOrder.OldestFirst,
    queueLimit: 3, 
    replenishmentPeriod: TimeSpan.FromMilliseconds(1), 
    tokensPerPeriod: 2, 
    autoReplenishment: true);

// Create an HTTP client with the client-side rate limited handler.
using HttpClient client = new(
    handler: new ClientSideRateLimitedHandler(
        limiter: new TokenBucketRateLimiter(options)));



// Create 100 urls with a unique query string.
var oneHundredUrls = Enumerable.Range(0, 100).Select(
    i => $"https://example.com?iteration={i:0#}");

// Flood the HTTP client with requests.
var floodOneThroughFortyNineTask = Parallel.ForEachAsync(
    source: oneHundredUrls.Take(0..49), 
    body: (url, cancellationToken) => GetAsync(client, url, cancellationToken));

var floodFiftyThroughOneHundredTask = Parallel.ForEachAsync(
    source: oneHundredUrls.Take(^50..),
    body: (url, cancellationToken) => GetAsync(client, url, cancellationToken));

await Task.WhenAll(
    floodOneThroughFortyNineTask,
    floodFiftyThroughOneHundredTask);

static async ValueTask GetAsync(
    HttpClient client, string url, CancellationToken cancellationToken)
{
    using var response =
        await client.GetAsync(url, cancellationToken);

    Console.WriteLine(
        $"URL: {url}, HTTP status code: {response.StatusCode} ({(int)response.StatusCode})");
}
