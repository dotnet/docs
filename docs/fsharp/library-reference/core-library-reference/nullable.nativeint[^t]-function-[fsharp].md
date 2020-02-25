---
title: Nullable.nativeint<^T> Function (F#)
description: Nullable.nativeint<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 34b1755d-6adb-4aa1-8a09-7b4e81af8df6
---

# Nullable.nativeint<^T> Function (F#)

Converts the argument to signed native integer ([`nativeint`](https://msdn.microsoft.com/library/f8478c3e-fff5-4f10-82cf-4bedfe305f7b)). This is a direct conversion for all primitive numeric types. Otherwise, the operation requires an appropriate static conversion method on the input type.

**Namespace/Module Path**: Microsoft.FSharp.Linq.Nullable

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
nativeint : Nullable<^T> -> Nullable<nativeint> when ^T with static member op_Explicit and ^T : (new : unit ->  ^T) and ^T : struct and ^T :> ValueType

// Usage:
Nullable.nativeint value
```

#### Parameters
*value*
Type: **System.Nullable&#96;1**&lt;^T&gt;


The input value.

## Return Value
The converted nativeint.

## Remarks
This function is named `ToIntPtr` in the .NET assembly. If accessing the member from a .NET language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable


## See Also
[Linq.Nullable Module &#40;F&#35;&#41;](Linq.Nullable-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Linq Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq-Namespace-%5BFSharp%5D.md)

[Operators.nativeint&#60;^T&#62; Function &#40;F&#35;&#41;](Operators.nativeint%5B%5ET%5D-Function-%5BFSharp%5D.md)
