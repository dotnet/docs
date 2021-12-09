---
title: SYSLIB1037 warning
description: Learn about the diagnostic that generates compile-time warning SYSLIB1037.
ms.date: 05/07/2021
---

# SYSLIB1037: `System.Text.Json` source generator encountered a type with init-only properties which are not supported for deserialization

The `System.Text.Json` source generator encountered a type with init-only properties, such as a record type. These properties are currently not supported by the source generator for deserialization.

## Workarounds

If deserialization of init-only properties is required, use the [reflection-based `JsonSerializer` implementation](../../standard/serialization/system-text-json-source-generation-modes.md).

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
