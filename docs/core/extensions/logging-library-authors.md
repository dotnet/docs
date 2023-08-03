---
title: Logging guidance for .NET library authors
author: IEvangelist
description: Learn how to expose logging as a library author in .NET. Follow the guidance to ensure your library is correctly exposed to consumers.
ms.author: dapine
ms.date: 08/03/2023
---

# Logging guidance for .NET library authors

As a library author, exposing logging is a great way to provide consumers with insight into the inner workings of your library. This guidance helps you expose logging in a way that is consistent with other .NET libraries and frameworks.

## Use the `ILoggerFactory` interface

When your library exposes configuration functionality for logging, it might be tempting to accept an <xref:Microsoft.Extensions.Logging.ILogger>, but that isn't recommended as it represents a single category. An <xref:Microsoft.Extensions.Logging.ILogger%601> represents a one-to-one relationship between a category and a type. If your library allows consumers to provide one of these interfaces, it means that you're limiting the consumer to a single category, which may not be appropriate for their use case.

Instead, you should accept an <xref:Microsoft.Extensions.Logging.ILoggerFactory> and use it to create <xref:Microsoft.Extensions.Logging.ILogger%601> instances. Using an `ILoggerFactory` ensures that the logging configuration is consistent with the rest of the app and is more flexible. For more information, see [Log category](logging.md#log-category).

Logging supports filtering only by log level and category, so it's important to use the correct category for each log message. For more information, see [How filtering rules are applied](logging.md#how-filtering-rules-are-applied).

### Create a logger factory

To create an `ILoggerFactory`, use the <xref:Microsoft.Extensions.Logging.LoggerFactory> class. This class is available from the [Microsoft.Extensions.Logging](https://www.nuget.org/packages/Microsoft.Extensions.Logging) NuGet package. The following example shows how to create a logger factory that logs to the console:

```csharp
var factory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
});
```

> [!TIP]
> The <xref:Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddConsole%2A> extension method is available from the [Microsoft.Extensions.Logging.Console](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Console) NuGet package. For more information, see [Logging providers in .NET](logging-providers.md).

### Default with null logging

Libraries can default to _null logging_ if no `ILoggerFactory` is provided. The use of _null logging_ differs from defining types as nullable (`ILoggerFactory?`), as the types are non-null. These convenience-based types don't log anything and are essentially no-ops. Consider using any of the available abstraction types:

- <xref:Microsoft.Extensions.Logging.Abstractions.NullLogger>
- <xref:Microsoft.Extensions.Logging.Abstractions.NullLoggerFactory>
- <xref:Microsoft.Extensions.Logging.Abstractions.NullLoggerProvider>

### Dependency injection-aware libraries

If your library is dependency injection-aware, classes that require logging may accept an <xref:Microsoft.Extensions.Logging.ILogger%601> in the constructor.

:::code source="./snippets/logging/library-authors/DiExampleService.cs":::

For more information, see [.NET dependency injection](dependency-injection.md).

### Dependency injection-oblivious libraries

If your library is dependency injection-oblivious, classes that require logging should use the configured <xref:Microsoft.Extensions.Logging.ILoggerFactory> to resolve <xref:Microsoft.Extensions.Logging.ILogger%601> instances on demand.

:::code source="./snippets/logging/library-authors/NonDiExampleService.cs":::

The preceding code:

- Assigns the `_logger` field in the constructor, using the <xref:Microsoft.Extensions.Logging.Abstractions.NullLoggerFactory>.
- Demonstrates how to statically access the `ILoggerFactory` instance to create an `ILogger<TCategoryName>`.

In this way, the `ExampleService` class uses an `ILogger<TCategoryName>` instance with the correct `TCategoryName`, which is `"ExampleService"`.

## Prefer source-generated logging

Wherever your library code relies on logging APIs, for example, the `ILogger` interface, consider using source-generated logging where possible. As a general rule, when calling any of the following extension methods, you should ensure that the corresponding `LogLevel` is enabled:

- <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogCritical%2A>
- <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogDebug%2A>
- <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogError%2A>
- <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogInformation%2A>
- <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogTrace%2A>
- <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogWarning%2A>

Use the <xref:Microsoft.Extensions.Logging.LoggerMessageAttribute> to automatically apply the appropriate guards, calling <xref:Microsoft.Extensions.Logging.ILogger.IsEnabled%2A?displayProperty=nameWithType> with the correct <xref:Microsoft.Extensions.Logging.LogLevel>. When you use the `LoggerMessage` attribute, it ensures that the logging code is only executed if the corresponding `LogLevel` is enabled.

Additionally, the `LoggerMessage` attribute avoids the need to use reflection at run time, which can be a significant performance improvement.

For more information, see [Compile-time logging source generation](logger-message-generator.md) and [High-performance logging in .NET](high-performance-logging.md).

## Avoid string interpolation

A common mistake is to use [string interpolation](../../csharp/tutorials/string-interpolation.md) to build log messages. String interpolation in logging is problematic for performance, as the string is evaluated even if the corresponding `LogLevel` isn't enabled.

Instead of string interpolation, use the log message template, formatting, and argument list. For more information, see [Logging in .NET: Log message template](logging.md#log-message-template).
