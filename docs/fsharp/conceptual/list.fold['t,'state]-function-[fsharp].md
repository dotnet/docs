---
title: List.fold<'T,'State> Function (F#)
description: List.fold<'T,'State> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 6d59656f-7690-4312-ab29-406c5a1b0c03 
---

# List.fold<'T,'State> Function (F#)

Applies a function `f` to each element of the collection, threading an accumulator argument through the computation. The `fold` function takes the second argument, and applies the function `f` to it and the first element of the list. Then, it feeds this result into the function `f` along with the second element, and so on. It returns the final result. If the input function is `f` and the elements are `i0...iN`, then this function computes `f (... (f s i0) i1 ...) iN`.

**Namespace/Module Path:** Microsoft.FSharp.Collections.List

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.fold : ('State -> 'T -> 'State) -> 'State -> 'T list -> 'State

// Usage:
List.fold folder state list
```

#### Parameters
*folder*
Type: **'State -&gt; 'T -&gt; 'State**


The function to update the state given the input elements.


*state*
Type: **'State**


The initial state.


*list*
Type: **'T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The input list.

## Return Value

The final state value.

## Remarks
This function is named `Fold` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fssamples101/snippet3006.fs)]

### Output

```
Total number of animals: 14
```

The following code example illustrates additional uses of `List.fold`. Note that library functions exist that already encapsulate the functionality implemented below. For example, [`List.sum`](https://msdn.microsoft.com/library/54d47fe3-5ecf-4883-beb5-e915342a17f9) is available to add up all the elements of a list.

[!code-fsharp[Main](snippets/fslists/snippet27.fs)]

**Output**

```
Sum of the elements of list [1; 2; 3] is 6.
List [1; 1; 1] average: 1.000000 stddev: 0.000000
List [1; 2; 1] average: 1.333333 stddev: 0.471405
List [1; 2; 3] average: 2.000000 stddev: 0.816497
0.0
1.0
2.5
5.1
[10; 9; 8; 7; 6; 5; 4; 3; 2; 1]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)