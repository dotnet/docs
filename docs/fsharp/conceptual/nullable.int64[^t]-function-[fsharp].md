---
title: Nullable.int64<^T> Function (F#)
description: Nullable.int64<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 7b90604e-8d4f-4ec0-8dd9-182dddd8927d
---

# Nullable.int64<^T> Function (F#)

Converts the argument to signed 64-bit integer [`int64`](https://msdn.microsoft.com/library/1bec11c0-45ac-469e-923b-22a1708c0701). This is a direct conversion for all primitive numeric types. The operation requires an appropriate static conversion method on the input type.

**Namespace/Module Path**: Microsoft.FSharp.Linq.Nullable

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
int64 : Nullable<^T> -> Nullable<int64> when ^T with static member op_Explicit and ^T : (new : unit ->  ^T) and ^T : struct and ^T :> ValueType

// Usage:
Nullable.int64 value
```

#### Parameters
*value*
Type: **System.Nullable&#96;1**&lt;^T&gt;


The input value.

## Return Value
The converted `int64`.


## Remarks
This function is named `ToInt64` in the .NET assembly. If accessing the member from a .NET language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Linq.Nullable Module &#40;F&#35;&#41;](Linq.Nullable-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Linq Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq-Namespace-%5BFSharp%5D.md)

[Operators.int64&#60;^T&#62; Function &#40;F&#35;&#41;](Operators.int64%5B%5ET%5D-Function-%5BFSharp%5D.md)
