---
title: Microsoft.Testing.Platform (MTP) Microsoft.Extensions integration
description: Learn about the MTP extensions that bridge Microsoft.Testing.Platform to the Microsoft.Extensions.* libraries your application already uses.
author: evangelink
ms.author: amauryleve
ms.date: 10/01/2026
ai-usage: ai-assisted
---

# Microsoft.Extensions integration

These extensions bridge Microsoft.Testing.Platform (MTP) to the `Microsoft.Extensions.*` libraries your application already uses, so platform and extension components flow through the same infrastructure as the rest of your code. Each extension requires an additional NuGet package, as described in each section.

> [!TIP]
> When using [Microsoft.Testing.Platform.MSBuild](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild), the logging package is auto-registered with a generated entry point. The configuration package requires an `IConfiguration` instance, and the hosting package requires either `TestingPlatformHostFactory` or a custom entry point, so follow their registration sections.

## Logging bridge

The logging bridge forwards Microsoft.Testing.Platform diagnostic logs to <xref:Microsoft.Extensions.Logging.ILogger>, so platform and extension logs flow through the same `Microsoft.Extensions.Logging` pipeline your application already uses. You can reuse an existing logging stack — Console, Debug, Serilog, Application Insights, OpenTelemetry, or a custom `ILoggerProvider` — without writing a custom MTP logger provider. This extension requires the [Microsoft.Testing.Extensions.Logging](https://nuget.org/packages/Microsoft.Testing.Extensions.Logging) NuGet package.

> [!NOTE]
> Available in MTP starting with version 2.3.0. This extension is experimental, and its options and output format might change in a future version.

The bridge forwards each message only when the platform's diagnostic logging is enabled. When the platform's effective log level is `None` (the default, unless you pass [`--diagnostic`](microsoft-testing-platform-cli-options.md)), the configuration delegate isn't invoked and no logger factory is created. Per-category filters that you set in the `ILoggingBuilder` can narrow the platform's effective diagnostic level, but they can't widen it.

### Manual registration

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);
builder.AddMicrosoftExtensionsLogging(logging => logging.AddConsole());
```

## Configuration snapshot

The experimental [`Microsoft.Testing.Extensions.Configuration`](https://github.com/microsoft/testfx/tree/main/src/Platform/Microsoft.Testing.Extensions.Configuration) package adds a read-only snapshot of an application-owned <xref:Microsoft.Extensions.Configuration.IConfiguration> to MTP's configuration pipeline.

Register the configuration before you build the test application:

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);
builder.AddMicrosoftExtensionsConfigurationSnapshot(configuration);
```

By default, the snapshot uses order `2`. MTP command-line values (order `0`) and environment variables (order `1`) take precedence, while the snapshot takes precedence over *testconfig.json* (order `3`). Pass a different order when your application requires another precedence.

MTP reads the snapshot when `BuildAsync` builds the configuration pipeline. Later changes and reload notifications don't propagate. The caller retains ownership of the configuration, hierarchical keys keep the standard `:` delimiter, and registration applies only to the current process. A live configuration object doesn't cross into a separately launched controller or test host process.

## Host integration

The experimental [`Microsoft.Testing.Extensions.Hosting`](https://github.com/microsoft/testfx/tree/main/src/Platform/Microsoft.Testing.Extensions.Hosting) package runs MTP inside an application-owned <xref:Microsoft.Extensions.Hosting.IHost>. The host remains the composition root and owns its service provider, configuration, logging, OpenTelemetry providers, lifetime, and disposal.

For a generated entry point, set `TestingPlatformHostFactory` to a fully qualified static method that returns a fresh, unstarted `Task<IHost>`:

```xml
<TestingPlatformHostFactory>Contoso.Tests.TestHost.CreateHost</TestingPlatformHostFactory>
```

Set `TestingPlatformOpenTelemetryMode` to `HostOwned` when the host owns OpenTelemetry providers and the test project references `Microsoft.Testing.Extensions.OpenTelemetry`. The generated entry point creates and disposes the host, preserves self-registered extensions, and bypasses the factory for command-line `--help` and `--info`.

For a custom entry point, call `RunTestingPlatformAsync` on the host and register the test framework through its callback. The method imports a configuration snapshot, forwards MTP diagnostics to the host's `ILoggerFactory`, starts the host before MTP, links host and caller cancellation to MTP, returns the MTP exit code, and stops the host in a `finally` block. The caller still disposes the host.

Keep standard output free of host startup, shutdown, logging, and exporter messages because MTP uses it for machine-readable modes such as `--list-tests json`, JSON-RPC server mode, and the `dotnet test` protocol. Also avoid exclusive global resources in a host factory used with process-restart extensions, because retry, crash dump, or hang dump scenarios might invoke the factory in controller and child processes.

> [!IMPORTANT]
> The configuration and hosting APIs use the `TPEXP` diagnostic ID and might change in a future release. They are available in MTP 2.5 preview packages.
