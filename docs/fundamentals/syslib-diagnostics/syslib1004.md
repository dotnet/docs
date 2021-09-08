---
title: SYSLIB1004 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1004.
ms.date: 05/07/2021
---

# SYSLIB1004: Logging class cannot be in a nested type

A method annotated with the `LoggerMessageAttribute` is contained in a nested type. This is not currently supported by the logging model.

## Workarounds

It's customary to have logging methods declared in a top-level, static class called `Log`. This pattern eliminates issues with nested types.

For example:

```csharp
namespace MyService
{
    internal static partial class Log
    {
        [LoggerMessage(
            EventId = 0,
            Level = LogLevel.Critical,
            Message = "Could not open socket to `{hostName}`")]
        public static partial void CouldNotOpenSocket(
            ILogger logger, string hostName);
    }
}
```

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
