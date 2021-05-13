---
title: SYSLIB1001 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1001.
ms.date: 05/07/2021
---

# SYSLIB1001: Logging method names can't start with an underscore

The name a of method annotated with the `LoggerMessageAttribute` starts with an underscore character. This is not allowed, as it may result in conflicting symbol names with respect to the automatically generated code.

## Workarounds

Choose a different method name that doesn't start with an underscore.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
