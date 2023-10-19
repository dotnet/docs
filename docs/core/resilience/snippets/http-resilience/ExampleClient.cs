using System.Net.Http.Json;

namespace Http.Resilience.Example;

internal sealed class ExampleClient(HttpClient client)
{
    public IAsyncEnumerable<Comment?> GetCommentsAsync()
    {
        return client.GetFromJsonAsAsyncEnumerable<Comment>("/comments");
    }
}
