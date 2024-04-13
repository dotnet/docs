using System.Runtime.CompilerServices;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

// <service>
class MyChatCompletionService : IChatCompletionService
{
    private IReadOnlyDictionary<string, object?>? _attributes;
    public IReadOnlyDictionary<string, object?> Attributes => _attributes ??= new Dictionary<string, object?>();

    public async Task<IReadOnlyList<ChatMessageContent>> GetChatMessageContentsAsync(ChatHistory chatHistory, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, CancellationToken cancellationToken = default)
    {
        string myModelOutput = await Task.Run(() =>
        {
            // Access your model, send the chat history, and receive the output
            // ...
            return "<placeholder for your model's output text>";
        }, cancellationToken);

        // Return your models output as an assistant message
        return 
        [
            new(AuthorRole.Assistant, myModelOutput)
            // Include any additional outputs from your model in this list
            // ...
        ];
    }

    public async IAsyncEnumerable<StreamingChatMessageContent> GetStreamingChatMessageContentsAsync(ChatHistory chatHistory, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        string myModelOutput = await Task.Run(() =>
        {
            // Access your model, send the chat history, and receive the output
            // ...
            return "<placeholder for your model's output text>";
        }, cancellationToken);


        foreach (string word in myModelOutput.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            cancellationToken.ThrowIfCancellationRequested();
            yield return new StreamingChatMessageContent(AuthorRole.Assistant, $"{word} ");
        }
    }
}
// </service>