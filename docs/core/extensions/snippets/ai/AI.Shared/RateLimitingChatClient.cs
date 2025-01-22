﻿using Microsoft.Extensions.AI;
using System.Runtime.CompilerServices;
using System.Threading.RateLimiting;

public sealed class RateLimitingChatClient(
    IChatClient innerClient, RateLimiter rateLimiter)
        : DelegatingChatClient(innerClient)
{
    public override async Task<ChatCompletion> CompleteAsync(
        IList<ChatMessage> chatMessages,
        ChatOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        using var lease = await rateLimiter.AcquireAsync(permitCount: 1, cancellationToken)
            .ConfigureAwait(false);

        if (!lease.IsAcquired)
        {
            throw new InvalidOperationException("Unable to acquire lease.");
        }

        return await base.CompleteAsync(chatMessages, options, cancellationToken)
            .ConfigureAwait(false);
    }

    public override async IAsyncEnumerable<StreamingChatCompletionUpdate> CompleteStreamingAsync(
        IList<ChatMessage> chatMessages,
        ChatOptions? options = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        using var lease = await rateLimiter.AcquireAsync(permitCount: 1, cancellationToken)
            .ConfigureAwait(false);

        if (!lease.IsAcquired)
        {
            throw new InvalidOperationException("Unable to acquire lease.");
        }

        await foreach (var update in base.CompleteStreamingAsync(chatMessages, options, cancellationToken)
            .ConfigureAwait(false))
        {
            yield return update;
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            rateLimiter.Dispose();
        }

        base.Dispose(disposing);
    }
}
