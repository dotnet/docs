---
title: SYSLIB1002 warning
description: Learn about the diagnostic that generates compile-time warning SYSLIB1002.
ms.date: 05/07/2021
---

# SYSLIB1002: Don't include log level parameters as templates in the logging message

The first log-level argument to a logging method is referenced as a template in the logging message. This is not necessary, since the first log level is passed down to the logging infrastructure explicitly. It doesn't need to be repeated in the logging message.

## Workarounds

Remove the template that references the log-level argument from the logging message.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
