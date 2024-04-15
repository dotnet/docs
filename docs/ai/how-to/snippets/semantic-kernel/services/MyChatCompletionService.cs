using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

// <service>
class MyChatCompletionService : IChatCompletionService
{
    private MyModel myModel = new();

    private IReadOnlyDictionary<string, object?>? _attributes;
    public IReadOnlyDictionary<string, object?> Attributes => _attributes ??= new Dictionary<string, object?>();

    public async Task<IReadOnlyList<ChatMessageContent>> GetChatMessageContentsAsync(ChatHistory chatHistory, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, CancellationToken cancellationToken = default)
    {
        // Access your model, send the chat history, and receive the output
        MyModelRequest request = MyModelRequest.FromChatHistory(chatHistory, executionSettings);
        MyModelResponse response = await myModel.GetCompletionsAsync(request, cancellationToken);

        // Convert your model's response into a list of ChatMessageContent
        return response.Completions
            .Select<string, ChatMessageContent>(completion => new(AuthorRole.Assistant, completion))
            .ToImmutableList();
    }

    public async IAsyncEnumerable<StreamingChatMessageContent> GetStreamingChatMessageContentsAsync(ChatHistory chatHistory, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        // Access your model, send the chat history, and stream the output
        MyModelRequest request = MyModelRequest.FromChatHistory(chatHistory, executionSettings);
        IAsyncEnumerable<string> responseStream = myModel.GetStreamingCompletionAsync(request, cancellationToken);

        // Enumerate over the model's response stream, yield a StreamingChatMessageContent for each iteration
        await foreach (string chunk in responseStream)
        {
            cancellationToken.ThrowIfCancellationRequested();
            yield return new StreamingChatMessageContent(AuthorRole.Assistant, chunk);
        }
    }
}
// </service>