---
title: Operators.decimal<^T> Function (F#)
description: Operators.decimal<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d0adc3a3-12fe-4b14-8f3b-9df9b6912ad4
---

# Operators.decimal<^T> Function (F#)

Converts the argument to `System.Decimal` using a direct conversion for all primitive numeric types. For strings, the input is converted using `System.UInt64.Parse(System.String)` with `System.Globalization.CultureInfo.InvariantCulture` settings. Otherwise the operation requires an appropriate static conversion method on the input type.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
decimal : ^T -> decimal (requires ^T with static member op_Explicit)

// Usage:
decimal value
```

#### Parameters
*value*
Type: **^T**


The input value.

## Return Value

The converted decimal.

## Remarks
This function is named `ToDecimal` in the assembly. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
