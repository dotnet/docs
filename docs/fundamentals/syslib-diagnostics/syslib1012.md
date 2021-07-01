---
title: SYSLIB1012 warning
description: Learn about the diagnostic that generates compile-time warning SYSLIB1012.
ms.date: 05/07/2021
---

# SYSLIB1012: Redundant qualifier in logging message

The message string of a `LoggerMessageAttribute` attribute contains a prefix such as `INFO:` or `ERROR:`, which is redundant because each logging message has a corresponding log level.

## Workarounds

Remove the prefix from the message string.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
