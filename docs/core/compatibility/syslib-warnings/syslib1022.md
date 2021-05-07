---
title: SYSLIB1022 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1022.
ms.topic: reference
ms.date: 05/07/2021
---
# SYSLIB1022: Can't have malformed format strings (like dangling curly braces, etc.)

A method annotated with the `LoggerMessageAttribute` attribute cannot have message templates formed incorrectly.

## Workarounds

Makes sure curly braces are used appropriately in the message template.