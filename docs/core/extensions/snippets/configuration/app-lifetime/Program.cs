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
//     info: AppLifetime.Example.ExampleHostedService[0]
//           1.StartingAsync has been called.
//     info: AppLifetime.Example.ExampleHostedService[0]
//           2.StartAsync has been called.
//     info: AppLifetime.Example.ExampleHostedService[0]
//           3.StartedAsync has been called.
//     info: AppLifetime.Example.ExampleHostedService[0]
//           4.OnStarted has been called.
//     info: Microsoft.Hosting.Lifetime[0]
//           Application started. Press Ctrl+C to shut down.
//     info: Microsoft.Hosting.Lifetime[0]
//           Hosting environment: Production
//     info: Microsoft.Hosting.Lifetime[0]
//           Content root path: ..\app-lifetime\bin\Debug\net8.0
//     info: AppLifetime.Example.ExampleHostedService[0]
//           5.OnStopping has been called.
//     info: Microsoft.Hosting.Lifetime[0]
//           Application is shutting down...
//     info: AppLifetime.Example.ExampleHostedService[0]
//           6.StoppingAsync has been called.
//     info: AppLifetime.Example.ExampleHostedService[0]
//           7.StopAsync has been called.
//     info: AppLifetime.Example.ExampleHostedService[0]
//           8.StoppedAsync has been called.
//     info: AppLifetime.Example.ExampleHostedService[0]
//           9.OnStopped has been called.
// </Output>
