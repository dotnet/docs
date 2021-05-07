---
title: SYSLIB1023 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1023.
ms.topic: reference
ms.date: 05/07/2021
---
# SYSLIB1023: Generating more than 6 arguments is not supported

The `LoggerMessageAttribute` is limited to the number of parameters supported by `LoggerMessage.Define`.

## Workarounds

Rather than using `LoggerMessageAttribute` you may consider implementing it manually using a custom struct.