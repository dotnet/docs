---
title: Seq.skip<'T> Function (F#)
description: Seq.skip<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 61f03aa6-e08f-466a-b5f0-0dab8944a814
---

# Seq.skip<'T> Function (F#)

Returns a sequence that skips N elements of the underlying sequence and then yields the remaining elements of the sequence.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Seq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.skip : int -> seq<'T> -> seq<'T>

// Usage:
Seq.skip count source
```

#### Parameters
*count*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The number of items to skip.


*source*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T&gt;**


The input sequence.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input sequence is null.|
|[InvalidOperationException](https://msdn.microsoft.com/library/system.invalidoperationexception.aspx)|Thrown when count exceeds the number of elements in the sequence.|

## Return Value

The result sequence.

## Remarks
This function is named `Skip` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following example demonstrates the use of `Seq.skip` to skip the first five squares of a list of squares.

[!code-fsharp[Main](snippets/fssequences/snippet171.fs)]

```
36 49 64 81 100
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable




## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
