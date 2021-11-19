---
title: SYSLIB0022 warning
description: Learn about the Rijndael and RijndaelManaged obsoletions that generate compile-time warning SYSLIB0022.
ms.date: 05/18/2021
---
# SYSLIB0022: The Rijndael and RijndaelManaged types are obsolete

The <xref:System.Security.Cryptography.Rijndael> and <xref:System.Security.Cryptography.RijndaelManaged> types are marked as obsolete, starting in .NET 6. Using them in code generates warning `SYSLIB0022` at compile time.

## Workarounds

Use <xref:System.Security.Cryptography.Aes?displayProperty=fullName> instead.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
