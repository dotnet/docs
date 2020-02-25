---
title: Seq.filter<'T> Function (F#)
description: Seq.filter<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e68c8bf1-8194-4e0d-89d3-839776384e11
---

# Seq.filter<'T> Function (F#)

Returns a new collection containing only the elements of the collection for which the given predicate returns `true`.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Seq

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.filter : ('T -> bool) -> seq<'T> -> seq<'T>

// Usage:
Seq.filter predicate source
```

#### Parameters
*predicate*
Type: **'T -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


A function to test whether each item in the input sequence should be included in the output.


*source*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T&gt;**


The input sequence.

## Exceptions
|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input sequence is null|

## Return Value

The result sequence.

## Remarks
The returned sequence may be passed between threads safely. However, individual `IEnumerator` values generated from the returned sequence should not be accessed concurrently. The sequence is lazily evaluated. Therefore, effects are delayed until it is enumerated.

This function is named `Filter` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example
The following code shows the use of Seq.filter to filter an infinite sequence of random numbers to select only even numbers.

[!code-fsharp[Main](snippets/fssequences/snippet35.fs)]

**Output**

```
2140052690 963487404 467169526 1800517368 1225141818
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
