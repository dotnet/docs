---
title: SYSLIB1003 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1003.
ms.topic: reference
ms.date: 05/07/2021
---
# SYSLIB1003: Logging method parameter names can't start with an underscore

The name a of parameter of a method annotated with the `LoggerMessageAttribute` starts with an underscore character. This is not allowed as it may result in conflicting symbol names with respect to the automatically generated code.

## Workarounds

Choose a different parameter name which doesn't start with an underscore.