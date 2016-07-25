---
title: List.sortWith<'T> Function (F#)
description: List.sortWith<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 25abd618-0568-420a-bf8f-851619a4af04 
---

# List.sortWith<'T> Function (F#)

Sorts the given list using the given comparison function.

**Namespace/Module Path:** Microsoft.FSharp.Collections.List

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.sortWith : ('T -> 'T -> int) -> 'T list -> 'T list

// Usage:
List.sortWith comparer list
```

#### Parameters
*comparer*
Type: **'T -&gt; 'T -&gt;**[int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The function to compare the list elements.


*list*
Type: **'T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The input list.

## Return Value

The sorted list.

## Remarks
This is a stable sort, that is, the original order of equal elements is preserved.

This function is named `SortWith` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fslists/snippet62.fs)]

**Output**

```
Before sorting:
["<>"; "&"; "&&"; "&&&"; "<"; ">"; "|"; "||"; "|||"]
After sorting:
["&"; "|"; "<"; ">"; "&&"; "||"; "<>"; "&&&"; "|||"]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)