---
title: Operators.byte<^T> Function (F#)
description: Operators.byte<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: c67dbe25-7274-4aea-812e-0bb2778a157b
---

# Operators.byte<^T> Function (F#)

Converts the argument to byte. This is a direct conversion for all primitive numeric types. For strings, the input is converted using `System.Byte.Parse(System.String)` with `System.Globalization.CultureInfo.InvariantCulture` settings. Otherwise the operation requires an appropriate static conversion method on the input type.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
byte : ^T -> byte (requires ^T with static member op_Explicit)

// Usage:
byte value
```

#### Parameters
*value*
Type: **^T**


The input value.

## Return Value

The converted byte.

## Remarks
This function is named `ToByte` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
