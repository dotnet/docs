---
title: Seq.item<'T> Function (F#)
description: Seq.item<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: ploeh
manager: danielfe
ms.date: 05/18/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ea57122a-933d-4522-b71e-e910a7021afa
---

# Seq.item<'T> Function (F#)

Computes the *nth* element in the collection.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Seq

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.item : int -> seq<'T> -> 'T

// Usage:
Seq.item index source
```

#### Parameters
*index*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The zero-based index of the element to retrieve.


*source*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T&gt;**


The input sequence.

## Return Value

The result sequence.

## Remarks
This function is named `Item` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fssequences/snippet203.fs)]

**Output:**

```
bar
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
