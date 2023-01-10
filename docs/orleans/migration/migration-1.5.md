---
title: Migration from Orleans 1.5 to 2.0
description: Learn how to migrate forward from Orleans 1.5 to 2.0.
ms.date: 03/21/2022
---

# Migration from Orleans 1.5 to 2.0

The bulk of the Orleans APIs stayed unchanged in 2.0 or implementation of those APIs were left in legacy classes for backward compatibility. At the same time, the newly introduced APIs provide some new capabilities or better ways of accomplishing those tasks. There are also more subtle differences when it comes to .NET SDK tooling and Visual Studio support that helps to be aware of. This document guides migrating application code to Orleans 2.0.

## Visual Studio and tooling requirements

Orleans 2.0.0 is built on top of .NET Standard 2.0. Because of that, you need to upgrade development tools to ensure yourself a pleasant developing experience. We recommend using Visual Studio 2017 or above to develop Orleans 2.0.0 applications. Based on our experience, version 15.5.2 and above works best. .NET Standard 2.0.0 is compatible with .NET 4.6.1 and above, .NET Core 2.0, and a list of other frameworks. Orleans 2.0.0 inherited that compatibility. For more information on .NET Standard compatibility with another framework, please refer to [.NET Standard documentation](../../standard/net-standard.md).

