---
title: SYSLIB1018 warning
description: Learn about the diagnostic that generates compile-time warning SYSLIB1018.
ms.date: 05/07/2021
---

# SYSLIB1018: Don't include logger parameters as templates in the logging message

The first logger argument to a logging method is referenced as a template in the logging message. The first logger is passed down to the logging infrastructure explicitly, so it doesn't need to be repeated in the logging message.

## Workarounds

Remove the template that references the logger argument from the logging message.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
