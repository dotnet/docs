---
title: Seq.forall2<'T1,'T2> Function (F#)
description: Seq.forall2<'T1,'T2> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 135c9673-412e-4fad-bb54-3763a7523141
---

# Seq.forall2<'T1,'T2> Function (F#)

Tests whether all the pairs of elements drawn from the two sequences satisfy the given predicate. If one sequence is shorter than the other then the remaining elements of the longer sequence are ignored.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Seq

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.forall2 : ('T1 -> 'T2 -> bool) -> seq<'T1> -> seq<'T2> -> bool

// Usage:
Seq.forall2 predicate source1 source2
```

#### Parameters
*predicate*
Type: **'T1 -&gt; 'T2 -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


A function to test pairs of elements from the input sequences.


*source1*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T1&gt;**


The first input sequence.


*source2*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T2&gt;**


The second input sequence.
## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown when the input sequence is empty.|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input sequence is null.|

## Return Value

`true` if all element pairs in the sequences satisfy the given predicate. Otherwise, returns `false`.

## Remarks
This function is named `ForAll2` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example
The following code shows how to use Seq.forall2.

[!code-fsharp[Main](snippets/fssequences/snippet40.fs)]

**Output**
```
true
false
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable




## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
