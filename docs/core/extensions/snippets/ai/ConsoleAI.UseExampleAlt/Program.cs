using System.Threading.RateLimiting;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;

var client = new SampleChatClient(new Uri("http://localhost"), "test")
    .AsBuilder()
    .UseDistributedCache()
    .Use(static (innerClient, services) =>
    {
        var rateLimiter = services.GetRequiredService<RateLimiter>();

        return new AnonymousDelegatingChatClient(
            innerClient, async (chatMessages, options, nextAsync, cancellationToken) =>
            {
                using var lease = await rateLimiter.AcquireAsync(permitCount: 1, cancellationToken)
                    .ConfigureAwait(false);

                if (!lease.IsAcquired)
                {
                    throw new InvalidOperationException("Unable to acquire lease.");
                }

                await nextAsync(chatMessages, options, cancellationToken);
            });
    })
    .UseOpenTelemetry()
    .Build();
