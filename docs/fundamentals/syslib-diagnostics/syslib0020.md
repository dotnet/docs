---
title: SYSLIB0020 warning
description: Learn about the IgnoreNullValues obsoletion that generates compile-time warning SYSLIB0020.
ms.date: 04/24/2021
---
# SYSLIB0020: IgnoreNullValues is obsolete

The <xref:System.Text.Json.JsonSerializerOptions.IgnoreNullValues?displayProperty=nameWithType> property is marked as obsolete, starting in .NET 6. Using it in code generates warning `SYSLIB0020` at compile time.

## Workarounds

To ignore null values when serializing, set <xref:System.Text.Json.JsonSerializerOptions.DefaultIgnoreCondition> to <xref:System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull?displayProperty=nameWithType>. For more information, see <https://github.com/dotnet/runtime/issues/39152>.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
