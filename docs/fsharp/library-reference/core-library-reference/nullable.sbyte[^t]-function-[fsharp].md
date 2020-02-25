---
title: Nullable.sbyte<^T> Function (F#)
description: Nullable.sbyte<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: f2d463c5-910e-42f5-b17e-fed825ff8e99
---

# Nullable.sbyte<^T> Function (F#)

Converts the argument to signed byte ([`sbyte`](https://msdn.microsoft.com/library/fbc28b7f-2dbf-4361-acb3-830886820068)). This is a direct conversion for all primitive numeric types. The operation requires an appropriate static conversion method on the input type.

**Namespace/Module Path**: Microsoft.FSharp.Linq.Nullable

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
sbyte : Nullable<^T> -> Nullable<sbyte> when ^T with static member op_Explicit and ^T : (new : unit ->  ^T) and ^T : struct and ^T :> ValueType

// Usage:
Nullable.sbyte value
```

#### Parameters
*value*
Type: **System.Nullable&#96;1**&lt;^T&gt;


The input value.




## Return Value
The converted sbyte.


## Remarks
This function is named **ToSByte** in the .NET assembly. If accessing the member from a .NET language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable




## See Also
[Linq.Nullable Module &#40;F&#35;&#41;](Linq.Nullable-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Linq Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq-Namespace-%5BFSharp%5D.md)

[Operators.sbyte&#60;^T&#62; Function &#40;F&#35;&#41;](Operators.sbyte%5B%5ET%5D-Function-%5BFSharp%5D.md)
