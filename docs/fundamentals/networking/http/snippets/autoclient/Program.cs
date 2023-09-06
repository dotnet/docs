// <program>
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateEmptyApplicationBuilder(null);

// Add a named HTTP client "ICompleteUserClient".
builder.Services.AddHttpClient(nameof(ICompleteUserClient), options =>
{
    options.BaseAddress = new("https://jsonplaceholder.typicode.com");
});

builder.Services.AddCompleteUserClient(options =>
{
    options.JsonSerializerOptions = new(JsonSerializerDefaults.Web)
    {
        PropertyNameCaseInsensitive = true
    };
});

builder.Services.AddSingleton<UserService>();

using IHost host = builder.Build();

UserService service = host.Services.GetRequiredService<UserService>();

await service.ProcessUsersAsync();

host.Run();
// </program>

// <output>
// Sample output:
//   CreateUserAsync: Created user
//      'Ada Lovelace (Email: 1st-computer-programmer@example.com, Id: 11)'...
//   
//   GetUserAsync: Received user
//       'Kurtis Weissnat (Email: Telly.Hoeger@billy.biz, Id: 7)'...
//   
//   GetUsersAsync: Received a total of 10 users...
// </output>