If you are developing a .NET Core or .NET application using Orleans, you will need to follow certain steps to set up your environment, such as installing .NET Core SDK. For more information, please refer to their [documentation](https://dotnet.github.io/).

## Available options for configuration code

## Hosting

### Configuring and Starting a Silo (using the new SiloBuilder API and legacy ClusterConfiguration object)

There are several new option classes in Orleans 2.0 that provide a new way for configuring a silo.
To ease migration to the new API, there is an optional backward compatibility package, `Microsoft.Orleans.Runtime.Legacy`, that provides a bridge from the old 1.x configuration API to the new one.

If you add `Microsoft.Orleans.Runtime.Legacy` package, a silo can still be configured programmatically via the legacy `ClusterConfiguration` object that can then be passed to `SiloHostBuilder` to build and start a silo.

You still need to specify grain class assemblies via the <xref:Orleans.Hosting.SiloHostBuilderExtensions.ConfigureApplicationParts%2A> call. Here is an example of how a local silo can be configured in the legacy way:

```csharp
class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            var host = await StartSiloAsync();

            Console.WriteLine("Press Enter to terminate...");
            Console.ReadLine();

            await host.StopAsync();

            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return 1;
        }
    }

    static async Task<ISiloHost> StartSiloAsync()
    {

        var config = ClusterConfiguration.LocalhostPrimarySilo();
        config.AddMemoryStorageProvider();

        var builder = new HostBuilder()
            .UseOrleans(c =>
            {
                c.UseConfiguration(config)
                .ConfigureApplicationParts(parts =>
                    parts.AddApplicationPart(typeof(HelloGrain).Assembly)
                        .WithReferences())
                .ConfigureLogging(logging => logging.AddConsole());
            });

        var host = builder.Build();
        await host.StartAsync();

        return host;
    }
}
```

### Configure client

There are several new option classes in Orleans 2.0 that provide a new way for configuring a client. To ease migration to the new API, there is an optional backward compatibility package, `Microsoft.Orleans.Core.Legacy`, that provides a bridge from the old 1.x configuration API to the new one.

If you added `Microsoft.Orleans.Core.Legacy` package, a client can still be configured programmatically via the legacy <xref:Orleans.Runtime.Configuration.ClientConfiguration> object that can then be passed to `ClientBuilder` to build and connect the client.

You still need to specify grain interface assemblies via the `ConfigureApplicationParts` call. Here is an example of how a client can connect to a local silo, using legacy configuration:

```csharp
var config = ClientConfiguration.LocalhostSilo();
var builder = new ClientBuilder()
    .UseConfiguration(config)
    .ConfigureApplicationParts(
        parts => parts.AddApplicationPart(typeof(IHello).Assembly))
    .ConfigureLogging(logging => logging.AddConsole());

var client = builder.Build();
await client.Connect();
```

## Configure logging

Orleans 2.0 uses the same logging abstractions as ASP.NET Core 2.0. You can find a replacement for most Orleans logging features in ASP.NET Core logging. Orleans specific logging feature, such as <xref:Orleans.Runtime.ILogConsumer> and message bulking, is still maintained in `Microsoft.Orleans.Logging.Legacy` package, so that you still have the option to use them. But how to configure your logging with Orleans changed in 2.0. Let me walk you through the process of migration.

In 1.5, logging configuration is done through `ClientConfiguration` and `NodeConfiguration`. You can configure `DefaultTraceLevel`, `TraceFileName`, `TraceFilePattern`, `TraceLevelOverrides`, `TraceToConsole`, `BulkMessageLimit`, `LogConsumers`, etc through it. In 2.0, logging configuration is consistent with ASP.NET Core 2.0 logging, which means most of the configuration is done through `Microsoft.Extensions.Logging.ILoggingBuilder`.

To configure `DefaultTraceLevel` and `TraceLevelOverrides`, you need to apply [log filtering](../../core/extensions/logging.md#how-filtering-rules-are-applied) to `ILoggingBuilder`. For example, to set the 'Trace' level to 'Debug' on Orleans runtime, you can use the following code:

```csharp
siloBuilder.AddLogging(builder => builder.AddFilter("Orleans", LogLevel.Debug));
```

You can configure the log level for your application code in the same way. If you want to set a default minimum level to be 'Debug', use the following code:

```csharp
siloBuilder.AddLogging(builder => builder.SetMinimumLevel(LogLevel.Debug);
```

For more information, see [Apply log filter rules in code](../../core/extensions/logging.md#apply-log-filter-rules-in-code).

To configure `TraceToConsole` to be `true`, you need to reference `Microsoft.Extensions.Logging.Console` package and then use <xref:Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddConsole%2A> extension method on <xref:Microsoft.Extensions.Logging.ILoggingBuilder>`ILoggingBuilder`. The same with `TraceFileName` and `TraceFilePattern`, if you want to log messages to a file, you need to use `AddFile("file name")` method on `ILoggingBuilder`.

If you still want to use the _message bulking_ feature, you need to configure it through `ILoggingBuilder` as well. The message bulking feature lives in `Microsoft.Orleans.Logging.Legacy` package. So you need to add a dependency on that package first. And then configure it through `ILoggingBuilder`. Consider the following example of how to configure it with <xref:Orleans.Hosting.ISiloHostBuilder>:

```csharp
siloBuilder.AddLogging(
    builder =>
    builder.AddMessageBulkingLoggerProvider(
        new FileLoggerProvider("mylog.log")));
```

This method would apply the _message bulking_ feature to the `FileLoggerProvider`, with default bulking config.

Since we are going to eventually deprecate and remove LogConsumer feature support in the future, we highly encourage you to migrate off this feature as soon as possible. There are a couple of approaches you can take to migrate off. One option is to maintain your own <xref:Microsoft.Extensions.Logging.ILoggerProvider>, which creates <xref:Microsoft.Extensions.Logging.ILogger> who logs to all your existing log consumers. This is very similar to what we are doing in `Microsoft.Orleans.Logging.Legacy` package. You can take a look at `LegacyOrleansLoggerProvider` and borrow logic from it. Another option is to replace your `ILogConsumer` with the existing implementation of `ILoggerProvider` on NuGet which provides identical or similar functionality or implement your own `ILoggerProvider` which fits your specific logging requirement. And configure those `ILoggerProvider`s with `ILoggingBuilder`.

But if you cannot migrate away from the log consumer in the short term, you can still use it. The support for `ILogConsumer` lives in `Microsoft.Orleans.Logging.Legacy` package. So you need to add a dependency on that package first, and then configure Log consumers through the extension method `AddLegacyOrleansLogging` on `ILoggingBuilder`. There's a native `AddLogging` method on <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection> provided by .NET for you to configure <xref:Microsoft.Extensions.Logging.ILoggingBuilder>. We also wrap that method under the extension method on `ISiloHostBuilder` and `IClientBuilder`. So you can call `AddLogging` method on silo builder and client builder as well to configure `ILoggingBuilder`.

Consider the following example:

```csharp
var severityOverrides = new OrleansLoggerSeverityOverrides();
severityOverrides.LoggerSeverityOverrides.Add(
    typeof(MyType).FullName, Severity.Warning);

siloBuilder.AddLogging(
    builder => builder.AddLegacyOrleansLogging(new List<ILogConsumer>
    {
        new LegacyFileLogConsumer($"{this.GetType().Name}.log")
    },
    severityOverrides));
```

You can use this feature if you invested in a custom implementation of `ILogConsumer` and cannot convert them to the implementation of `ILoggerProvider` in the short term.

`Logger GetLogger(string loggerName)` method on `Grain` base class and `IProviderRuntime`, and `Logger Log { get; }` method on `IStorageProvider` are still maintained as a deprecated feature in 2.0. You can still use it in your process of migrating off Orleans legacy logging. But we recommend you migrate off them as soon as possible.

## Provider configuration

In Orleans 2.0, the configuration of the included providers has been standardized to obtain service id and cluster id from the `ClusterOptions` configured for the silo or client.

service id is a stable identifier of the service or application that the cluster represents. service id does not change between deployments and upgrades of clusters that implement the service over time.

Unlike service id, cluster id stays the same only through the lifecycle of a cluster of silos. If a running cluster gets shut down, and a new cluster for the same service gets deployed, the new cluster will have a new and unique cluster id but will maintain the service id of the old cluster.

service id is often used as part of a key for persisting data that needs to have continuity throughout the life of the service. Examples are grain states, reminders, and queues of persistent streams. On the other hand, data within a cluster membership table only makes sense within the scope of its cluster, and hence is normally keyed off cluster id.

Before 2.0, the behavior of Orleans providers was sometimes inconsistent with regards to using service id and cluster id (that was also previously called Deployment ID). Because of these unification's and the overall change of provider configuration API, data written to storage by some providers may change location or key. An example of a provider that is sensitive to this change is the Azure Queue stream provider.

If you are migrating an existing service from 1.x to 2.0, and need to maintain backward compatibility with regards to location or keys of data persisted by the providers you are using in the service, please verify that the data will be where your service or provider expects it to be. If your service happen to depend on the incorrect usage of service id and cluster id by a 1.x provider, you can override `ClusterOptions` for that specific provider by calling `ISiloHostBuilder.AddProviderClusterOptions()` or `IClientBuilder.AddProviderClusterOptions()` and force it to read/write data from/to the 1.x location in storage
