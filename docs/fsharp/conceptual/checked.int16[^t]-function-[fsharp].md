---
title: Checked.int16<^T> Function (F#)
description: Checked.int16<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d41f9782-9459-44f4-9ee1-95b5293e0590 
---

# Checked.int16<^T> Function (F#)

Converts the argument to `int16`. This is a direct, checked conversion for all primitive numeric types. For strings, the input is converted using [`System.Int16.Parse`](https://msdn.microsoft.com/library/system.int16.parse.aspx) with [`System.Globalization.CultureInfo.InvariantCulture`](https://msdn.microsoft.com/library/system.globalization.cultureinfo.invariantculture.aspx) settings. Otherwise the operation requires an appropriate static conversion method on the input type.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.Checked

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
int16 : ^T -> int16 (requires ^T with static member op_Explicit)

// Usage:
int16 value
```

#### Parameters
*value*
Type: **^T**


The input value.


## Return Value

The converted int16.

## Remarks
This function is named `ToInt16` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Operators.Checked Module &#40;F&#35;&#41;](Operators.Checked-Module-%5BFSharp%5D.md)

[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)