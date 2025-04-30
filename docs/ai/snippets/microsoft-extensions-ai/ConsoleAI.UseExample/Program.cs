using Microsoft.Extensions.AI;
using System.Threading.RateLimiting;

RateLimiter rateLimiter = new ConcurrencyLimiter(new()
{
    PermitLimit = 1,
    QueueLimit = int.MaxValue
});

IChatClient client = new OllamaChatClient(new Uri("http://localhost:11434"), "llama3.1")
    .AsBuilder()
    .UseDistributedCache()
    .Use(async (messages, options, nextAsync, cancellationToken) =>
    {
        using var lease = await rateLimiter.AcquireAsync(permitCount: 1, cancellationToken).ConfigureAwait(false);
        if (!lease.IsAcquired)
            throw new InvalidOperationException("Unable to acquire lease.");

        await nextAsync(messages, options, cancellationToken);
    })
    .UseOpenTelemetry()
    .Build();
