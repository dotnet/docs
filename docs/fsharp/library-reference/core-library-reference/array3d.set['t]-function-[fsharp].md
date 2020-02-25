---
title: Array3D.set<'T> Function (F#)
description: Array3D.set<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b2735549-4be5-4a6c-b8c6-9720ad2e0a23 
---

# Array3D.set<'T> Function (F#)

Sets the value of an element in an array.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Array3D

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array3D.set : 'T [,,] -> int -> int -> int -> 'T -> unit

// Usage:
Array3D.set array index1 index2 index3 value
```

#### Parameters
*array*
Type: **'T**[[,,]](https://msdn.microsoft.com/library/b4e5b35b-dc83-4b50-94aa-85fcf3ccb2b0)


The input array.


*index1*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The index along the first dimension.


*index2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The index along the second dimension.


*index3*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The index along the third dimension.


*value*
Type: **'T**


The value to set at the given index.

## Remarks
You can also use the syntax `array.[index1,index2,index3] <- value`.

This function is named `Set` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array3D Module &#40;F&#35;&#41;](Collections.Array3D-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)