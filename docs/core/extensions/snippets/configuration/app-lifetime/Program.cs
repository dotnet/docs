// <Program>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AppLifetime.Example;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<ExampleHostedService>();
using IHost host = builder.Build();

await host.RunAsync();
// </Program>
// <Output>
// Sample output:
//     info: ExampleHostedService[0]
//           1. StartAsync has been called.
//     info: ExampleHostedService[0]
//           2. OnStarted has been called.
//     info: Microsoft.Hosting.Lifetime[0]
//           Application started.Press Ctrl+C to shut down.
//     info: Microsoft.Hosting.Lifetime[0]
//           Hosting environment: Production
//     info: Microsoft.Hosting.Lifetime[0]
//           Content root path: ..\app-lifetime\bin\Debug\net7.0
//     info: ExampleHostedService[0]
//           3. OnStopping has been called.
//     info: Microsoft.Hosting.Lifetime[0]
//           Application is shutting down...
//     info: ExampleHostedService[0]
//           4. StopAsync has been called.
//     info: ExampleHostedService[0]
//           5. OnStopped has been called.
// </Output>
