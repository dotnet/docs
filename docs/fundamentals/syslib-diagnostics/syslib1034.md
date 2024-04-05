---
title: SYSLIB1034 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1034.
ms.date: 10/26/2023
f1_keywords:
  - syslib1034
---

# SYSLIB1034: JsonSourceGenerator encountered a [JsonStringEnumConverter] annotation

The non-generic <xref:System.Text.Json.Serialization.JsonStringEnumConverter> requires dynamic code and can't be used with source generation.

## Workarounds

Use <xref:System.Text.Json.Serialization.JsonStringEnumConverter%601> instead, which doesn't require run-time code generation.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
