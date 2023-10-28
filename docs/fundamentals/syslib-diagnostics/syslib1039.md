---
title: SYSLIB1039 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1039.
ms.date: 10/26/2023
---

# SYSLIB1039: JsonSourceGenerator encountered a `JsonDerivedTypeAttribute` annotation with `JsonSourceGenerationMode.Serialization` enabled

<xref:System.Text.Json.Serialization.JsonDerivedTypeAttribute> is not supported in source-generation mode.

## Workarounds

Use reflection mode for serialization instead, or remove the attribute.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
