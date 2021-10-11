---
title: Charsets and marshaling - .NET
description: Learn how different values of CharSet can change how .NET marshals your data to native code.
ms.date: 01/18/2019
---

# Charsets and marshaling

The way `char` values, `string` objects, and `System.Text.StringBuilder` objects are marshaled depends on the value of the `CharSet` field on either the P/Invoke or structure. You can set the `CharSet` of a P/Invoke by setting the <xref:System.Runtime.InteropServices.DllImportAttribute.CharSet?displayProperty=nameWithType> field when declaring your P/Invoke. To set the `CharSet` for a type, set the <xref:System.Runtime.InteropServices.StructLayoutAttribute.CharSet?displayProperty=nameWithType> field on your class or struct declaration. When these attribute fields are not set, it is up to the language compiler to determine which `CharSet` to use. C#, Visual Basic, and F# use the <xref:System.Runtime.InteropServices.CharSet.None> charset by default, which has the same behavior as the <xref:System.Runtime.InteropServices.CharSet.Ansi> charset.

If the <xref:System.Runtime.InteropServices.DefaultCharSetAttribute?displayProperty=nameWithType> is applied on the module in C# or Visual Basic code, then the C# or Visual Basic compiler will emit the provided `CharSet` by default instead of using `CharSet.None`. F# does not support the `DefaultCharSetAttribute`, and always emits `CharSet.None` by default.

The following table shows a mapping between each charset and how a character or string is represented when marshaled with that charset:

| `CharSet` value | Windows            | .NET Core 2.2 and earlier on Unix | .NET Core 3.0 and later and Mono on Unix |
|-----------------|--------------------|-----------------------------------|------------------------------------------|
| `Ansi`          | `char` (the system default [Windows (ANSI) code page](/windows/win32/intl/code-pages))      | `char` (UTF-8)                    | `char` (UTF-8)                           |
| `Unicode`       | `wchar_t` (UTF-16) | `char16_t` (UTF-16)               | `char16_t` (UTF-16)                      |
| `Auto`          | `wchar_t` (UTF-16) | `char16_t` (UTF-16)               | `char` (UTF-8)                           |

Make sure you know what representation your native representation expects when picking your charset.
