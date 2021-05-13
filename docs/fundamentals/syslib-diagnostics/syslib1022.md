---
title: SYSLIB1022 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1022.
ms.date: 05/07/2021
---

# SYSLIB1022: Can't have malformed format strings

A method annotated with the `LoggerMessageAttribute` attribute has a message template that's formatted incorrectly. For example, the template has an unmatched curly brace (`}`).

## Workarounds

Makes sure curly braces are used appropriately in the message template.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
