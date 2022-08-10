// <todoclient>
using HttpClient todoClient = new()
{
    BaseAddress = new Uri("https://jsonplaceholder.typicode.com")
};
// </todoclient>

await GetAsync(todoClient);
await GetFromJsonAsync(todoClient);
await PostAsync(todoClient);
await PostAsJsonAsync(todoClient);
await PutAsync(todoClient);
await PutAsJsonAsync(todoClient);
await PatchAsync(todoClient);
await DeleteAsync(todoClient);

// <client>
using HttpClient client = new();
// </client>

await HeadAsync(client);
await OptionsAsync(client);
