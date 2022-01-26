---
title: SYSLIB1036 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1036.
ms.date: 05/07/2021
---

# SYSLIB1036: `System.Text.Json` source generator encountered an invalid `[JsonExtensionData]` annotation

The `System.Text.Json` source generator encountered a property or field annotated with `[JsonExtensionData]` but whose data type does not implement `IDictionary<string, JsonElement>`, `IDictionary<string, object>`, `IDictionary<string, JsonNode>`, or `JsonNode`.

## Workarounds

Ensure that the data type for any property or field that is annotated with `[JsonExtensionData]` implements `IDictionary<string, JsonElement>`, `IDictionary<string, object>`, `IDictionary<string, JsonNode>`, or `JsonNode`.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
