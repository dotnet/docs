---
title: Charsets and marshalling - .NET
description: Learn how different values of CharSet can change how .NET marshals your data to native code.
author: jkoritzinsky
ms.author: jekoritz
ms.date: 01/18/2019
---

# Charsets and marshalling

The way `char` values, `string` objects, and `System.Text.StringBuilder` objects are marshalled depends on the value of the `CharSet` field on either the P/Invoke or structure. You can set the `CharSet` of a P/Invoke by setting the <xref:System.Runtime.InteropServices.DllImportAttribute.CharSet?displayProperty=nameWithType> field when declaring your P/Invoke. To set the `CharSet` for a structure, set the <xref:System.Runtime.InteropServices.StructLayoutAttribute.CharSet?displayProperty=nameWithType> field on your struct declaration. When these attribute fields are not set, it is up to the language compiler to determine which `CharSet` to use. C# uses the <xref:System.Runtime.InteropServices.CharSet.Ansi> charset by default.

The following table shows a mapping between each charset and how a character or string is represented when marshalled with that charset:

| CharSet | Windows | Unix | Mono on Unix |
|---------|---------|-------|-------|
| Ansi    | `char` (ANSI)  | `char` (ANSI on macOS, UTF-8 on Linux) | `char` (UTF-8) |
| Unicode | `wchar_t` (UTF-16) | `char16_t` (UTF-16) | `char16_t` (UTF-16) |
| Auto | `wchar_t` (UTF-16) | `char16_t` (UTF-16) | `char` (UTF-8) |

Make sure you know what representation your native representation expects when picking your charset.
