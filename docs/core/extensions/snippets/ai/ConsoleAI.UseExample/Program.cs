using Microsoft.Extensions.AI;
using System.Threading.RateLimiting;

RateLimiter rateLimiter = new ConcurrencyLimiter(new()
{
    PermitLimit = 1,
    QueueLimit = int.MaxValue
});

IChatClient client = new SampleChatClient(new Uri("http://localhost"), "test")
    .AsBuilder()
    .UseDistributedCache()
    .Use(async (chatMessages, options, nextAsync, cancellationToken) =>
    {
        using var lease = await rateLimiter.AcquireAsync(permitCount: 1, cancellationToken)
            .ConfigureAwait(false);

        if (!lease.IsAcquired)
        {
            throw new InvalidOperationException("Unable to acquire lease.");
        }

        await nextAsync(chatMessages, options, cancellationToken);
    })
    .UseOpenTelemetry()
    .Build();

// Use client
