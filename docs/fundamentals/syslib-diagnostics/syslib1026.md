---
title: SYSLIB1026 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1026.
ms.date: 11/07/2025
f1_keywords:
  - SYSLIB1026
---

# SYSLIB1026: C# language version not supported by the source generator

The logging source generator generates code using the [nullable](../../csharp/nullable-references.md) feature, which is only supported starting in C# 8.

## Workarounds

Set your C# language version to 8 or later.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
