---
title: SYSLIB1025 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1025.
ms.date: 11/07/2025
f1_keywords:
  - SYSLIB1025
---

# SYSLIB1025: Multiple logging methods should not use the same event name within a class

Within the scope of a class, log methods annotated with <xref:Microsoft.Extensions.Logging.LoggerMessageAttribute> must use unique event names.

## Workarounds

Use a unique event name.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
