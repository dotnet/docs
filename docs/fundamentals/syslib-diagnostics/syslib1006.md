---
title: SYSLIB1006 warning
description: Learn about the diagnostic that generates compile-time warning SYSLIB1006.
ms.date: 05/07/2021
---

# SYSLIB1006: Multiple logging methods cannot use the same event ID

Multiple methods annotated with the `LoggerMessageAttribute` are using the same event ID value. Event ID values must be unique within the scope of each assembly.

## Workarounds

Review the event ID values used for all logging methods in the assembly and ensure they are unique.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
