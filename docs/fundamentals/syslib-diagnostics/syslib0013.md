---
title: SYSLIB0013 warning
description: Learn about the EscapeUriString obsoletion that generates compile-time warning SYSLIB0013.
ms.date: 04/24/2021
---
# SYSLIB0013: EscapeUriString is obsolete

The <xref:System.Uri.EscapeUriString(System.String)?displayProperty=nameWithType> API is marked as obsolete, starting in .NET 6. Using it in code generates warning `SYSLIB0013` at compile time.

<xref:System.Uri.EscapeUriString(System.String)?displayProperty=nameWithType> can corrupt the Uri string in some cases.

For more information, see <https://github.com/dotnet/runtime/issues/31387>.

## Workarounds

Use <xref:System.Uri.EscapeDataString(System.String)?displayProperty=nameWithType> for query string components instead.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
