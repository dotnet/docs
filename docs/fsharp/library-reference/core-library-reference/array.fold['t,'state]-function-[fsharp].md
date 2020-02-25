---
title: Array.fold<'T,'State> Function (F#)
description: Array.fold<'T,'State> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 6a9b86ef-7891-494c-af32-7928d0ef69a3 
---

# Array.fold<'T,'State> Function (F#)

Applies a function to each element of the collection, threading an accumulator argument through the computation. If the input function is `f` and the elements are `i0...iN` then computes `f (... (f s i0)...) iN`.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.fold : ('State -> 'T -> 'State) -> 'State -> 'T [] -> 'State

// Usage:
Array.fold folder state array
```

#### Parameters
*folder*
Type: **'State -&gt; 'T -&gt; 'State**


The function to update the state given the input elements.


*state*
Type: **'State**


The initial state.


*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.

## Return Value

The final state.

## Remarks
This function is named `Fold` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code illustrates the use of Array.fold.

[!code-fsharp[Main](snippets/fsarrays/snippet32.fs)]

**Output**

```
Sum of the elements of array [1; 2; 3] is 6.
Array [|1; 1; 1|] average: 1.000000 stddev: 0.000000
Array [|1; 2; 1|] average: 1.333333 stddev: 0.471405
Array [|1; 2; 3|] average: 2.000000 stddev: 0.816497
0.0
1.0
2.5
5.1
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)