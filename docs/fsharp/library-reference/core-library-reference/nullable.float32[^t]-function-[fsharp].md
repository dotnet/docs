---
title: Nullable.float32<^T> Function (F#)
description: Nullable.float32<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d844c97a-3499-41f3-963b-7152d24f40b4
---

# Nullable.float32<^T> Function (F#)

Converts the argument to [`float32`](https://msdn.microsoft.com/library/9bf674b5-ea9a-4b08-ad42-4da313b6ebf0). This is a direct conversion for all primitive numeric types. The operation requires an appropriate static conversion method on the input type.

**Namespace/Module Path**: Microsoft.FSharp.Linq.Nullable

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
float32 : Nullable<^T> -> Nullable<float32> when ^T with static member op_Explicit and ^T : (new : unit ->  ^T) and ^T : struct and ^T :> ValueType

// Usage:
Nullable.float32 value
```

#### Parameters
*value*
Type: **System.Nullable&#96;1**&lt;^T&gt;


The input value.

## Return Value
The converted float32.


## Remarks
This function is named `ToSingle` in the .NET assembly. If accessing the member from a .NET language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Linq.Nullable Module &#40;F&#35;&#41;](Linq.Nullable-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Linq Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq-Namespace-%5BFSharp%5D.md)

[Operators.float32&#60;^T&#62; Function &#40;F&#35;&#41;](Operators.float32%5B%5ET%5D-Function-%5BFSharp%5D.md)
