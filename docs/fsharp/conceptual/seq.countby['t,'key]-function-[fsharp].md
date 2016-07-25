---
title: Seq.countBy<'T,'Key> Function (F#)
description: Seq.countBy<'T,'Key> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: f742cb1b-fce8-4e18-a235-35e3ff46e012
---

# Seq.countBy<'T,'Key> Function (F#)

Applies a key-generating function to each element of a sequence and returns a sequence yielding unique keys and their number of occurrences in the original sequence.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Seq

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
Seq.countBy : ('T -> 'Key) -> seq<'T> -> seq<'Key * int> (requires equality)

// Usage:
Seq.countBy projection source
```

#### Parameters
*projection*
Type: **'T -&gt; 'Key**

A function transforming each item of input sequence into a key to be compared against the others.

*source*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T&gt;**

The input sequence.

## Exceptions
|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input sequence is null|

## Return Value

A sequence of unique keys and their number of occurrences in the original sequence.

## Remarks
Note that this function returns a sequence that traverses the whole initial sequence as soon as that sequence is iterated. As a result this function should not be used with large or infinite sequences. The function makes no assumption on the ordering of the original sequence.

This function is named `CountBy` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following example demonstrates the use of `Seq.countBy` to determine the number of elements in a sequence that are odd or even.

[!code-fsharp[Main](snippets/fssequences/snippet20.fs)]

**Output**
```
(1, 50) (0, 50)
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
