---
title: Logging guidance for .NET library authors
author: IEvangelist
description: Learn how to expose logging as a library author in .NET. Follow the guidance to ensure your library is correctly exposed to consumers.
ms.author: dapine
ms.date: 08/02/2023
---

# Logging guidance for .NET library authors

As a library author, exposing logging is a great way to provide consumers with insight into the inner workings of your library. This guidance will help you expose logging in a way that is consistent with other .NET libraries and frameworks.

## Use the `ILoggerFactory` interface

When exposing configuration functionality in your library, it may be tempting to accept an <xref:Microsoft.Extensions.Logging.ILogger>, but that isn't recommended. Instead, you should accept an <xref:Microsoft.Extensions.Logging.ILoggerFactory> and use it to create an <xref:Microsoft.Extensions.Logging.ILogger> instance. This ensures that the logging configuration is consistent with the rest of the app and is more flexible.

## Prefer source-generated logging

Wherever your library code relies on logging APIs, for example, the `ILogger` interface, consider using source-generated logging where possible. As a general rule, when calling any of the following extension methods you should ensure that the corresponding `LogLevel` is enabled:

- <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogCritical%2A>
- <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogDebug%2A>
- <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogError%2A>
- <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogInformation%2A>
- <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogTrace%2A>
- <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogWarning%2A>

Use the <xref:Microsoft.Extensions.Logging.LoggerMessageAttribute> to automatically apply the appropriate guards, calling <xref:Microsoft.Extensions.Logging.ILogger.IsEnabled%2A?displayProperty=nameWithType> with the correct <xref:Microsoft.Extensions.Logging.LogLevel>. This ensures that the logging code is only executed if the corresponding `LogLevel` is enabled.

Additionally, the `LoggerMessageAttribute` avoids the need to use reflection at runtime, which can be a significant performance improvement.

For more information, see [Compile-time logging source generation](logger-message-generator.md) and [High-performance logging in .NET](high-performance-logging.md).

## Avoid string interpolation

A very common mistake is to use [string interpolation](../../csharp/tutorials/string-interpolation.md) to build the log message. This is problematic as string interpolation is evaluated even if the corresponding `LogLevel` isn't enabled. This can lead to unnecessary allocations and performance issues.

Instead, developers should use the log message template. For more information, see [Logging in .NET: Log message template](logging.md#log-message-template).
