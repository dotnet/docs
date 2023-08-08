---
title: Logging guidance for .NET library authors
author: IEvangelist
description: Learn how to expose logging as a library author in .NET. Follow the guidance to ensure your library is correctly exposed to consumers.
ms.author: dapine
ms.date: 08/08/2023
---

# Logging guidance for .NET library authors

As a library author, exposing logging is a great way to provide consumers with insight into the inner workings of your library. This guidance helps you expose logging in a way that is consistent with other .NET libraries and frameworks.

## When to use the `ILoggerFactory` interface

When writing a library that emits logs, you will need an <xref:Microsoft.Extensions.Logging.ILogger> object to record the logs. To get that object your API can either accept an <xref:Microsoft.Extensions.Logging.ILogger%601> parameter, or it can accept an <xref:Microsoft.Extensions.Logging.ILoggerFactory> after which you call <xref:Microsoft.Extensions.Logging.ILoggerFactory.CreateLogger%2A?displayProperty=nameWithType>. Which approach should be preferred?

- If you need a logging object that can be passed along to multiple classes so that all of them can emit logs, use `ILoggerFactory`. It is recommended that each class create logs with a separate category, named the same as the class name. To do this you will need the factory to create unique `ILogger<T>` objects for each class that is emitting logs. Common examples of this would be public entry point APIs for a library or public constructors of types that internally may create helper classes.

- If you need a logging object that will only be used inside one class and never shared use `ILogger<T>` where `T` is the type that will be producing the logs. A common example of this is a constructor for a class created by dependency injection.

If you are designing a public API that must remain stable over time, keep in mind that you might desire to refactor your internal implementation in the future. Even if a class doesn't create any internal helper types initially, that might change as the code evolves. Using `ILoggerFactory` will accommodate creating new `ILogger<T>` objects for any new classes without changing the public API.

### Default with null logging

Libraries can default to _null logging_ if no `ILoggerFactory` is provided. The use of _null logging_ differs from defining types as nullable (`ILoggerFactory?`), as the types are non-null. These convenience-based types don't log anything and are essentially no-ops. Consider using any of the available abstraction types where applicable:

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

Depending on your library's performance requirements, you may want to consider using the built-in source generator to generate [high-performance logging code](high-performance-logging.md). Imagine that your library logs informational messages about fictitious products being sold, you might write the following code:

```csharp
_logger.LogInformation(
    "Sold {quantity} units of {description}",
    7, product.GetFriendlyProductDescription());
```

This code might feel very natural to write. However, it has a few drawbacks:

- The `LogInformation` method is called even if the `Information` log level isn't enabled.
- The quantity value of `7` is boxed into an `object`.
- The `GetFriendlyProductDescription` method is called, evaluating the `string` argument.
- The boxed quantity and description are allocated into an `object[]` to satisfy `params`.

These allocations may or may not be acceptable for your library. All of the following extension methods have similar considerations:

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
