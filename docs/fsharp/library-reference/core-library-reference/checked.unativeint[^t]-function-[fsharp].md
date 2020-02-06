---
title: Checked.unativeint<^T> Function (F#)
description: Checked.unativeint<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 0b522fa2-78ff-438a-ab5f-2d7ee7a685e5 
---

# Checked.unativeint<^T> Function (F#)

Converts the argument to `unativeint`. This is a direct, checked conversion for all primitive numeric types. Otherwise the operation requires an appropriate static conversion method on the input type.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.Checked

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
unativeint : ^T -> unativeint (requires ^T with static member op_Explicit)

// Usage:
unativeint value
```

#### Parameters
*value*
Type: **^T**


The input value.

## Return Value

The converted `unativeint`.

## Remarks
This function is named `ToUIntPtr` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Operators.Checked Module &#40;F&#35;&#41;](Operators.Checked-Module-%5BFSharp%5D.md)

[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)