---
title: SYSLIB1021 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1021.
ms.topic: reference
ms.date: 05/07/2021
---
# SYSLIB1021: Can't have the same template with different casing

A method annotated with the `LoggerMessageAttribute` attribute cannot have the same template with different casing in its arguments.

## Workarounds

Make sure the message template arguments don't get repeated with different casing in the method argument annotated with `LoggerMessageAttribute`.