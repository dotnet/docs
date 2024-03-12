---
title: SYSLIB1039 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1039.
ms.date: 10/26/2023
f1_keywords:
  - syslib1039
---

# SYSLIB1039: JsonSourceGenerator encountered a `JsonDerivedTypeAttribute` annotation with `JsonSourceGenerationMode.Serialization` enabled

<xref:System.Text.Json.Serialization.JsonDerivedTypeAttribute> annotations are supported for source generation, but not for contexts that are annotated with <xref:System.Text.Json.Serialization.JsonSourceGenerationMode.Serialization?displayProperty=nameWithType>. That is, the attribute works with the metadata source generator, but not in fast-path methods.

## Workarounds

Remove the attribute, or remove the <xref:System.Text.Json.Serialization.JsonSourceGenerationMode.Serialization?displayProperty=nameWithType> annotation from your serialization context.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
