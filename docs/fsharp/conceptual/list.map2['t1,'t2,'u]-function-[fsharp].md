---
title: List.map2<'T1,'T2,'U> Function (F#)
description: List.map2<'T1,'T2,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: aa680673-f521-47b3-bd42-29a526d93904 
---

# List.map2<'T1,'T2,'U> Function (F#)

Creates a new collection whose elements are the results of applying the given function to the corresponding elements of the two collections pairwise.

**Namespace/Module Path:** Microsoft.FSharp.Collections.List

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.map2 : ('T1 -> 'T2 -> 'U) -> 'T1 list -> 'T2 list -> 'U list

// Usage:
List.map2 mapping list1 list2
```

#### Parameters
*mapping*
Type: **'T1 -&gt; 'T2 -&gt; 'U**


The function to transform pairs of elements from the input lists.


*list1*
Type: **'T1**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The first input list.


*list2*
Type: **'T2**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The second input list.

## Return Value

The list of resulting elements.

## Remarks
The two lists *list1* and *list2* must have the same length. If they don't, an exception is thrown.

This function is named `Map2` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fslists/snippet19.fs)]

**Output**

```
[5; 7; 9]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)