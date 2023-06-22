---
title: .NET Generic Host
author: IEvangelist
description: Learn about the .NET Generic Host, which is responsible for app startup and lifetime management.
ms.author: dapine
ms.date: 05/12/2023
---

# .NET Generic Host

The Worker Service templates create a .NET Generic Host, <xref:Microsoft.Extensions.Hosting.HostBuilder>. The Generic Host can be used with other types of .NET applications, such as Console apps.

A *host* is an object that encapsulates an app's resources and lifetime functionality, such as:

- Dependency injection (DI)
- Logging
- Configuration
- App shutdown
- `IHostedService` implementations

When a host starts, it calls <xref:Microsoft.Extensions.Hosting.IHostedService.StartAsync%2A?displayProperty=nameWithType> on each implementation of <xref:Microsoft.Extensions.Hosting.IHostedService> registered in the service container's collection of hosted services. In a worker service app, all `IHostedService` implementations that contain <xref:Microsoft.Extensions.Hosting.BackgroundService> instances have their <xref:Microsoft.Extensions.Hosting.BackgroundService.ExecuteAsync%2A?displayProperty=nameWithType> methods called.

The main reason for including all of the app's interdependent resources in one object is lifetime management: control over app startup and graceful shutdown. Reference the [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) NuGet package to achieve lifetime management.

## Set up a host

The host is typically configured, built, and run by code in the `Program` class. The `Main` method:

- Calls a <xref:Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder%2A> method to create and configure a builder object.
- Calls <xref:Microsoft.Extensions.Hosting.IHostBuilder.Build> to create an <xref:Microsoft.Extensions.Hosting.IHost> instance.
- Calls <xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.Run%2A> or <xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.RunAsync%2A> method on the host object.

The .NET Worker Service templates generate the following code to create a Generic Host:

```csharp
using Example.WorkerService;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

IHost host = builder.Build();
host.Run();
```

## Default builder settings

The <xref:Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder%2A> method:

