---
title: Nullable.char<^T> Function (F#)
description: Nullable.char<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 59a57347-0540-4917-853d-32b133d292e7
---

# Nullable.char<^T> Function (F#)

Converts the argument to [char](https://msdn.microsoft.com/library/3627f475-985b-4b4e-94d2-14f217c04958). Numeric inputs are converted according to the UTF-16 encoding for characters. The operation requires an appropriate static conversion method on the input type.

**Namespace/Module Path**: Microsoft.FSharp.Linq.Nullable

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
char : Nullable<^T> -> Nullable<char> when ^T with static member op_Explicit and ^T : (new : unit ->  ^T) and ^T : struct and ^T :> ValueType

// Usage:
Nullable.char value
```

#### Parameters
*value*
Type: **System.Nullable&#96;1**&lt;^T&gt;


The input value.


## Return Value
The converted char.


## Remarks
This function is named `ToChar` in the .NET assembly. If accessing the member from a .NET language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Linq.Nullable Module &#40;F&#35;&#41;](Linq.Nullable-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Linq Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq-Namespace-%5BFSharp%5D.md)

[Operators.char&#60;^T&#62; Function &#40;F&#35;&#41;](Operators.char%5B%5ET%5D-Function-%5BFSharp%5D.md)
