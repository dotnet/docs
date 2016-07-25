---
title: Checked.uint16<^T> Function (F#)
description: Checked.uint16<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 017a4bb0-afe2-4670-a539-ad1db7ff5fd3 
---

# Checked.uint16<^T> Function (F#)

Converts the argument to `uint16`. This is a direct, checked conversion for all primitive numeric types. For strings, the input is converted using [`System.UInt16.Parse`](https://msdn.microsoft.com/library/c9373sf3.aspx) with **System.Globalization.CultureInfo.InvariantCulture** settings. Otherwise the operation requires an appropriate static conversion method on the input type.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.Checked

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
uint16 : ^T -> uint16 (requires ^T with static member op_Explicit)

// Usage:
uint16 value
```

#### Parameters
*value*
Type: **^T**


The input value.


## Return Value

The converted `uint16`.

## Remarks
This function is named `ToUInt16` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Operators.Checked Module &#40;F&#35;&#41;](Operators.Checked-Module-%5BFSharp%5D.md)

[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)