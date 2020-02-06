---
title: Seq.delay<'T> Function (F#)
description: Seq.delay<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 8de7fb6f-6051-4f25-b133-74a1d10a88ca
---

# Seq.delay<'T> Function (F#)

Returns a sequence that is built from the given delayed specification of a sequence.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Seq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.delay : (unit -> seq<'T>) -> seq<'T>

// Usage:
Seq.delay generator
```

#### Parameters
*generator*
Type: [unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)**-&gt;**[seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T&gt;**


The generating function for the sequence.

## Return Value

The resulting sequence.

## Remarks
The input function is evaluated each time an `IEnumerator` for the sequence is requested.

This function is named `Delay` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code shows how to use `Seq.delay` to delay the evaluation of a sequence that is created from a collection that is normally evaluated immediately.

[!code-fsharp[Main](snippets/fssequences/snippet30.fs)]

**Output**

```
Calling makeSequence.
Printing sequences.
Squares:
Evaluating 4.
Evaluating 3.
Evaluating 2.
Evaluating 1.
Evaluating 0.16 9 4 1 Cubes:Evaluating 4.
Evaluating 3.
Evaluating 2.
Evaluating 1.
Evaluating 0.
64 27 8 1
```

The following code example is equivalent to the previous example, except that it does not use `Seq.delay`. Notice the difference in the output.

[!code-fsharp[Main](snippets/fssequences/snippet31.fs)]

**Output**

```
Calling makeSequence.
Evaluating 4.
Evaluating 3.
Evaluating 2.
Evaluating 1.
Evaluating 0.
Evaluating 4.
Evaluating 3.
Evaluating 2.
Evaluating 1.
Evaluating 0.
Printing sequences.
Squares:
16 9 4 1
Cubes:
64 27 8 1
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
