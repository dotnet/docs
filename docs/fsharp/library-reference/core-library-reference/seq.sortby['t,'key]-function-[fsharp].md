---
title: Seq.sortBy<'T,'Key> Function (F#)
description: Seq.sortBy<'T,'Key> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 5ca6e225-ea08-4709-813b-3bb8da6cd7e9
---

# Seq.sortBy<'T,'Key> Function (F#)

Applies a key-generating function to each element of a sequence and yields a sequence ordered by keys. The keys are compared using generic comparison as implemented by [Operators.compare](https://msdn.microsoft.com/library/295e1320-0955-4c3d-ac31-288fa80a658c).

**Namespace/Module Path**: Microsoft.FSharp.Collections.Seq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.sortBy : ('T -> 'Key) -> seq<'T> -> seq<'T> (requires comparison)

// Usage:
Seq.sortBy projection source
```

#### Parameters
*projection*
Type: **'T -&gt; 'Key**


A function to transform items of the input sequence into comparable keys.


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
This function returns a sequence that digests the whole initial sequence as soon as that sequence is iterated. Therefore, this function should not be used with large or infinite sequences. The function makes no assumption on the ordering of the original sequence. This is a stable sort, that is, the original order of equal elements is preserved.

This function is named `SortBy` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable




## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
