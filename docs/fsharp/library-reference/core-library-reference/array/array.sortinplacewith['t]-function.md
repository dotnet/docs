---
title: Array.sortInPlaceWith<'T> Function
description: Array.sortInPlaceWith<'T> Function
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 3a01c047-14d8-45e6-b4bc-b447910cc96a 
---

# Array.sortInPlaceWith<'T> Function

Sorts the elements of an array by mutating the array in place, using the given comparison function as the order.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.sortInPlaceWith : ('T -> 'T -> int) -> 'T [] -> unit

// Usage:
Array.sortInPlaceWith comparer array
```

#### Parameters
*comparer*
Type: **'T -&gt; 'T -&gt;**[int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The function to compare pairs of array elements.


*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.


## Remarks
This function is named `SortInPlaceWith` in compiled assemblies. If accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code example shows how to use Array.sortInPlaceWith.

[!code-fsharp[Main](~/samples/snippets/fsharp/arrays/snippet64.fs)]

**Output**

```
Before sorting:
[|"&lt;&gt;"; "&amp;"; "&amp;&amp;"; "&amp;&amp;&amp;"; "&lt;"; "&gt;"; "|"; "||"; "|||"|]
After sorting:
[|"&amp;"; "|"; "&lt;"; "&gt;"; "&amp;&amp;"; "||"; "&lt;&gt;"; "&amp;&amp;&amp;"; "|||"|]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Array Module](array-module.md)

[Microsoft.FSharp.Collections Namespace](../Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)