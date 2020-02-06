---
title: Checked.sbyte<^T> Function (F#)
description: Checked.sbyte<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 1e1c69b2-f27d-44e7-8261-19270a92ec4e 
---

# Checked.sbyte<^T> Function (F#)

Converts the argument to `sbyte`. This is a direct, checked conversion for all primitive numeric types. For strings, the input is converted using [`System.SByte.Parse`](https://msdn.microsoft.com/library/system.sbyte.parse.aspx) with [`System.Globalization.CultureInfo.InvariantCulture`](https://msdn.microsoft.com/library/system.globalization.cultureinfo.invariantculture.aspx) settings. Otherwise the operation requires an appropriate static conversion method on the input type.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.Checked

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
sbyte : ^T -> sbyte (requires ^T with static member op_Explicit)

// Usage:
sbyte value
```

#### Parameters
*value*
Type: **^T**


The input value.

## Return Value

The converted `sbyte`.

## Remarks
This function is named `ToSByte` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Operators.Checked Module &#40;F&#35;&#41;](Operators.Checked-Module-%5BFSharp%5D.md)

[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)