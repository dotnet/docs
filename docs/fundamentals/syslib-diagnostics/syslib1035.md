---
title: SYSLIB1035 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1035.
ms.date: 05/07/2021
---

# SYSLIB1035: `System.Text.Json` source generator encountered a type with multiple `[JsonExtensionData]` annotations

The `System.Text.Json` source generator encountered a serializable type with multiple `[JsonExtensionData]` annotations.

## Workarounds

Remove duplicate `[JsonExtensionData]` annotations.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
