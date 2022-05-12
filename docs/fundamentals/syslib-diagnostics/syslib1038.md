---
title: SYSLIB1038 warning
description: Learn about the diagnostic that generates compile-time warning SYSLIB1038.
ms.date: 05/07/2021
---

# SYSLIB1038: `System.Text.Json` source generator encountered a property annotated with `[JsonInclude]` but with inaccessible accessors

The `System.Text.Json` source generator encountered a property that is annotated with `[JsonInclude]` but has accessors that are inaccessible to the source generator. The property must have `public` or `internal` accessors.

## Workarounds

If serialization or deserialization of properties with accessors that are not `public` or `internal` is required, use the [reflection-based `JsonSerializer` implementation](../../standard/serialization/system-text-json-source-generation-modes.md).

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
