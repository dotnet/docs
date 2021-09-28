---
title: SYSLIB1020 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1020.
ms.date: 05/07/2021
---

# SYSLIB1020: Found multiple fields of type `ILogger`

When a logging method definition doesn't explicitly include a parameter of type `ILogger`, then the type containing the logging method must have one and only one field of type `ILogger`, which will be used as the target for log messages.

## Workarounds

Ensure the type containing the logging method includes only a single field of type `ILogger`.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
