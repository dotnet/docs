// <setup>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var app = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddKubernetesResourceMonitoring("MY_APP_");
    })
    .Build();

await app.RunAsync();
// </setup>
