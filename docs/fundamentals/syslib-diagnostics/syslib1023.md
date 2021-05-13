---
title: SYSLIB1023 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1023.
ms.date: 05/07/2021
---

# SYSLIB1023: Generating more than six arguments is not supported

The `LoggerMessageAttribute` is limited to the number of parameters supported by `LoggerMessage.Define`, which is six.

## Workarounds

Rather than using `LoggerMessageAttribute`, consider implementing a custom attribute using a struct.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
