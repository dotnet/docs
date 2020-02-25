---
title: Array.sortInPlace<'T> Function (F#)
description: Array.sortInPlace<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ee8fed22-6a0f-4407-80ca-2b903e4fb259 
---

# Array.sortInPlace<'T> Function (F#)

Sorts the elements of an array by mutating the array in-place, using the given comparison function. Elements are compared using [Operators.compare](https://msdn.microsoft.com/library/295e1320-0955-4c3d-ac31-288fa80a658c).

**Namespace/Module Path**: Microsoft.FSharp.Collections.Array

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.sortInPlace : 'T [] -> unit (requires comparison)

// Usage:
Array.sortInPlace array
```

#### Parameters
*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.


## Remarks
This function is named `SortInPlace` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code illustrates the use of `Array.sortInPlace`.

[!code-fsharp[Main](snippets/fsarrays/snippet40.fs)]

**Output**

```
[|-2; 1; 4; 5; 8|]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)