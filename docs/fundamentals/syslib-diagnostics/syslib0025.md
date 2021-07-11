---
title: SYSLIB0025 warning
description: Learn about the obsoletion of SuppressIldasmAttribute that generates compile-time warning SYSLIB0025.
ms.date: 06/21/2021
---
# SYSLIB0025: SuppressIldasmAttribute is obsolete

The <xref:System.Runtime.CompilerServices.SuppressIldasmAttribute> type is marked as obsolete, starting in .NET 6. Using it in code generates warning `SYSLIB0025` at compile time. [IL Disassembler (ildasm.exe)](../../framework/tools/ildasm-exe-il-disassembler.md) no longer supports this attribute.

## Workarounds

None.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
