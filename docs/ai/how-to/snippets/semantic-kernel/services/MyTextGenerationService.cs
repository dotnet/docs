using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.TextGeneration;

// <service>
class MyTextGenerationService : ITextGenerationService
{
    private MyModel myModel = new();
    
    private IReadOnlyDictionary<string, object?>? _attributes;
    public IReadOnlyDictionary<string, object?> Attributes => _attributes ??= new Dictionary<string, object?>();

    public async IAsyncEnumerable<StreamingTextContent> GetStreamingTextContentsAsync(string prompt, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        // Access your model, send the prompt, and stream the output
        MyModelRequest request = MyModelRequest.FromPrompt(prompt, executionSettings);
        IAsyncEnumerable<string> responseStream = myModel.GetStreamingCompletionAsync(request, cancellationToken);

        // Enumerate over the model's response stream, yield a StreamingTextContent for each iteration
        await foreach (string chunk in responseStream)
        {
            cancellationToken.ThrowIfCancellationRequested();
            yield return new StreamingTextContent(chunk);
        }
    }

    public async Task<IReadOnlyList<TextContent>> GetTextContentsAsync(string prompt, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, CancellationToken cancellationToken = default)
    {
        // Access your model, send the prompt, and receive the output
        MyModelRequest request = MyModelRequest.FromPrompt(prompt, executionSettings);
        MyModelResponse response = await myModel.GetCompletionsAsync(request, cancellationToken);

        // Convert your model's response into a list of TextContent
        return response.Completions
            .Select<string, TextContent>(completion => new(completion))
            .ToImmutableList();
    }
}
// </service>