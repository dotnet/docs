---
title: SYSLIB1031 warning
description: Learn about the diagnostic that generates compile-time warning SYSLIB1031.
ms.date: 05/07/2021
---

# SYSLIB1031: `System.Text.Json` source generator encountered a duplicate type info property name

The `System.Text.Json` source generator encountered a duplicate type info property name to be generated on the specified partial context type.

## Workarounds

Specify a new type info property name for the duplicate instance using `System.Text.Json.Serialization.JsonSerializableAttribute.TypeInfoPropertyName`.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
