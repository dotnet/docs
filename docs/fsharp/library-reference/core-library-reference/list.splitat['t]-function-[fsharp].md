---
title: List.splitAt<'T> Function (F#)
description: List.splitAt<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: ploeh
manager: danielfe
ms.date: 05/24/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: be7df48f-7675-4cb3-9a46-07196c2749b1 
---

# List.splitAt<'T> Function (F#)

Splits the collection into two collections, before the given index.

**Namespace/Module Path:** Microsoft.FSharp.Collections.List

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.splitAt : int -> 'T list -> 'T list * 'T list

// Usage:
List.splitAt index list
```

#### Parameters
*index*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The zero-based index at which the list should be split.


*list*
Type: **'T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The input list.

## Return Value

A list containing all the elements before the index, and a list containing all the elements at, and after, the index.

## Remarks
The function splits the input list into two lists. The element at the zero-based index goes into the second list. As a consequence of this, if *index* is *0*, the first list will be empty. Likewise, if the index is exactly equal to the length of the list, the second list will be empty.

If the index is higher than the length of the list, an exception is thrown. 

This function is named `SplitAt` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fslists/snippet112.fs)]

**Output**

```
First: [0; 1]
Second: [2; 3; 4; 5; 6; 7; 8; 9]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)