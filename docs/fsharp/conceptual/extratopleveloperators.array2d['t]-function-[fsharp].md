---
title: ExtraTopLevelOperators.array2D<'T> Function (F#)
description: ExtraTopLevelOperators.array2D<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: c397595d-2912-49d2-a1d4-95a6067ea27d 
---

# ExtraTopLevelOperators.array2D<'T> Function (F#)

Builds a 2D array from a sequence of sequences of elements.

**Namespace/Module Path:** Microsoft.FSharp.Core.ExtraTopLevelOperators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
array2D : seq<#seq<'T>> -> 'T [,]

// Usage:
array2D rows
```

#### Parameters
*rows*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T&gt;**


The sequence of sequences for the array rows.

## Remarks
This function is named `CreateArray2D` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code shows how to initialize a two-dimensional array using array2D.

```fsharp
let myArray2D : string[,] = array2D [["a1"; "b1"; "c1"]; ["a2"; "b2"; "c2"]] 
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.ExtraTopLevelOperators Module &#40;F&#35;&#41;](Core.ExtraTopLevelOperators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)