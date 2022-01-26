---
title: SYSLIB1030 warning
description: Learn about the diagnostic that generates compile-time warning SYSLIB1030.
ms.date: 05/07/2021
---

# SYSLIB1030: `System.Text.Json` source generator did not generate output for type

The `System.Text.Json` source generator did not generate output for a given type in the input object graph. This typically means that the type is not supported by `JsonSerializer`, for example multi-dimensional arrays like `int[,]`.

## Workarounds

Register a [custom converter](../../standard/serialization/system-text-json-converters-how-to.md) for the type.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
