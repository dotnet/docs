---
title: SYSLIB1019 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1019.
ms.date: 05/07/2021
f1_keywords:
  - syslib1019
---

# SYSLIB1019: Couldn't find a field of type `ILogger`

When a logging method definition doesn't explicitly include a parameter of type `ILogger`, then the type containing the logging method must have one and only one field of type `ILogger`. The `ILogger` will be used as the target for log messages.

## Workarounds

Ensure the type containing the logging method includes a field of type `ILogger` or include a parameter of type `ILogger` in the logging method signature.

### Primary Constructors

Smallest possible edit to workaround [Dotnet Runtime Issue 91121 - LoggerMessage source generator does not work with logger from primary constructor](https://github.com/dotnet/runtime/issues/91121):

```
public partial class Foo(ILogger<Foo> logger) {
    // workaround for https://github.com/dotnet/runtime/issues/91121
    private readonly ILogger _logger = logger;
}
```

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
