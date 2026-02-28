---
title: SYSLIB1011 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1011.
ms.date: 02/23/2026
f1_keywords:
  - syslib1011
---

# SYSLIB1011: Logging methods cannot use the `allows ref struct` constraint

A method annotated with `LoggerMessageAttribute` uses the C# 13 `allows ref struct` anti-constraint on a type parameter. The logging source generator stores parameters in struct fields, so it can't hold ref struct type arguments.

## Workarounds

Logging methods support generic type parameters and most constraint forms (`class`, `struct`, `unmanaged`, `notnull`, base types, interfaces, and `new()`). Remove the `allows ref struct` anti-constraint from the type parameter to resolve this error.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
