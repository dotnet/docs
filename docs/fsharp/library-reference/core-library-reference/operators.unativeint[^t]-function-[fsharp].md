---
title: Operators.unativeint<^T> Function (F#)
description: Operators.unativeint<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 69503359-8af2-4517-864a-e9667534c131
---

# Operators.unativeint<^T> Function (F#)

Converts the argument to unsigned native integer using a direct conversion for all primitive numeric types. Otherwise the operation requires an appropriate static conversion method on the input type.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

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

The converted `unativeint` value.

## Remarks
This function is named `ToUIntPtr` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
