---
title: Nullable.unativeint<^T> Function (F#)
description: Nullable.unativeint<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 642250d5-655e-43d3-a35b-fe1fccae8d61
---

# Nullable.unativeint<^T> Function (F#)

Converts the argument to unsigned native integer ([`unativeint`](https://msdn.microsoft.com/library/9d2946a7-ace9-48a4-8cff-7894b8e7de86)) using a direct conversion for all primitive numeric types. Otherwise, the operation requires an appropriate static conversion method on the input type.

**Namespace/Module Path**: Microsoft.FSharp.Linq.Nullable

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
unativeint : Nullable<^T> -> Nullable<unativeint> when ^T with static member op_Explicit and ^T : (new : unit ->  ^T) and ^T : struct and ^T :> ValueType

// Usage:
Nullable.unativeint value
```

#### Parameters
*value*
Type: **System.Nullable&#96;1**&lt;^T&gt;


The input value.

## Return Value
The converted unativeint.


## Remarks
This function is named `ToUIntPtr` in the .NET assembly. If accessing the member from a .NET language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Linq.Nullable Module &#40;F&#35;&#41;](Linq.Nullable-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Linq Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq-Namespace-%5BFSharp%5D.md)

[Operators.unativeint&#60;^T&#62; Function &#40;F&#35;&#41;](Operators.unativeint%5B%5ET%5D-Function-%5BFSharp%5D.md)
