using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateApplicationBuilder(args).Build();

// Application code should start here.

await host.RunAsync();
