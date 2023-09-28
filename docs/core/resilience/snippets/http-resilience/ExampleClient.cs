using System.Net.Http.Json;

internal sealed class ExampleClient(HttpClient client)
{
    public IAsyncEnumerable<Comment?> GetCommentsAsync()
    {
        return client.GetFromJsonAsAsyncEnumerable<Comment>("/comments");
    }
}
