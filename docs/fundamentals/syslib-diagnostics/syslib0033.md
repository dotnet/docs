---
title: SYSLIB0033 warning - Rfc2898DeriveBytes.CryptDeriveKey is obsolete
description: Learn about the obsoletion of Rfc2898DeriveBytes.CryptDeriveKey that generates compile-time warning SYSLIB0033.
ms.date: 09/07/2021
---
# SYSLIB0033: Rfc2898DeriveBytes.CryptDeriveKey is obsolete

The <xref:System.Security.Cryptography.Rfc2898DeriveBytes.CryptDeriveKey(System.String,System.String,System.Int32,System.Byte[])?displayProperty=nameWithType> method is marked as obsolete, starting in .NET 6. Using this API in code generates warning `SYSLIB0033` at compile time.

## Workaround

Use <xref:System.Security.Cryptography.PasswordDeriveBytes.CryptDeriveKey(System.String,System.String,System.Int32,System.Byte[])?displayProperty=nameWithType> instead.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
