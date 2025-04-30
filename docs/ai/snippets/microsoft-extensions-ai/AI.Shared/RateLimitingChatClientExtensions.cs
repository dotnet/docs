namespace Example.One;

// <one>
using Microsoft.Extensions.AI;
using System.Threading.RateLimiting;

public static class RateLimitingChatClientExtensions
{
    public static ChatClientBuilder UseRateLimiting(this ChatClientBuilder builder, RateLimiter rateLimiter) =>
        builder.Use(innerClient => new RateLimitingChatClient(innerClient, rateLimiter));
}
// </one>
