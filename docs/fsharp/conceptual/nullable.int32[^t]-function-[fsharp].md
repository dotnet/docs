---
title: Nullable.int32<^T> Function (F#)
description: Nullable.int32<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 18a0d1ce-4cdd-498c-8aac-9f64756dfdcc
---

# Nullable.int32<^T> Function (F#)

Converts the argument to signed 32-bit integer ([`int32`](https://msdn.microsoft.com/library/6ab0ea34-03db-4874-a265-bef9c64f8eff)). This is a direct conversion for all primitive numeric types. The operation requires an appropriate static conversion method on the input type.

**Namespace/Module Path**: Microsoft.FSharp.Linq.Nullable

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
int32 : Nullable<^T> -> Nullable<int32> when ^T with static member op_Explicit and ^T : (new : unit ->  ^T) and ^T : struct and ^T :> ValueType

// Usage:
Nullable.int32 value
```

#### Parameters
*value*
Type: **System.Nullable&#96;1**&lt;^T&gt;


The input value.

## Return Value
The converted int32.


## Remarks
This function is named `ToInt32` in the .NET assembly. If accessing the member from a .NET language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Linq.Nullable Module &#40;F&#35;&#41;](Linq.Nullable-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Linq Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq-Namespace-%5BFSharp%5D.md)

[Operators.int32&#60;^T&#62; Function &#40;F&#35;&#41;](Operators.int32%5B%5ET%5D-Function-%5BFSharp%5D.md)
