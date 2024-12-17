namespace Example.Two;

// <two>
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.RateLimiting;

public static class RateLimitingChatClientExtensions
{
    public static ChatClientBuilder UseRateLimiting(
        this ChatClientBuilder builder, RateLimiter? rateLimiter = null) =>
        builder.Use((innerClient, services) =>
            new RateLimitingChatClient(
                innerClient,
                rateLimiter ?? services.GetRequiredService<RateLimiter>()));
}
// </two>
