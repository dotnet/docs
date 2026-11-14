---
title: SYSLIB1009 warning
description: Learn about the diagnostic that generates compile-time warning SYSLIB1009.
ms.date: 11/01/2026
f1_keywords:
  - syslib1009
---

# SYSLIB1009: Logging methods must be static

The compile-time diagnostic SYSLIB1009 is emitted when a method annotated with <xref:Microsoft.Extensions.Logging.LoggerMessageAttribute> is not declared as `static` in an environment where instance logging methods are not supported (such as projects targeting .NET 6), or where the containing type does not expose an accessible logger instance.

## Cause

In .NET 6, the logging source generator required all methods decorated with `LoggerMessageAttribute` to be declared as `static`. If a decorated method was declared as an instance method, the compiler generated warning SYSLIB1009.

Starting in .NET 7, the logging source generator added support for instance logging methods. However, if the containing type does not provide an accessible `ILogger` instance or if the project targets .NET 6, SYSLIB1009 is reported.

## Workarounds

To resolve SYSLIB1009:

- Declare the logging method as `static partial` and include an `ILogger` instance as one of the method parameters:

  ```csharp
  [LoggerMessage(EventId = 1, Level = LogLevel.Information, Message = "Processing item {Name}")]
  public static partial void LogProcessingItem(ILogger logger, string name);
  ```

- Alternatively, if you are targeting .NET 7 or later, declare the method as an instance `partial` method on a `partial` class that provides an accessible `ILogger` field, property, or primary constructor parameter:

  ```csharp
  public partial class MyService
  {
      private readonly ILogger<MyService> _logger;

      public MyService(ILogger<MyService> logger)
      {
          _logger = logger;
      }

      [LoggerMessage(EventId = 1, Level = LogLevel.Information, Message = "Processing item {Name}")]
      public partial void LogProcessingItem(string name);
  }
  ```

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]

## See also

- [Compile-time logging source generation](../../core/extensions/logging/source-generation.md)
