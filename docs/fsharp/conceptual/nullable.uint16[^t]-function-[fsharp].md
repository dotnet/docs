---
title: Nullable.uint16<^T> Function (F#)
description: Nullable.uint16<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 975656d3-ee8a-43fc-9755-2f501783aff7
---

# Nullable.uint16<^T> Function (F#)

Converts the argument to unsigned 16-bit integer ([`uint16`](https://msdn.microsoft.com/library/2ab2f1fa-344e-4fcf-a688-5024c589630b)). This is a direct conversion for all primitive numeric types. The operation requires an appropriate static conversion method on the input type.

**Namespace/Module Path**: Microsoft.FSharp.Linq.Nullable

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
uint16 : Nullable<^T> -> Nullable<uint16> when ^T with static member op_Explicit and ^T : (new : unit ->  ^T) and ^T : struct and ^T :> ValueType

// Usage:
Nullable.uint16 value
```

#### Parameters
*value*
Type: **System.Nullable&#96;1**&lt;^T&gt;


The input value.

## Return Value
The converted uint16.


## Remarks
This function is named `ToUInt16` in the .NET assembly. If accessing the member from a .NET language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Linq.Nullable Module &#40;F&#35;&#41;](Linq.Nullable-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Linq Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq-Namespace-%5BFSharp%5D.md)

[Operators.uint16&#60;^T&#62; Function &#40;F&#35;&#41;](Operators.uint16%5B%5ET%5D-Function-%5BFSharp%5D.md)
