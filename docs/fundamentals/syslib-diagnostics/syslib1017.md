---
title: SYSLIB1017 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1017.
ms.date: 05/07/2021
---

# SYSLIB1017: A `LogLevel` value must be supplied in the `LoggerMessage` attribute or as a parameter to the logging method

The `LoggerMessageAttribute` attribute was applied to a method without a `LogLevel` value specified. When you do this, one argument to the logging method must be of that type so that the `LogLevel` value ends up being specified explicitly when calling the logging method.

## Workarounds

Either specify a `LogLevel` value in the `LoggerMessage` attribute, or make one of the arguments of the logging method a `LogLevel` value.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
