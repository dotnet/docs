---
title: Seq.exists2<'T1,'T2> Function (F#)
description: Seq.exists2<'T1,'T2> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: bc387ec1-4dc1-43b2-b971-bd291c186cd6
---

# Seq.exists2<'T1,'T2> Function (F#)

Tests if any pair of corresponding elements of the input sequences satisfies the given predicate.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Seq

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.exists2 : ('T1 -> 'T2 -> bool) -> seq<'T1> -> seq<'T2> -> bool

// Usage:
Seq.exists2 predicate source1 source2
```

#### Parameters
*predicate*
Type: **'T1 -&gt; 'T2 -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


A function to test each pair of items from the input sequences.


*source1*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T1&gt;**


The first input sequence.


*source2*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T2&gt;**


The second input sequence.

## Exceptions
|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when either of the two input sequences is null.|

## Return Value
The predicate is applied to matching elements in the two sequences up to the lesser of the two lengths of the collections. If any application returns true then the overall result is true and no further elements are tested. Otherwise, false is returned.

## Remarks
If one sequence is shorter than the other then the remaining elements of the longer sequence are ignored.

This function is named `Exists2` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

```fsharp
// Use Seq.exists2 to compare elements in two sequences.
// isEqualElement returns true if any elements at the same position in two supplied
// sequences match.
let isEqualElement seq1 seq2 = Seq.exists2 (fun elem1 elem2 -> elem1 = elem2) seq1 seq2
let seq1to5 = seq { 1 .. 5 }
let seq5to1 = seq { 5 .. -1 .. 1 }
if (isEqualElement seq1to5 seq5to1) then
    printfn "Sequences %A and %A have at least one equal element at the same position." seq1to5 seq5to1
else
    printfn "Sequences %A and %A do not have any equal elements that are at the same position." seq1to5 seq5to1
```

**Output**

```
Sequences seq [1; 2; 3; 4; ...] and seq [5; 4; 3; 2; ...] have at least one equal element at the same position.
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
