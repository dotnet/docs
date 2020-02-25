---
title: Array.permute<'T> Function (F#)
description: Array.permute<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 5e2836f2-5b47-4ce0-af1d-ec75b84f1ea1 
---

# Array.permute<'T> Function (F#)

Returns an array with all elements permuted according to the specified permutation.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.permute : (int -> int) -> 'T [] -> 'T []

// Usage:
Array.permute indexMap array
```

#### Parameters
*indexMap*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt;**[int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The function that maps input indices to output indices.


*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.

## Return Value

The permuted array.

## Remarks
This function is named `Permute` in compiled assemblies. If accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code illustrates the use of `Array.permute`.

[!code-fsharp[Main](snippets/fsarrays/snippet34.fs)]

**Output**

```
[|1; 2; 3; 4; 5|]
[|5; 1; 2; 3; 4|]
[|4; 5; 1; 2; 3|]
[|3; 4; 5; 1; 2|]
[|2; 3; 4; 5; 1|]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)