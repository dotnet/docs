---
title: Logging guidance for .NET library authors
author: IEvangelist
description: Learn how to expose logging as a library author in .NET. Follow the guidance to ensure your library is correctly exposed to consumers.
ms.author: dapine
ms.date: 08/08/2023
---

# Logging guidance for .NET library authors

As a library author, exposing logging is a great way to provide consumers with insight into the inner workings of your library. This guidance helps you expose logging in a way that is consistent with other .NET libraries and frameworks. It also helps you avoid common performance bottlenecks that may not be otherwise obvious.

## When to use the `ILoggerFactory` interface

When writing a library that emits logs, you need an <xref:Microsoft.Extensions.Logging.ILogger> object to record the logs. To get that object your API can either accept an <xref:Microsoft.Extensions.Logging.ILogger%601> parameter, or it can accept an <xref:Microsoft.Extensions.Logging.ILoggerFactory> after which you call <xref:Microsoft.Extensions.Logging.ILoggerFactory.CreateLogger%2A?displayProperty=nameWithType>. Which approach should be preferred?

- When you need a logging object that can be passed along to multiple classes so that all of them can emit logs, use `ILoggerFactory`. It's recommended that each class creates logs with a separate category, named the same as the class. To do this, you need the factory to create unique `ILogger<TCategoryName>` objects for each class that is emitting logs. Common examples include public entry point APIs for a library or public constructors of types that internally may create helper classes.

- When you need a logging object that's only used inside one class and never shared, use `ILogger<TCategoryName>` where `TCategoryName` is the type that is producing the logs. A common example of this is a constructor for a class created by dependency injection.

If you're designing a public API that must remain stable over time, keep in mind that you might desire to refactor your internal implementation in the future. Even if a class doesn't create any internal helper types initially, that might change as the code evolves. Using `ILoggerFactory` accommodates creating new `ILogger<TCategoryName>` objects for any new classes without changing the public API.

For more information, see [How filtering rules are applied](logging.md#how-filtering-rules-are-applied).

## Prefer source-generated logging

Depending on your library's performance requirements, you may consider using the built-in source generator to generate [high-performance logging code](high-performance-logging.md). Imagine that your library logs informational messages about fictitious products being sold, you might write the following code:

```csharp
_logger.LogInformation(
    "Sold {quantity} units of {description}",
    7, "Widgets");
```

This code seems like a natural way to log this information. However, it has a few drawbacks:

- The `LogInformation` extension method is called even if the `Information` log level isn't enabled.
- The quantity value `7` is boxed into an `object`.
- The boxed quantity and description are allocated into an `object[]` to satisfy the `params` keyword.

These allocations can be avoided when logging is disabled, but that requires a guard to check if the `Information` log level is enabled:

```csharp
if (_logger.IsEnabled(LogLevel.Information))
{
    _logger.LogInformation(
        "Sold {quantity} units of {description}",
        7, "Widgets");
}
```

In situations like these, the guard prevents the allocations. All of the following extension methods have similar concerns:

- <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogCritical%2A?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogDebug%2A?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogError%2A?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogInformation%2A?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogTrace%2A?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogWarning%2A?displayProperty=nameWithType>

It's easy to forget to add the `IsEnabled` guard and it becomes repetitive. Instead, use the <xref:Microsoft.Extensions.Logging.LoggerMessageAttribute> to automatically apply the appropriate guards, calling <xref:Microsoft.Extensions.Logging.ILogger.IsEnabled%2A?displayProperty=nameWithType> with the correct <xref:Microsoft.Extensions.Logging.LogLevel>. When you use the `LoggerMessage` attribute, it ensures that the logging code is only executed if the corresponding `LogLevel` is enabled. Consider the following code:

:::code source="snippets/logging/library-authors/LogMessages.cs":::

The preceding code:

- Defines a `partial class` named `LogMessages`, which is `static` so that it can be used to define extension methods on the `ILogger` type.
- Decorates a `LogProductSaleDetails` extension method with the `LoggerMessage` attribute and `Message` template.
- The `LogProductSaleDetails` accepts an `ILogger`, the `quantity`, `description`, and `logLevel` values.

> [!TIP]
> The source generated code can be stepped into during debugging, as it's part of the same assembly as the code that calls it.

### Expensive parameter evaluation considerations

There may be situations where evaluating parameters is expensive. Expanding upon the previous example, imagine the `description` parameter is a `string` that is expensive to compute. Perhaps the product being sold gets a friendly product description and relies on a database query, or reading from a file. In these situations, you can instruct the source generator to skip the `IsEnabled` guard and manually add the `IsEnabled` guard at the call site. This allows the user to determine where the guard is called and ensures that parameters that might be expensive to compute are only evaluated when truly needed. Consider the following code:

```csharp
using Microsoft.Extensions.Logging;

namespace Logging.LibraryAuthors;

internal static partial class LogMessages
{
    [LoggerMessage(
        Message = "Sold {quantity} of {description}",
        SkipEnabledCheck = true)]
    internal static partial void LogProductSaleDetails(
        this ILogger logger,
        int quantity,
        string description,
        LogLevel logLevel = LogLevel.Information);
}
```

When the `LogProductSaleDetails` extension method is called, the `IsEnabled` guard is manually invoked and the expensive parameter evaluation is limited to when it's needed. Consider the following code:

```csharp
if (_logger.IsEnabled(LogLevel.Information))
{
    // Expensive parameter evaluation
    var description = product.GetFriendlyProductDescription();

    _logger.LogProductSaleDetails(
        quantity,
        description);
}
```

For more information, see [Compile-time logging source generation](logger-message-generator.md) and [High-performance logging in .NET](high-performance-logging.md).

## Avoid string interpolation in logging

A common mistake is to use [string interpolation](../../csharp/tutorials/string-interpolation.md) to build log messages. String interpolation in logging is problematic for performance, as the string is evaluated even if the corresponding `LogLevel` isn't enabled. Instead of string interpolation, use the log message template, formatting, and argument list. For more information, see [Logging in .NET: Log message template](logging.md#log-message-template).

## Use no-op logging defaults

Libraries can default to _null logging_ if no `ILoggerFactory` is provided. The use of _null logging_ differs from defining types as nullable (`ILoggerFactory?`), as the types are non-null. These convenience-based types don't log anything and are essentially no-ops. Consider using any of the available abstraction types where applicable:

- <xref:Microsoft.Extensions.Logging.Abstractions.NullLogger.Instance?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Logging.Abstractions.NullLoggerFactory.Instance?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Logging.Abstractions.NullLoggerProvider.Instance?displayProperty=nameWithType>
