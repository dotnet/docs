---
title: Seq.map2<'T1,'T2,'U> Function (F#)
description: Seq.map2<'T1,'T2,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 32772be2-57a9-4c70-a719-ded64dd75b2f
---

# Seq.map2<'T1,'T2,'U> Function (F#)

Creates a new collection whose elements are the results of applying the given function to the corresponding pairs of elements from the two sequences. If one input sequence is shorter than the other then the remaining elements of the longer sequence are ignored.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Seq

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.map2 : ('T1 -> 'T2 -> 'U) -> seq<'T1> -> seq<'T2> -> seq<'U>

// Usage:
Seq.map2 mapping source1 source2
```

#### Parameters
*mapping*
Type: **'T1 -&gt; 'T2 -&gt; 'U**


A function to transform pairs of items from the input sequences.


*source1*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T1&gt;**


The first input sequence.


*source2*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T2&gt;**


The second input sequence.


## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input sequence is null.|

## Return Value

The result sequence.

## Remarks
This function is named `Map2` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable




## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
