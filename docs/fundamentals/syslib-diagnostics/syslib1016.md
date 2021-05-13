---
title: SYSLIB1016 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1016.
ms.date: 05/07/2021
---

# SYSLIB1016: Logging methods cannot have a body

The `LoggerMessageAttribute` attribute was applied to a method that has a method body.

## Workarounds

Remove the method body.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
