---
title: Array.reduceBack<'T> Function (F#)
description: Array.reduceBack<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 928a0256-d038-45a3-a4aa-bf3c5bc337df 
---

# Array.reduceBack<'T> Function (F#)

Applies a function to each element of the array, threading an accumulator argument through the computation. If the input function is `f` and the elements are `i0...iN` then computes `f i0 (...(f iN-1 iN))`. Raises [ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx) if the array has size zero.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
Array.reduceBack : ('T -> 'T -> 'T) -> 'T [] -> 'T

// Usage:
Array.reduceBack reduction array
```

#### Parameters
*reduction*
Type: **'T -&gt; 'T -&gt; 'T**

The function to reduce a pair of elements to a single element.

*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The input array.

## Return Value

Returns the final result of the reductions.

## Remarks
This function is named `ReduceBack` in compiled assemblies. If you are accessing the member from a language other than F#, or through reflection, use this name.

## Example

The following code example compares [`Array.reduce`](https://msdn.microsoft.com/library/fd62a985-89fe-4f49-a9d4-0c808ac6749d) and `Array.reduceBack`.

[!code-fsharp[Main](snippets/fsarrays/snippet63.fs)]

**Output**

```
-8
-2
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)