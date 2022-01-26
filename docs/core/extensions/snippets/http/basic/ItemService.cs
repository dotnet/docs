using System.Net.Mime;
using System.Text;
using System.Text.Json;
using Shared;

namespace BasicHttp.Example;

public class ItemService
{
    private readonly HttpClient _httpClient = null!;

    public ItemService(HttpClient httpClient) => _httpClient = httpClient;

    // <Create>
    public async Task CreateItemAsync(Item item)
    {
        using StringContent json = new(
            JsonSerializer.Serialize(item, DefaultJsonSerialization.Options),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);

        using HttpResponseMessage httpResponse =
            await _httpClient.PostAsync("/api/items", json);

        httpResponse.EnsureSuccessStatusCode();
    }
    // </Create>
    // <Update>
    public async Task UpdateItemAsync(Item item)
    {
        using StringContent json = new(
            JsonSerializer.Serialize(item, DefaultJsonSerialization.Options),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);

        using HttpResponseMessage httpResponse =
            await _httpClient.PutAsync($"/api/items/{item.Id}", json);

        httpResponse.EnsureSuccessStatusCode();
    }
    // </Update>
    // <Delete>
    public async Task DeleteItemAsync(Guid id)
    {
        using HttpResponseMessage httpResponse =
            await _httpClient.DeleteAsync($"/api/items/{id}");

        httpResponse.EnsureSuccessStatusCode();
    }
    // </Delete>
}
