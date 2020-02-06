---
title: Seq.iter<'T> Function (F#)
description: Seq.iter<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a05dad36-eeed-41dc-8bf4-53390eb38b26
---

# Seq.iter<'T> Function (F#)

Applies the given function to each element of the collection.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Seq

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.iter : ('T -> unit) -> seq<'T> -> unit

// Usage:
Seq.iter action source
```

#### Parameters
*action*
Type: **'T -&gt;**[unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)


A function to apply to each element of the sequence.


*source*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T&gt;**


The input sequence.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input sequence is null.|


## Remarks
This function is named `Iterate` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Examples

[!code-fsharp[Main](snippets/fssamples101/snippet1003.fs)]

```fsharp
Seq.iter: (1, 1) (2, 4) (3, 9) (4, 16) (5, 25)
```

The following example illustrates the use of `Seq.iter` to work with CSV (Comma-Separated Value) files.

[!code-fsharp[Main](snippets/fssamples101/snippet2003.fs)]

```
-------Enumeration 1------
line System.String[]
line System.String[]
-------Enumeration 2------
line has 8 entries
line has 7 entries
-------Enumeration 3------
lengths of entries: [|7; 0; 6; 0; 6; 5; 0; 1|]
lengths of entries: [|5; 0; 6; 0; 4; 0; 2|]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
