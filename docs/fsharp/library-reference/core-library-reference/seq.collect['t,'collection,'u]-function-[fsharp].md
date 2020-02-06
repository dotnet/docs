---
title: Seq.collect<'T,'Collection,'U> Function (F#)
description: Seq.collect<'T,'Collection,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a904f3e6-bac8-449e-83d1-0b499bdcb733
---

# Seq.collect<'T,'Collection,'U> Function (F#)

Applies the given function to each element of the sequence and concatenates all the results.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Seq

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.collect : ('T -> 'Collection) -> seq<'T> -> seq<'U> (requires 'Collection :> seq<'U>)

// Usage:
Seq.collect mapping source
```

#### Parameters
*mapping*
Type: **'T -&gt; 'Collection**


A function to transform elements of the input sequence into the sequences that are concatenated.


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
The sequence is evaluated lazily. Therefore, effects are delayed until it is enumerated.

This function is named `Collect` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example
The following code demonstrates the use of Seq.collect.

[!code-fsharp[Main](snippets/fssequences/snippet28.fs)]

**Output**

```
-4 -3 -2 -1 1 2 3 4
-12 -4 -2 0 0 2 4 12
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
