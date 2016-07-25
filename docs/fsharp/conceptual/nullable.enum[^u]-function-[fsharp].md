---
title: Nullable.enum<^U> Function (F#)
description: Nullable.enum<^U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 95cb79c9-2f43-49a5-b29a-04a2a3ce552c
---

# Nullable.enum<^U> Function (F#)

Converts the argument to a particular enum type.

**Namespace/Module Path**: Microsoft.FSharp.Linq.Nullable

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
enum : Nullable<int32> -> Nullable<^U> when ^U : enum<int32> and ^U : (new : unit ->  ^U) and ^U : struct and ^U :> ValueType

// Usage:
Nullable.enum value
```

#### Parameters
*value*
Type: **System.Nullable&#96;1**&lt;[int32](https://msdn.microsoft.com/library/6ab0ea34-03db-4874-a265-bef9c64f8eff)&gt;


The input value.

## Return Value
The converted enum type.

## Remarks
This function is named `ToEnum` in the .NET assembly. If accessing the member from a .NET language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Linq.Nullable Module &#40;F&#35;&#41;](Linq.Nullable-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Linq Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq-Namespace-%5BFSharp%5D.md)

[Operators.enum&#60;^U&#62; Function &#40;F&#35;&#41;](Operators.enum%5B%5EU%5D-Function-%5BFSharp%5D.md)

[Enumerations (F#)](https://msdn.microsoft.com/library/74192be5-bb8d-499d-b540-283cecd999cd)
