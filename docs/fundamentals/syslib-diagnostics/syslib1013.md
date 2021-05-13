---
title: SYSLIB1013 warning
description: Learn about the diagnostic that generates compile-time warning SYSLIB1013.
ms.date: 05/07/2021
---

# SYSLIB1013: Don't include exception parameters as templates in the logging message

The first exception argument to a logging method is referenced as a template in the logging message. This isn't necessary, because the first exception is passed down to the logging infrastructure explicitly. It doesn't need to be repeated in the logging message.

## Workarounds

Remove the template that references the exception argument from the logging message.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
