---
title: SYSLIB1027 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1027.
ms.date: 11/07/2025
f1_keywords:
  - SYSLIB1027
---

# SYSLIB1027: Primary constructor parameter of type 'Microsoft.Extensions.Logging.ILogger' is hidden by a field

A class has a primary constructor parameter of type <xref:Microsoft.Extensions.Logging.ILogger> that's hidden by a field in the class or a base class, which prevents its use.

For example, the following class raises the `SYSLIB1027` diagnostic:

```csharp
partial class C(ILogger logger)
{
    private readonly object logger = logger;

    [LoggerMessage(EventId = 0, Level = LogLevel.Debug, Message = "...")]
    public partial void M1();
}
```

## Workarounds

Either remove the field or the primary constructor. For more information, see [Basic usage](../../core/extensions/logger-message-generator.md#basic-usage).

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]

## See also

- [Compile-time logging source generation](../../core/extensions/logger-message-generator.md)
