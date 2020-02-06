---
title: Operators.nativeint<^T> Function (F#)
description: Operators.nativeint<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 40b319f4-3879-4a05-9667-15e181f97fc5
---

# Operators.nativeint<^T> Function (F#)

Converts the argument to signed native integer. This is a direct conversion for all primitive numeric types. Otherwise the operation requires an appropriate static conversion method on the input type.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
nativeint : ^T -> nativeint (requires ^T with static member op_Explicit)

// Usage:
nativeint value
```

#### Parameters
*value*
Type: **^T**


The input value.

## Return Value

The converted `nativeint` value.

## Remarks
This function is named `ToIntPtr` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
