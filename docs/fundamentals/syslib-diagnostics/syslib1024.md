---
title: SYSLIB1024 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1024.
ms.date: 11/07/2025
f1_keywords:
  - SYSLIB1024
---

# SYSLIB1024: Argument is using the unsupported 'out' parameter modifier

The `out` parameter modifier isn't supported for <xref:Microsoft.Extensions.Logging.LoggerMessageAttribute>-annotated logging methods.

## Workarounds

Remove the `out` parameter modifier.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
