---
title: Globalization breaking changes
description: Lists the breaking changes in globalization in .NET Core.
ms.date: 04/07/2020
---
# Globalization breaking changes

The following breaking changes are documented on this page:

| Breaking change | Version introduced |
| - | :-: |
| [Globalization APIs use ICU libraries on Windows](#globalization-apis-use-icu-libraries-on-windows) | 5.0 |
| [StringInfo and TextElementEnumerator are now UAX29-compliant](#stringinfo-and-textelementenumerator-are-now-uax29-compliant) | 5.0 |
| ["C" locale maps to the invariant locale](#c-locale-maps-to-the-invariant-locale) | 3.0 |

## .NET 5.0

[!INCLUDE [icu-globalization-api](../../../includes/core-changes/globalization/5.0/icu-globalization-api.md)]

***

[!INCLUDE [uax29-compliant-grapheme-enumeration](../../../includes/core-changes/globalization/5.0/uax29-compliant-grapheme-enumeration.md)]

***

## .NET Core 3.0

[!INCLUDE["C" locale maps to the invariant locale](~/includes/core-changes/globalization/3.0/c-locale-maps-to-invariant-locale.md)]

***
