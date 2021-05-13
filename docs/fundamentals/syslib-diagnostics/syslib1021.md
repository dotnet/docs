---
title: SYSLIB1021 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1021.
ms.date: 05/07/2021
---

# SYSLIB1021: Can't have the same template placeholders with different casing

A method annotated with the `LoggerMessageAttribute` attribute has multiple template placeholders that differ only by case.

## Workarounds

Make sure the message-template placeholders aren't repeated with different casing in the method annotated with `LoggerMessageAttribute`.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
