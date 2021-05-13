---
title: SYSLIB1011 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1011.
ms.date: 05/07/2021
---

# SYSLIB1011: Logging methods cannot be generic

A method annotated with the `LoggerMessageAttribute` contains parameters with generic types.

## Workarounds

Logging methods cannot have any generically typed parameters. Use fully resolved types instead.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
