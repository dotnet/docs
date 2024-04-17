using System.Collections.Immutable;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

// <service>
class MyChatCompletionService : IChatCompletionService
{
    private IReadOnlyDictionary<string, object?>? _attributes;
    public IReadOnlyDictionary<string, object?> Attributes => _attributes ??= new Dictionary<string, object?>();
    
    public string ModelUrl { get; init; } = "<default url to your model's Chat API>";
    public required string ModelApiKey { get; init; }

    public async Task<IReadOnlyList<ChatMessageContent>> GetChatMessageContentsAsync(ChatHistory chatHistory, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, CancellationToken cancellationToken = default)
    {
        // Build your model's request object
        MyModelRequest request = MyModelRequest.FromChatHistory(chatHistory, executionSettings);

        // Send the completion request via HTTP
        using var httpClient = new HttpClient();

        // Send a POST to your model with the serialized request in the body
        using HttpResponseMessage httpResponse = await httpClient.PostAsJsonAsync(ModelUrl, request, cancellationToken);

        // Verify the request was completed successfully
        httpResponse.EnsureSuccessStatusCode();

        // Deserialize the response body to your model's response object
        // Handle when the deserialization fails and returns null
        MyModelResponse response = await httpResponse.Content.ReadFromJsonAsync<MyModelResponse>(cancellationToken)
            ?? throw new Exception("Failed to deserialize response from model");

        // Convert your model's response into a list of ChatMessageContent
        return response.Completions
            .Select<string, ChatMessageContent>(completion => new(AuthorRole.Assistant, completion))
            .ToImmutableList();
    }

    public async IAsyncEnumerable<StreamingChatMessageContent> GetStreamingChatMessageContentsAsync(ChatHistory chatHistory, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        // Build your model's request object, specify that streaming is requested
        MyModelRequest request = MyModelRequest.FromChatHistory(chatHistory, executionSettings);
        request.Stream = true;

        // Send the completion request via HTTP
        using var httpClient = new HttpClient();

        // Send a POST to your model with the serialized request in the body
        using HttpResponseMessage httpResponse = await httpClient.PostAsJsonAsync(ModelUrl, request, cancellationToken);

        // Verify the request was completed successfully
        httpResponse.EnsureSuccessStatusCode();

        // Read your models response as a stream
        using StreamReader reader = new(await httpResponse.Content.ReadAsStreamAsync(cancellationToken));

        // Iteratively read a chunk of the response until the end of the stream
        // It is more efficient to use a buffer that is the same size as the internal buffer of the stream
        // If the size of the internal buffer was unspecified when the stream was constructed, its default size is 4 kilobytes (2048 UTF-16 characters)
        char[] buffer = new char[2048];
        while(!reader.EndOfStream)
        {
            // Check the cancellation token with each iteration
            cancellationToken.ThrowIfCancellationRequested();

            // Fill the buffer with the next set of characters, track how many characters were read
            int readCount = reader.Read(buffer, 0, buffer.Length);

            // Convert the character buffer to a string, only include as many characters as were just read
            string chunk = new(buffer, 0, readCount);

            yield return new StreamingChatMessageContent(AuthorRole.Assistant, chunk);
        }
    }
}
// </service>