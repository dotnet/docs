---
title: Seq.findIndex<'T> Function (F#)
description: Seq.findIndex<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: fa4703ea-313a-41e8-9e10-f24660737b37
---

# Seq.findIndex<'T> Function (F#)

Returns the index of the first element for which the given function returns `true`.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Seq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.findIndex : ('T -> bool) -> seq<'T> -> int

// Usage:
Seq.findIndex predicate source
```

#### Parameters
*predicate*
Type: **'T -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


A function to test whether the index of a particular element should be returned.


*source*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T&gt;**


The input sequence.

## Exceptions
|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input sequence is null|
|[KeyNotFoundException](https://msdn.microsoft.com/library/system.collections.generic.keynotfoundexception.aspx)|Thrown if no element returns true when evaluated by the predicate|

## Return Value

The index of the first element for which the given function returns true.
## Remarks
This function is named `FindIndex` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example
The following code example shows how to use Seq.findIndex.

[!code-fsharp[Main](snippets/fssequences/snippet37.fs)]

**Output**

The first element that is both a square and a cube is 64 and its index is 62.
## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable




## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
