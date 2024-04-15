using System.Runtime.CompilerServices;

// This is a simple mock model to provide the needed function signatures for the snippet code
class MyModel
{
    public MyModelRequest? LastRequest { get; private set; }

    public Task<MyModelResponse> GetCompletionsAsync(MyModelRequest request, CancellationToken cancellationToken = default)
    {
        LastRequest = request;
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(new MyModelResponse { Completions = ["Hello World!"] });
    }

    public async IAsyncEnumerable<string> GetStreamingCompletionAsync(MyModelRequest request, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        LastRequest = request;
        cancellationToken.ThrowIfCancellationRequested();
        yield return await Task.FromResult("Hello World!");
    }
}