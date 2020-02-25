---
title: Seq.pairwise<'T> Function (F#)
description: Seq.pairwise<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e79a4c7b-c66d-44fd-8d94-e903f4757ec9
---

# Seq.pairwise<'T> Function (F#)

Returns a sequence of each element in the input sequence and its predecessor, with the exception of the first element which is only returned as the predecessor of the second element.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Seq

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.pairwise : seq<'T> -> seq<'T * 'T>

// Usage:
Seq.pairwise source
```

#### Parameters
*source*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T&gt;**


The input sequence.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input sequence is null.|

## Return Value

The result sequence.

## Remarks
This function is named `Pairwise` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following example demonstrates the use of `Seq.pairwise`. The initial sequence is a sequence of squares up to 100. The `Seq.pairwise` function generates a sequence of tuples of consecutive squares, `{ (1, 4), (4, 9), (9, 16) ... }`. The second part of the example produces a list of the differences in each pair of squares.

[!code-fsharp[Main](snippets/fssequences/snippet18.fs)]

```
(1, 4) (4, 9) (9, 16) (16, 25) (25, 36) (36, 49) (49, 64) (64, 81) (81, 100)
3 5 7 9 11 13 15 17 19
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
