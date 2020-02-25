---
title: Array.sub<'T> Function (F#)
description: Array.sub<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 825d39fa-6e6e-42d4-bb6c-75ead30ff30b 
---

# Array.sub<'T> Function (F#)

Builds a new array that contains the given subrange specified by starting index and length.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.sub : 'T [] -> int -> int -> 'T []

// Usage:
Array.sub array startIndex count
```

#### Parameters
*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.


*startIndex*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The index of the first element of the subarray.


*count*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The length of the subarray.


## Return Value

The created subarray.

## Remarks
This function is named `GetSubArray` in compiled assemblies. If accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following example shows the use of `Array.sub` to specify a subarray. The output shows that the subarray starts at a zero-based index of 5 and has 10 elements.

[!code-fsharp[Main](snippets/fsarrays/snippet12.fs)]

```
[|5; 6; 7; 8; 9; 10; 11; 12; 13; 14|]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)