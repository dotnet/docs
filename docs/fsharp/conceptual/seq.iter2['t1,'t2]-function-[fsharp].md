---
title: Seq.iter2<'T1,'T2> Function (F#)
description: Seq.iter2<'T1,'T2> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 33c4a8df-4a6e-4a28-90a7-fc836cb22c57
---

# Seq.iter2<'T1,'T2> Function (F#)

Applies the given function to two collections simultaneously. If one sequence is shorter than the other then the remaining elements of the longer sequence are ignored.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Seq

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.iter2 : ('T1 -> 'T2 -> unit) -> seq<'T1> -> seq<'T2> -> unit

// Usage:
Seq.iter2 action source1 source2
```

#### Parameters
*action*
Type: **'T1 -&gt; 'T2 -&gt;**[unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)


A function to apply to each pair of elements from the input sequences.


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

## Remarks
This function is named `Iterate2` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## Example

The following code shows how to use `Seq.iter2` and compares its behavior to related functions.

[!code-fsharp[Main](snippets/fssequences/snippet43.fs)]

**Output**

```
Seq.iter: element is 1
Seq.iter: element is 2
Seq.iter: element is 3
Seq.iteri: element 0 is 1
Seq.iteri: element 1 is 2
Seq.iteri: element 2 is 3
Seq.iter2: elements are 1 4
Seq.iter2: elements are 2 5
Seq.iter2: elements are 3 6
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable




## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
