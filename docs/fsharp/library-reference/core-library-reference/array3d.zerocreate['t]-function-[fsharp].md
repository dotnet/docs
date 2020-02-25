---
title: Array3D.zeroCreate<'T> Function (F#)
description: Array3D.zeroCreate<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 216a5588-352f-402f-a0d6-996b67db98ff 
---

# Array3D.zeroCreate<'T> Function (F#)

Creates an array where the entries are initially the default value.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array3D

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array3D.zeroCreate : int -> int -> int -> 'T [,,]

// Usage:
Array3D.zeroCreate length1 length2 length3
```

#### Parameters
*length1*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The length of the first dimension.


*length2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The length of the second dimension.


*length3*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The length of the third dimension.

## Return Value

The created array.

## Remarks
This function is named `ZeroCreate` in compiled assembly. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array3D Module &#40;F&#35;&#41;](Collections.Array3D-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)