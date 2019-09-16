---
title: Charsets and marshaling - .NET
description: Learn how different values of CharSet can change how .NET marshals your data to native code.
author: jkoritzinsky
ms.author: jekoritz
ms.date: 01/18/2019
---

# Charsets and marshaling

The way `char` values, `string` objects, and `System.Text.StringBuilder` objects are marshaled depends on the value of the `CharSet` field on either the P/Invoke or structure. You can set the `CharSet` of a P/Invoke by setting the <xref:System.Runtime.InteropServices.DllImportAttribute.CharSet?displayProperty=nameWithType> field when declaring your P/Invoke. To set the `CharSet` for a structure, set the <xref:System.Runtime.InteropServices.StructLayoutAttribute.CharSet?displayProperty=nameWithType> field on your struct declaration. When these attribute fields are not set, it is up to the language compiler to determine which `CharSet` to use. C# and VB use the <xref:System.Runtime.InteropServices.CharSet.Ansi> charset by default.

The following table shows a mapping between each charset and how a character or string is represented when marshaled with that charset:

| `CharSet` value | Windows            | .NET Core 2.2 and earlier on Unix | .NET Core 3.0 and later and Mono on Unix |
|-----------------|--------------------|-----------------------------------|------------------------------------------|
| Ansi            | `char` (the system default [Windows (ANSI) code page](/windows/win32/intl/code-pages))      | `char` (UTF-8)                    | `char` (UTF-8)                           |
| Unicode         | `wchar_t` (UTF-16) | `char16_t` (UTF-16)               | `char16_t` (UTF-16)                      |
| Auto            | `wchar_t` (UTF-16) | `char16_t` (UTF-16)               | `char` (UTF-8)                           |

Make sure you know what representation your native representation expects when picking your charset.
