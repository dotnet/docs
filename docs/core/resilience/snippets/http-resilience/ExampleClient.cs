using System.Net.Http.Json;

namespace Http.Resilience.Example;

/// <summary>
/// An example client service, that relies on the <see cref="HttpClient"/> instance.
/// </summary>
/// <param name="client">The given <see cref="HttpClient"/> instance.</param>
internal sealed class ExampleClient(HttpClient client)
{
    /// <summary>
    /// Returns an <see cref="IAsyncEnumerable{T}"/> of <see cref="Comment"/>s.
    /// </summary>
    public IAsyncEnumerable<Comment?> GetCommentsAsync()
    {
        return client.GetFromJsonAsAsyncEnumerable<Comment>("/comments");
    }
}