- Sets the content root to the path returned by <xref:System.IO.Directory.GetCurrentDirectory>.
- Loads [host configuration](#host-configuration) from:
  - Environment variables prefixed with `DOTNET_`.
  - Command-line arguments.
- Loads app configuration from:
  - *appsettings.json*.
  - *appsettings.{Environment}.json*.
  - Secret Manager when the app runs in the `Development` environment.
  - Environment variables.
  - Command-line arguments.
- Adds the following logging providers:
  - Console
  - Debug
  - EventSource
  - EventLog (only when running on Windows)
- Enables scope validation and [dependency validation](xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions.ValidateOnBuild) when the environment is `Development`.

The <xref:Microsoft.Extensions.Hosting.HostApplicationBuilder.Services?displayProperty=nameWithType> is an <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection?displayProperty=nameWithType> instance. These services are used to build an <xref:System.IServiceProvider> that's used with dependency injection to resolve the registered services.

## Framework-provided services

The following services are registered automatically:

- [IHostApplicationLifetime](#ihostapplicationlifetime)
- [IHostLifetime](#ihostlifetime)
- [IHostEnvironment](#ihostenvironment)

## IHostApplicationLifetime

Inject the <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime> service into any class to handle post-startup and graceful shutdown tasks. Three properties on the interface are cancellation tokens used to register app start and app stop event handler methods. The interface also includes a <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime.StopApplication> method.

The following example is an `IHostedService` implementation that registers `IHostApplicationLifetime` events:

:::code language="csharp" source="snippets/configuration/app-lifetime/ExampleHostedService.cs" highlight="16-18":::

The Worker Service template could be modified to add the `ExampleHostedService` implementation:

:::code language="csharp" source="snippets/configuration/app-lifetime/Program.cs" id="Program" highlight="8":::

The application would write the following sample output:

:::code language="csharp" source="snippets/configuration/app-lifetime/Program.cs" id="Output":::

## IHostLifetime

The <xref:Microsoft.Extensions.Hosting.IHostLifetime> implementation controls when the host starts and when it stops. The last implementation registered is used. `Microsoft.Extensions.Hosting.Internal.ConsoleLifetime` is the default `IHostLifetime` implementation. For more information on the lifetime mechanics of shutdown, see [Host shutdown](#host-shutdown).

## IHostEnvironment

Inject the <xref:Microsoft.Extensions.Hosting.IHostEnvironment> service into a class to get information about the following settings:

- <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ApplicationName?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootFileProvider?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootPath?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Hosting.IHostEnvironment.EnvironmentName?displayProperty=nameWithType>

## Host configuration

Host configuration is used to configure properties of the [IHostEnvironment](#ihostenvironment) implementation.

The host configuration is available in [HostBuilderContext.Configuration](xref:Microsoft.Extensions.Hosting.HostBuilderContext.Configuration) within the <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureAppConfiguration%2A> method. When you call the `ConfigureAppConfiguration` method, the `HostBuilderContext` and `IConfigurationBuilder` are passed into the `configureDelegate`. The `configureDelegate` is defined as an `Action<HostBuilderContext, IConfigurationBuilder>`. The host builder context exposes the `Configuration` property, which is an instance of `IConfiguration`. It represents the configuration built from the host, whereas the `IConfigurationBuilder` is the builder object used to configure the app.

> [!TIP]
> After `ConfigureAppConfiguration` is called the `HostBuilderContext.Configuration` is replaced with the [app config](#app-configuration).

To add host configuration, call <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureHostConfiguration%2A> on `IHostBuilder`. `ConfigureHostConfiguration` can be called multiple times with additive results. The host uses whichever option sets a value last on a given key.

The following example creates host configuration:

:::code language="csharp" source="snippets/configuration/console-host/Program.cs" highlight="5-11":::

## App configuration

App configuration is created by calling <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureAppConfiguration%2A> on `IHostBuilder`. `ConfigureAppConfiguration` can be called multiple times with additive results. The app uses whichever option sets a value last on a given key.

The configuration created by `ConfigureAppConfiguration` is available in [HostBuilderContext.Configuration](xref:Microsoft.Extensions.Hosting.HostBuilderContext.Configuration%2A) for subsequent operations and as a service from DI. The host configuration is also added to the app configuration.

For more information, see [Configuration in .NET](configuration.md).

## Host shutdown

There are several ways in which a hosted process is stopped. Most commonly, a hosted process can be stopped in the following ways:

- If someone doesn't call <xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.Run%2A> or <xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.WaitForShutdown%2A?displayProperty=nameWithType> and the app exits normally with `Main` completing.
- If the app crashes.
- If the app is forcefully shut down using [SIGKILL][sigkill] (or <kbd>CTRL</kbd>+<kbd>Z</kbd>).

The hosting code isn't responsible for handling these scenarios. The owner of the process needs to deal with them the same as any other app. There are several other ways in which a hosted service process can be stopped:

- If `ConsoleLifetime` is used (<xref:Microsoft.Extensions.Hosting.HostingHostBuilderExtensions.UseConsoleLifetime%2A>), it listens for the following signals and attempts to stop the host gracefully.
  - [SIGINT][sigint] (or <kbd>CTRL</kbd>+<kbd>C</kbd>).
  - [SIGQUIT][sigquit] (or <kbd>CTRL</kbd>+<kbd>BREAK</kbd> on Windows, <kbd>CTRL</kbd>+<kbd>\\</kbd> on Unix).
  - [SIGTERM][sigterm] (sent by other apps, such as `docker stop`).
- If the app calls <xref:System.Environment.Exit%2A?displayProperty=nameWithType>.

The built-in hosting logic handles these scenarios, specifically the `ConsoleLifetime`
class. `ConsoleLifetime` tries to handle the "shutdown" signals SIGINT, SIGQUIT, and SIGTERM to allow for a graceful exit to the
application.

[sigkill]: https://en.wikipedia.org/wiki/Signal_(IPC)#SIGKILL
[sigint]: https://en.wikipedia.org/wiki/Signal_(IPC)#SIGINT
[sigquit]: https://en.wikipedia.org/wiki/Signal_(IPC)#SIGQUIT
[sigterm]: https://en.wikipedia.org/wiki/Signal_(IPC)#SIGTERM

Before .NET 6, there wasn't a way for .NET code to gracefully handle SIGTERM. To work around this limitation, `ConsoleLifetime` would subscribe to <xref:System.AppDomain.ProcessExit?displayProperty=fullName>. When `ProcessExit` was raised, `ConsoleLifetime` would signal the host to stop and block the `ProcessExit` thread, waiting for the host to stop.

The process exit handler would allow for the clean-up code in the application to run—for example, <xref:Microsoft.Extensions.Hosting.IHost.StopAsync%2A?displayProperty=nameWithType> and code after <xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.Run%2A?displayProperty=nameWithType> in the `Main` method.

However, there were other issues with this approach because SIGTERM wasn't the only way `ProcessExit` was raised. SIGTERM is also raised when app code calls `Environment.Exit`. `Environment.Exit` isn't a graceful way of shutting down a process in the `Microsoft.Extensions.Hosting` app model. It raises the `ProcessExit` event and then exits the process. The end of the `Main` method doesn't get executed. Background and foreground threads are terminated, and `finally` blocks *aren't* executed.

Since `ConsoleLifetime` blocked `ProcessExit` while waiting for the host to shut down, this behavior led to [deadlocks][deadlocks] from `Environment.Exit` also blocks waiting for the call to `ProcessExit`. Additionally, since the SIGTERM handling was attempting to gracefully shut down the process, `ConsoleLifetime` would set the <xref:System.Environment.ExitCode> to `0`, which [clobbered][clobbered] the user's exit code passed to `Environment.Exit`.

[deadlocks]: https://github.com/dotnet/runtime/issues/50397
[clobbered]: https://github.com/dotnet/runtime/issues/42224

In .NET 6, [POSIX signals][POSIX signals] are supported and handled. The `ConsoleLifetime` handles SIGTERM gracefully, and no longer gets involved when `Environment.Exit` is invoked.

[POSIX signals]: https://github.com/dotnet/runtime/issues/50527

> [!TIP]
> For .NET 6+, `ConsoleLifetime` no longer has logic to handle scenario `Environment.Exit`. Apps that call `Environment.Exit` and need to perform clean-up logic can subscribe to `ProcessExit` themselves. Hosting will no longer attempt to gracefully stop the host in these scenarios.

If your application uses hosting, and you want to gracefully stop the host, you can call
<xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime.StopApplication%2A?displayProperty=nameWithType> instead of `Environment.Exit`.

### Hosting shutdown process

The following sequence diagram shows how the signals are handled internally in the hosting code. Most users don't need to understand this process. But for developers that need a deep understanding, a good visual may help you get started.

After the host has been started, when a user calls `Run` or `WaitForShutdown`, a handler gets registered for <xref:Microsoft.Extensions.Hosting.IApplicationLifetime.ApplicationStopping%2A?displayProperty=nameWithType>. Execution is paused in `WaitForShutdown`, waiting for the `ApplicationStopping` event to be raised. The `Main` method doesn't return right away, and the app stays running until `Run` or `WaitForShutdown` returns.

When a signal is sent to the process, it initiates the following sequence:

:::image type="content" source="media/hosting-shutdown-sequence.svg" lightbox="media/hosting-shutdown-sequence.svg" alt-text="Hosting shutdown sequence diagram.":::

1. The control flows from `ConsoleLifetime` to `ApplicationLifetime` to raise the `ApplicationStopping` event. This signals
`WaitForShutdownAsync` to unblock the `Main` execution code. In the meantime, the POSIX signal handler returns with
`Cancel = true` since the POSIX signal has been handled.
1. The `Main` execution code starts executing again and tells the host to `StopAsync()`, which in turn stops all the hosted
services, and raises any other stopped events.
1. Finally, `WaitForShutdown` exits, allowing for any application clean-up code to execute, and for the `Main` method
to exit gracefully.

### Host shutdown in web server scenarios

There are various other common scenarios in which graceful shutdown works in Kestrel for both HTTP/1.1 and HTTP/2 protocols, and how you can configure it in different environments with a load balancer to drain traffic smoothly. While web server configuration is beyond the scope of this article, you can find more information on [Configure options for the ASP.NET Core Kestrel web server](/aspnet/core/fundamentals/servers/kestrel/options) documentation.

When the Host receives a shutdown signal (for example, <kbd>CTL</kbd>+<kbd>C</kbd> or `StopAsync`), it notifies the application by signaling <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime.ApplicationStopping>. You should subscribe to this event if you have any long-running operations that need to finish gracefully.

Next, the Host calls <xref:Microsoft.AspNetCore.Hosting.Server.IServer.StopAsync%2A?displayProperty=nameWithType> with a shutdown timeout that you can configure (default 30s). Kestrel (and Http.Sys) close their port bindings and stop accepting new connections. They also tell the current connections to stop processing new requests. For HTTP/2 and HTTP/3, a preliminary `GOAWAY` message is sent to the client. For HTTP/1.1, they stop the connection loop because requests are processed in order. IIS behaves differently, by rejecting new requests with a 503 status code.

The active requests have until the shutdown timeout to complete. If they're all complete before the timeout, the server returns control to the host sooner. If the timeout expires, the pending connections and requests are aborted forcefully, which can cause errors in the logs and to the clients.

#### Load balancer considerations

To ensure a smooth transition of clients to a new destination when working with a load balancer, you can follow these steps:

- Bring up the new instance and start balancing traffic to it (you may already have several instances for scaling purposes).
- Disable or remove the old instance in the load balancer configuration so it stops receiving new traffic.
- Signal the old instance to shut down.
- Wait for it to drain or time out.

## See also

- [Dependency injection in .NET](dependency-injection.md)
- [Logging in .NET](logging.md)
- [Configuration in .NET](configuration.md)
- [Worker Services in .NET](workers.md)
- [ASP.NET Core Web Host](/aspnet/core/fundamentals/host/web-host)
- [ASP.NET Core Kestrel web server configuration](/aspnet/core/fundamentals/servers/kestrel/options)
- Generic host bugs should be created in the [github.com/dotnet/runtime](https://github.com/dotnet/runtime/issues) repo
