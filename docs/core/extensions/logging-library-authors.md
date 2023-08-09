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

The `ILogger` API supports two approaches to using the API. You can either call methods such as <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogError%2A?displayProperty=nameWithType> and <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogInformation%2A?displayProperty=nameWithType>, or you can use the logging source generator to define strongly typed logging methods. For most situations, the source generator is recommended because it offers superior performance and stronger typing. It also isolates logging-specific concerns such as message templates, IDs, and log levels from the calling code. The non-source-generated approach is primarily useful for scenarios where you are willing to give up those advantages to make the code more concise.

:::code source="snippets/logging/library-authors/LogMessages.cs":::

The preceding code:

- Defines a `partial class` named `LogMessages`, which is `static` so that it can be used to define extension methods on the `ILogger` type.
- Decorates a `LogProductSaleDetails` extension method with the `LoggerMessage` attribute and `Message` template.
- The `LogProductSaleDetails` extends the `ILogger` and accepts a `quantity` and `description`.

> [!TIP]
> The source generated code can be stepped into during debugging, as it's part of the same assembly as the code that calls it.

### Use `IsEnabled` to avoid expensive parameter evaluation

There may be situations where evaluating parameters is expensive. Expanding upon the previous example, imagine the `description` parameter is a `string` that is expensive to compute. Perhaps the product being sold gets a friendly product description and relies on a database query, or reading from a file. In these situations, you can instruct the source generator to skip the `IsEnabled` guard and manually add the `IsEnabled` guard at the call site. This allows the user to determine where the guard is called and ensures that parameters that might be expensive to compute are only evaluated when truly needed. Consider the following code:

```csharp
using Microsoft.Extensions.Logging;

namespace Logging.LibraryAuthors;

internal static partial class LogMessages
{
    [LoggerMessage(
        Message = "Sold {quantity} of {description}",
        LogLevel = LogLevel.Information,
        SkipEnabledCheck = true)]
    internal static partial void LogProductSaleDetails(
        this ILogger logger,
        int quantity,
        string description);
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
