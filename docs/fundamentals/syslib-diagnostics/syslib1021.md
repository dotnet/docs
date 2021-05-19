---
title: SYSLIB1021 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1021.
ms.date: 05/07/2021
---

# SYSLIB1021: Multiple message-template item names differ only by case

A method annotated with the `LoggerMessageAttribute` attribute has multiple template item names that differ only by case.

## Workarounds

Make sure the message-template item names aren't repeated with different casing in the method annotated with `LoggerMessageAttribute`.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
