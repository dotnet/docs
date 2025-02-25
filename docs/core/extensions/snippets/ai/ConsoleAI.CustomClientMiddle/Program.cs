using Microsoft.Extensions.AI;
using System.Threading.RateLimiting;

var client = new RateLimitingChatClient(
    new SampleChatClient(new Uri("http://localhost"), "test"),
    new ConcurrencyLimiter(new()
    {
        PermitLimit = 1,
        QueueLimit = int.MaxValue
    }));

await client.GetResponseAsync("What color is the sky?");
