---
title: Seq.choose<'T,'U> Function (F#)
description: Seq.choose<'T,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: cb00d38c-2a83-4223-b0bf-e2a88fda7aa3
---

# Seq.choose<'T,'U> Function (F#)

Applies the given function to each element of the list and returns the list comprised of the results for each element where the function returns `Some` with some value.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Seq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.choose : ('T -> 'U option) -> seq<'T> -> seq<'U>

// Usage:
Seq.choose chooser source
```

#### Parameters
*chooser*
Type: **'T -&gt; 'U**[option](https://msdn.microsoft.com/library/b08add48-34bf-4410-80a1-ef6a8daddc58)


A function to transform items of type T into options of type U.


*source*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T&gt;**


The input sequence of type T.

## Exceptions
|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input sequence is null|

## Return Value

The result sequence.

## Remarks
The returned sequence may be passed between threads safely. However, individual `IEnumerator` values generated from the returned sequence should not be accessed concurrently.

This function is named `Choose` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

The following code example demonstrates the use of `Seq.choose` to select elements from a sequence by using a lambda expression that uses pattern matching to return an option type.

[!code-fsharp[Main](snippets/fssamples101/snippet1008.fs)]

```fsharp
numbers = seq [1; 2; 3; 4; ...]
evens = seq [2; 4; 6; 8; ...]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
