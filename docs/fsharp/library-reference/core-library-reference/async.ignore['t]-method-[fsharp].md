---
title: Async.Ignore<'T> Method (F#)
description: Async.Ignore<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: addbbfa8-f010-4177-bae9-4dd04c5f69d2 
---

# Async.Ignore<'T> Method (F#)

Creates an asynchronous computation that runs the given computation and ignores its result.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member Ignore : Async<'T> -> Async<unit>

// Usage:
Async.Ignore (computation)
```

#### Parameters
*computation*
Type: [Async](https://msdn.microsoft.com/library/e0b28ea2-dea5-4021-b2b9-d7d4761babde)**&lt;'T&gt;**


The input computation.

## Return Value

A computation that is equivalent to the input computation, but disregards the result.

## Example

The following code example illustrates the use of `Async.Ignore`.

[!code-fsharp[Main](snippets/fsasyncapis/snippet34.fs)]

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.Async Class &#40;F&#35;&#41;](Control.Async-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)