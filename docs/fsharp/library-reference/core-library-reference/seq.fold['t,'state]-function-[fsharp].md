---
title: Seq.fold<'T,'State> Function (F#)
description: Seq.fold<'T,'State> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 8774ee16-8663-4996-855b-11145265f6b2
---

# Seq.fold<'T,'State> Function (F#)

Applies a function to each element of the collection, threading an accumulator argument through the computation. If the input function is `f` and the elements are `i0...iN`, then this function computes `f (... (f s i0)...) iN`.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Seq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.fold : ('State -> 'T -> 'State) -> 'State -> seq<'T> -> 'State

// Usage:
Seq.fold folder state source
```

#### Parameters
*folder*
Type: **'State -&gt; 'T -&gt; 'State**


A function that updates the state with each element from the sequence.


*state*
Type: **'State**


The initial state.


*source*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T&gt;**


The input sequence.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input sequence is null.|

## Return Value

The final result of the computation.
## Remarks
This function is named `Fold` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code shows how to use `Seq.fold` to implement a function that computes the sum of the elements of a sequence.

[!code-fsharp[Main](snippets/fssequences/snippet38.fs)]

**Output**

```
The sum of the elements is 285.
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
