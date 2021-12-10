---
title: SYSLIB1032 error
description: Learn about the diagnostic that generates compile-time warning SYSLIB1032.
ms.date: 05/07/2021
---

# SYSLIB1032: Context classes to be augmented by the `System.Text.Json` source generator must be declared as partial

The `System.Text.Json` source generator encountered a context type included for source generation that is not partial, or whose containing type(s) is not partial.

## Workarounds

Make the context type and all containing types partial.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
