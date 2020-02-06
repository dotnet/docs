---
title: List.sortBy<'T,'Key> Function (F#)
description: List.sortBy<'T,'Key> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 6f6ff91d-5c49-4f4a-8aea-5423237d346d 
---

# List.sortBy<'T,'Key> Function (F#)

Sorts the given list using keys given by the given projection. Keys are compared using [`Operators.compare`](https://msdn.microsoft.com/library/295e1320-0955-4c3d-ac31-288fa80a658c).

**Namespace/Module Path:** Microsoft.FSharp.Collections.List

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.sortBy : ('T -> 'Key) -> 'T list -> 'T list (requires comparison)

// Usage:
List.sortBy projection list
```

#### Parameters
*projection*
Type: **'T -&gt; 'Key**


The function to transform the list elements into the type to be compared.


*list*
Type: **'T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The input list.

## Return Value

The sorted list.

## Remarks

This is a stable sort, that is, the original order of equal elements is preserved.

This function is named `SortBy` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fslists/snippet6.fs)]

**Output**

```
[1; -2; 4; 5; 8]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)