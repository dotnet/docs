---
title: SYSLIB1033 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1033.
ms.date: 05/07/2021
---

# SYSLIB1033: `System.Text.Json` source generator encountered a type with multiple `[JsonConstructor]` annotations

The `System.Text.Json` source generator encountered a serializable type with multiple `[JsonConstructor]` annotations.

## Workarounds

Remove duplicate `[JsonConstructor]` annotations.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
