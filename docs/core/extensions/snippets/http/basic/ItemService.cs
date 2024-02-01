using System.Net.Mime;
using System.Text;
using System.Text.Json;
using Shared;

namespace BasicHttp.Example;

public sealed class ItemService(HttpClient httpClient) : IDisposable
{

    // <Create>
    public async Task CreateItemAsync(Item item)
    {
        using StringContent json = new(
            JsonSerializer.Serialize(item, new JsonSerializerOptions(JsonSerializerDefaults.Web)),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);

        using HttpResponseMessage httpResponse =
            await httpClient.PostAsync("/api/items", json);

        httpResponse.EnsureSuccessStatusCode();
    }
    // </Create>
    // <Update>
    public async Task UpdateItemAsync(Item item)
    {
        using StringContent json = new(
            JsonSerializer.Serialize(item, new JsonSerializerOptions(JsonSerializerDefaults.Web)),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);

        using HttpResponseMessage httpResponse =
            await httpClient.PutAsync($"/api/items/{item.Id}", json);

        httpResponse.EnsureSuccessStatusCode();
    }
    // </Update>
    // <Delete>
    public async Task DeleteItemAsync(Guid id)
    {
        using HttpResponseMessage httpResponse =
            await httpClient.DeleteAsync($"/api/items/{id}");

        httpResponse.EnsureSuccessStatusCode();
    }
    // </Delete>

    void IDisposable.Dispose() => httpClient?.Dispose();
}
