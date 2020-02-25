---
title: Seq.cast<'T> Function (F#)
description: Seq.cast<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d1145bec-3a13-4d9a-a2c9-58b934eb333e
---

# Seq.cast<'T> Function (F#)

Wraps a weakly typed `System.Collections` sequence as a typed sequence.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Seq

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.cast : IEnumerable -> seq<'T>

// Usage:
Seq.cast source
```

#### Parameters
*source*
Type: **System.Collections.IEnumerable**


The input sequence.

## Exceptions
|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input sequence is null|

## Return Value

The result sequence.

## Remarks
The use of this function usually requires a type annotation. An incorrect type annotation may result in runtime type errors. Individual `System.Collections.Generic.IEnumerator<T>` values generated from the returned sequence should not be accessed concurrently.

This function is named `Cast` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code demonstrates the use of `Seq.cast` to convert a weakly typed `System.Collections.ArrayList`, where the element type is just `System.Object`, into a sequence of int.

[!code-fsharp[Main](snippets/fssequences/snippet12.fs)]

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
