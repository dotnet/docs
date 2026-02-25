---
title: SYSLIB1028 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1028.
ms.date: 02/25/2026
f1_keywords:
  - SYSLIB1028
---

# SYSLIB1028: Argument is using the unsupported 'params' parameter modifier

The `params` parameter modifier isn't supported for <xref:Microsoft.Extensions.Logging.LoggerMessageAttribute>-annotated logging methods.

## Workarounds

Remove the `params` modifier from the parameter.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
