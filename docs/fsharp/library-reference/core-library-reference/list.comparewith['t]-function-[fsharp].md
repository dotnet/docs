---
title: List.compareWith<'T> Function (F#)
description: List.compareWith<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: liboz
manager: danielfe
ms.date: 07/05/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 4e128d48-49cb-4985-8b2d-7fcb3ff19721
---

# List.compareWith<'T> Function (F#)

Compares two lists using the given comparison function, element by element.

**Namespace/Module Path**: Microsoft.FSharp.Collections.List

**Assembly**: FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
List.compareWith : ('T -> 'T -> int) -> 'T list -> 'T list -> int

// Usage:
List.compareWith comparer source1 source2
```

#### Parameters
*comparer*
Type: **'T -&gt; 'T -&gt;**[int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

A function that takes an element from each of the two source lists and returns an int. If it evaluates to a non-zero value, iteration is stopped and that value is returned.

*source1*
Type: **'T** [list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)

The first input list.

*source2*
Type: **'T** [list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)

The second input list.

## Return Value
Returns the first non-zero result from the comparison function. If the first list has a larger element, the return value is always positive. 
If the second list has a larger element, the return value is always negative. 
When the elements are equal in the two lists, 1 is returned if the first list is longer, 
0 is returned if they are equal in length, and -1 is returned when the second list is longer.

## Remarks
This function is named `CompareWith` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## Example

The following example demonstrates the use of List.compareWith to compare two sequences using a custom comparison function.

[!code-fsharp[Main](snippets/fslists/snippet114.fs)]

**Output**

```
List1 is less than List2.
42
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)