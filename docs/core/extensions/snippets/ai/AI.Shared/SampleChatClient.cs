using System.Runtime.CompilerServices;
using Microsoft.Extensions.AI;

public sealed class SampleChatClient(Uri endpoint, string modelId) : IChatClient
{
    public ChatClientMetadata Metadata { get; } = new(nameof(SampleChatClient), endpoint, modelId);

    public async Task<ChatResponse> GetResponseAsync(
        IEnumerable<ChatMessage> chatMessages,
        ChatOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        // Simulate some operation.
        await Task.Delay(300, cancellationToken);

        // Return a sample chat completion response randomly.
        string[] responses =
        [
            "This is the first sample response.",
            "Here is another example of a response message.",
            "This is yet another response message."
        ];

        return new(new ChatMessage(
            ChatRole.Assistant,
            responses[Random.Shared.Next(responses.Length)]
            ));
    }

    public async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(
        IEnumerable<ChatMessage> chatMessages,
        ChatOptions? options = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        // Simulate streaming by yielding messages one by one.
        string[] words = ["This ", "is ", "the ", "response ", "for ", "the ", "request."];
        foreach (string word in words)
        {
            // Simulate some operation.
            await Task.Delay(100, cancellationToken);

            // Yield the next message in the response.
            yield return new ChatResponseUpdate(ChatRole.Assistant, word);
        }
    }

    public object? GetService(Type serviceType, object? serviceKey) => this;

    public TService? GetService<TService>(object? key = null)
        where TService : class => this as TService;

    void IDisposable.Dispose() { }
}
