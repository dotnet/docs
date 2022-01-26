---
title: .NET Generic Host
author: IEvangelist
description: Learn about the .NET Generic Host, which is responsible for app startup and lifetime management.
ms.author: dapine
ms.date: 11/12/2021
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

The main reason for including all of the app's interdependent resources in one object is lifetime management: control over app startup and graceful shutdown. This is achieved with the [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) NuGet package.

## Set up a host

The host is typically configured, built, and run by code in the `Program` class. The `Main` method:

- Calls a <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder> method to create and configure a builder object.
- Calls <xref:Microsoft.Extensions.Hosting.IHostBuilder.Build> to create an <xref:Microsoft.Extensions.Hosting.IHost> instance.
- Calls <xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.Run%2A> or <xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.RunAsync%2A> method on the host object.

The .NET Worker Service templates generate the following code to create a Generic Host:

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Worker>();
            });
}
```

## Default builder settings

The <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A> method:

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

The `ConfigureServices` method exposes the ability to add services to the <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection?displayProperty=nameWithType> instance. Later, these services can be made available from dependency injection.

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

:::code language="csharp" source="snippets/configuration/app-lifetime/Program.cs" id="Program" highlight="14":::

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

The host configuration is available in [HostBuilderContext.Configuration](xref:Microsoft.Extensions.Hosting.HostBuilderContext.Configuration) within the <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureAppConfiguration%2A> method. When calling the `ConfigureAppConfiguration` method, the `HostBuilderContext` and `IConfigurationBuilder` are passed into the `configureDelegate`. The `configureDelegate` is defined as an `Action<HostBuilderContext, IConfigurationBuilder>`. The host builder context exposes the `.Configuration` property, which is an instance of `IConfiguration`. It represents the configuration built from the host, whereas the `IConfigurationBuilder` is the builder object used to configure the app.

> [!TIP]
> After `ConfigureAppConfiguration` is called the `HostBuilderContext.Configuration` is replaced with the [app config](#app-configuration).

To add host configuration, call <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureHostConfiguration%2A> on `IHostBuilder`. `ConfigureHostConfiguration` can be called multiple times with additive results. The host uses whichever option sets a value last on a given key.

The following example creates host configuration:

:::code language="csharp" source="snippets/configuration/console-host/Program.cs" highlight="17-23":::

## App configuration

App configuration is created by calling <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureAppConfiguration%2A> on `IHostBuilder`. `ConfigureAppConfiguration` can be called multiple times with additive results. The app uses whichever option sets a value last on a given key.

The configuration created by `ConfigureAppConfiguration` is available in [HostBuilderContext.Configuration](xref:Microsoft.Extensions.Hosting.HostBuilderContext.Configuration%2A) for subsequent operations and as a service from DI. The host configuration is also added to the app configuration.

For more information, see [Configuration in .NET](configuration.md).

## Host shutdown

A hosted service process can be stopped in the following ways:

- If someone doesn't call <xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.Run%2A> or <xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.WaitForShutdown%2A?displayProperty=nameWithType> and the app exits normally with `Main` completing.
- If the app crashes.
- If the app is forcefully shut down using [SIGKILL][sigkill] (or <kbd>CTRL</kbd>+<kbd>Z</kbd>).

All of these scenarios aren't handled directly by the hosting code. The owner of the process needs to deal with
them the same as any application. There are several additional ways in which a hosted service process can be stopped:

- If `ConsoleLifetime` is used, it listens for the following signals and attempts to stop the host gracefully.
  - [SIGINT][sigint] (or <kbd>CTRL</kbd>+<kbd>C</kbd>).
  - [SIGQUIT][sigquit] (or <kbd>CTRL</kbd>+<kbd>BREAK</kbd> on Windows, <kbd>CTRL</kbd>+<kbd>\\</kbd> on Unix).
  - [SIGTERM][sigterm] (sent by other apps, such as `docker stop`).
- If the app calls <xref:System.Environment.Exit%2A?displayProperty=nameWithType>.

These scenarios are handled by the built-in hosting logic, specifically the `ConsoleLifetime`
class. `ConsoleLifetime` tries to handle the "shutdown" signals SIGINT, SIGQUIT, and SIGTERM to allow for a graceful exit to the
application.

[sigkill]: https://en.wikipedia.org/wiki/Signal_(IPC)#SIGKILL
[sigint]: https://en.wikipedia.org/wiki/Signal_(IPC)#SIGINT
[sigquit]: https://en.wikipedia.org/wiki/Signal_(IPC)#SIGQUIT
[sigterm]: https://en.wikipedia.org/wiki/Signal_(IPC)#SIGTERM

Before .NET 6, there wasn't a way for .NET code to gracefully handle SIGTERM. To work around this limitation,
`ConsoleLifetime` would subscribe to <xref:System.AppDomain.ProcessExit?displayProperty=fullName>. When `ProcessExit` was raised,
`ConsoleLifetime` would signal the host to stop and block the `ProcessExit` thread, waiting for the host to stop.
This would allow for the clean-up code in the application to run &mdash; for example, <xref:Microsoft.Extensions.Hosting.IHost.StopAsync%2A?displayProperty=nameWithType> and code after <xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.Run%2A?displayProperty=nameWithType> in the `Main` method.

This caused other issues because SIGTERM wasn't the only way `ProcessExit` was raised. It is also raised by code
in the application calling `Environment.Exit`. `Environment.Exit` isn't a graceful way of shutting down a process
in the `Microsoft.Extensions.Hosting` app model. It raises the `ProcessExit` event and then exits the process. The end of the
`Main` method doesn't get executed. Background and foreground threads are terminated, and `finally` blocks are *not* executed.

Since `ConsoleLifetime` blocked `ProcessExit` waiting for the host to shutdown, this behavior led to [deadlocks][deadlocks]
from `Environment.Exit` also blocking waiting for `ProcessExit` to return. Additionally, since the SIGTERM handling was attempting
to gracefully shut down the process, `ConsoleLifetime` would set the <xref:System.Environment.ExitCode> to `0`, which [clobbered][clobbered] the user's exit code passed to `Environment.Exit`.

[deadlocks]: https://github.com/dotnet/runtime/issues/50397
[clobbered]: https://github.com/dotnet/runtime/issues/42224

In .NET 6, [POSIX signals][POSIX signals] are supported and handled. This allows for `ConsoleLifetime` to handle SIGTERM gracefully, and no longer get involved when `Environment.Exit` is invoked.

[POSIX signals]: https://github.com/dotnet/runtime/issues/50527

> [!TIP]
> For .NET 6+, `ConsoleLifetime` no longer has logic to handle scenario `Environment.Exit`. Apps that call `Environment.Exit` and need to perform clean-up logic can subscribe to `ProcessExit` themselves. Hosting will no longer attempt to gracefully stop the host in this scenario.

If your application uses hosting, and you want to gracefully stop the host, you can call
<xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime.StopApplication%2A?displayProperty=nameWithType> instead of `Environment.Exit`.

### Hosting shutdown process

The following sequence diagram shows how the signals are handled internally in the hosting code. It isn't necessary for most users to understand this process. But for developers that need a deep understanding, this may help you get started.

After the host has been started, when a user calls `Run` or `WaitForShutdown`, a handler gets registered for <xref:Microsoft.Extensions.Hosting.IApplicationLifetime.ApplicationStopping%2A?displayProperty=nameWithType>. Execution is paused in `WaitForShutdown`, waiting for the `ApplicationStopping` event to be raised. This is how the `Main` method doesn't return right away, and the app stays running until
`Run` or `WaitForShutdown` returns.

When a signal is sent to the process, it initiates the following sequence:

:::image type="content" source="media/hosting-shutdown-sequence.svg" lightbox="media/hosting-shutdown-sequence.svg" alt-text="Hosting shutdown sequence diagram.":::

1. The control flows from `ConsoleLifetime` to `ApplicationLifetime` to raise the `ApplicationStopping` event. This signals
`WaitForShutdownAsync` to unblock the `Main` execution code. In the meantime, the POSIX signal handler returns with
`Cancel = true` since this POSIX signal has been handled.
1. The `Main` execution code starts executing again and tells the host to `StopAsync()`, which in turn stops all the hosted
services, and raises any other stopped events.
1. Finally, `WaitForShutdown` exits, allowing for any application clean up code to execute, and for the `Main` method
to exit gracefully.

## See also

- [Dependency injection in .NET](dependency-injection.md)
- [Logging in .NET](logging.md)
- [Configuration in .NET](configuration.md)
- [Worker Services in .NET](workers.md)
- [ASP.NET Core Web Host](/aspnet/core/fundamentals/host/web-host)
- Generic host bugs should be created in the [github.com/dotnet/extensions](https://github.com/dotnet/extensions/issues) repo
