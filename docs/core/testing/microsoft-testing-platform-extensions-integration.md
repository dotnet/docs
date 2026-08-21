---
title: Microsoft.Testing.Platform (MTP) Microsoft.Extensions integration
description: Learn about the MTP extensions that bridge Microsoft.Testing.Platform to the Microsoft.Extensions.* libraries your application already uses.
author: evangelink
ms.author: amauryleve
ms.date: 07/09/2026
ai-usage: ai-assisted
---

# Microsoft.Extensions integration

These extensions bridge Microsoft.Testing.Platform (MTP) to the `Microsoft.Extensions.*` libraries your application already uses, so platform and extension components flow through the same infrastructure as the rest of your code. Each extension requires an additional NuGet package, as described in each section.

> [!TIP]
> When using [Microsoft.Testing.Platform.MSBuild](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild) (included transitively by MSTest, NUnit, and xUnit runners), these extensions are auto-registered when you install their NuGet packages — no code changes needed. The manual registration specified in this article is only required if you disabled the auto-generated entry point by setting `<GenerateTestingPlatformEntryPoint>false</GenerateTestingPlatformEntryPoint>`.

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
