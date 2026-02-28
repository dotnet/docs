---
title: SYSLIB1029 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1029.
ms.date: 02/25/2026
f1_keywords:
  - SYSLIB1029
---

# SYSLIB1029: Logging method parameter is a ref struct

Ref struct types aren't supported as parameters for <xref:Microsoft.Extensions.Logging.LoggerMessageAttribute>-annotated logging methods. The logging source generator stores parameters in struct fields, which can't hold ref struct values.

## Workarounds

Use a non-ref struct type for the parameter.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
