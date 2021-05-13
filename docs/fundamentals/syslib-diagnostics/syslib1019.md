---
title: SYSLIB1019 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1019.
ms.date: 05/07/2021
---

# SYSLIB1019: Couldn't find a field of type `ILogger`

When a logging method definition doesn't explicitly include a parameter of type `ILogger`, then the type containing the logging method must have one and only one field of type `ILogger`. The `ILogger` will be used as the target for log messages.

## Workarounds

Ensure the type containing the logging method includes a field of type `ILogger` or include a parameter of type `ILogger` in the logging method signature.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
