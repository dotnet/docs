---
title: SYSLIB1008 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1008.
ms.date: 05/07/2021
---

# SYSLIB1008: One of the arguments to a logging method must implement the `ILogger` interface

One of the parameters of a method annotated with the `LoggerMessageAttribute` must be of the type `ILogger` or a type
that implements `ILogger`.

## Workarounds

Ensure that a parameter of all logging methods is of type `ILogger` or of a type that
implements `ILogger`.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
