---
title: Array.compareWith<'T> Function (F#)
description: Array.compareWith<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: liboz
manager: danielfe
ms.date: 07/07/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 39df9501-99de-4ed3-b1d6-3aab44135861
---

# Array.compareWith<'T> Function (F#)

Compares two arrays using the given comparison function, element by element.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Array

**Assembly**: FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
Array.compareWith : ('T -> 'T -> int) -> 'T [] -> 'T [] -> int

// Usage:
Array.compareWith comparer source1 source2
```

#### Parameters
*comparer*
Type: **'T -&gt; 'T -&gt;**[int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

A function that takes an element from each of the two source arrays and returns an int. If it evaluates to a non-zero value, iteration is stopped and that value is returned.

*source1*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The first input array.

*source2*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The second input array.

## Return Value
Returns the first non-zero result from the comparison function. If the first array has a larger element, the return value is always positive. 
If the second array has a larger element, the return value is always negative. 
When the elements are equal in the two arrays, 1 is returned if the first array is longer, 
0 is returned if they are equal in length, and -1 is returned when the second array is longer.

## Remarks
This function is named `CompareWith` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## Example

The following example demonstrates the use of Array.compareWith to compare two sequences using a custom comparison function.

[!code-fsharp[Main](snippets/fsarrays/snippet114.fs)]

**Output**

```
Array1 is less than Array2.
42
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)