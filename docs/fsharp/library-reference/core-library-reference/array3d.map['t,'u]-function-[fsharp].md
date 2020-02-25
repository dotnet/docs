---
title: Array3D.map<'T,'U> Function (F#)
description: Array3D.map<'T,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ee9a960c-7c70-4844-b206-8edb5b86df7b 
---

# Array3D.map<'T,'U> Function (F#)

Creates a new array whose elements are the results of applying the given function to each of the elements of the array.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array3D

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array3D.map : ('T -> 'U) -> 'T [,,] -> 'U [,,]

// Usage:
Array3D.map mapping array
```

#### Parameters
*mapping*
Type: **'T -&gt; 'U**


The function to transform each element of the array.


*array*
Type: **'T**[[,,]](https://msdn.microsoft.com/library/b4e5b35b-dc83-4b50-94aa-85fcf3ccb2b0)


The input array.

## Return Value

The array created from the transformed elements.

## Remarks
For non-zero-based arrays the basing on an input array will be propagated to the output array.

This function is named `Map` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array3D Module &#40;F&#35;&#41;](Collections.Array3D-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)