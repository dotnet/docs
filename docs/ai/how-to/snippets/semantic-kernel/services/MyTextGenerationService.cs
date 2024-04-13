using System.Runtime.CompilerServices;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Services;
using Microsoft.SemanticKernel.TextGeneration;

// <service>
class MyTextGenerationService : ITextGenerationService
{
    private IReadOnlyDictionary<string, object?>? _attributes;
    public IReadOnlyDictionary<string, object?> Attributes => _attributes ??= new Dictionary<string, object?>();

    public async IAsyncEnumerable<StreamingTextContent> GetStreamingTextContentsAsync(string prompt, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        string myModelOutput = await Task.Run(() =>
        {
            // Access your model, send the prompt, and receive the output
            // ...
            return "<placeholder for your model's output text>";
        }, cancellationToken);

        foreach (string word in myModelOutput.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            cancellationToken.ThrowIfCancellationRequested();
            yield return new StreamingTextContent($"{word} ");
        }
    }

    public async Task<IReadOnlyList<TextContent>> GetTextContentsAsync(string prompt, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, CancellationToken cancellationToken = default)
    {
        string myModelOutput = await Task.Run(() =>
        {
            // Access your model, send the prompt, and receive the output
            // ...
            return "<placeholder for your model's output text>";
        }, cancellationToken);

        return
        [
            new(myModelOutput)
            // Include any additional outputs from your model in this list
            // ...
        ];
    }
}
// </service>