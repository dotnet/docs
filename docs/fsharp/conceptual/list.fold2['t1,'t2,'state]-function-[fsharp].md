---
title: List.fold2<'T1,'T2,'State> Function (F#)
description: List.fold2<'T1,'T2,'State> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 3c8edaf5-fbbb-4726-900e-b2423c54caf0 
---

# List.fold2<'T1,'T2,'State> Function (F#)

Applies a function to corresponding elements of two collections, threading an accumulator argument through the computation. The collections must have identical sizes. If the input function is `f` and the elements are `i0...iN` and `j0...jN` then computes `f (... (f s i0 j0)...) iN jN`.

**Namespace/Module Path:** Microsoft.FSharp.Collections.List

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.fold2 : ('State -> 'T1 -> 'T2 -> 'State) -> 'State -> 'T1 list -> 'T2 list -> 'State

// Usage:
List.fold2 folder state list1 list2
```

#### Parameters
*folder*
Type: **'State -&gt; 'T1 -&gt; 'T2 -&gt; 'State**


The function to update the state given the input elements.


*state*
Type: **'State**


The initial state.


*list1*
Type: **'T1**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The first input list.


*list2*
Type: **'T2**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The second input list.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown when the input lists differ in length.|

## Return Value

The final state value.

## Remarks
This function is named `Fold2` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fslists/snippet28.fs)]

**Output**

```
The sum of the greater of each pair of elements in the two lists is 8.
```

The following code example illustrates the use of `List.fold2` to compute the ending balance in a bank account after a series of transactions. The two input lists represent the transaction type (deposit or withdrawal) and the transaction amount.

[!code-fsharp[Main](snippets/fslists/snippet29.fs)]

**Output**

```
1205.000000
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)