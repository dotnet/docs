---
title: List.foldBack2<'T1,'T2,'State> Function (F#)
description: List.foldBack2<'T1,'T2,'State> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 5b84c2a5-18db-44dc-9c5c-f83664672e45 
---

# List.foldBack2<'T1,'T2,'State> Function (F#)

Applies a function to corresponding elements of two collections, threading an accumulator argument through the computation. The collections must have identical sizes. If the input function is `f` and the elements are `i0...iN` and `j0...jN`, then this function computes `f i0 j0 (...(f iN jN s))`.

**Namespace/Module Path:** Microsoft.FSharp.Collections.List

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.foldBack2 : ('T1 -> 'T2 -> 'State -> 'State) -> 'T1 list -> 'T2 list -> 'State -> 'State

// Usage:
List.foldBack2 folder list1 list2 state
```

#### Parameters
*folder*
Type: **'T1 -&gt; 'T2 -&gt; 'State -&gt; 'State**


The function to update the state given the input elements.


*list1*
Type: **'T1**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The first input list.


*list2*
Type: **'T2**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The second input list.


*state*
Type: **'State**


The initial state.


## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown when the list is empty.|

## Return Value

The final state value.

## Remarks
This function is named `FoldBack2` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## Example
The following code examples illustrate the difference between [`List.fold2`](https://msdn.microsoft.com/library/6cfcd043-a65d-4423-805a-2ab234cb5343) and `List.foldBack2`.

[!code-fsharp[Main](snippets/fslists/snippet31.fs)]

**Output**

```
1210.020833
```

[!code-fsharp[Main](snippets/fslists/snippet32.fs)]

**Output**

```
1205.833333
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)