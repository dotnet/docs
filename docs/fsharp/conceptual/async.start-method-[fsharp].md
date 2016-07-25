---
title: Async.Start Method (F#)
description: Async.Start Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e01561dc-31e8-44e0-b0d4-4308f3d55998 
---

# Async.Start Method (F#)

Starts the asynchronous computation in the thread pool. Do not await its result.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member Start : Async<unit> * ?CancellationToken -> unit

// Usage:
Async.Start (computation)
Async.Start (computation, cancellationToken = cancellationToken)
```

#### Parameters
*computation*
Type: [Async](https://msdn.microsoft.com/library/e0b28ea2-dea5-4021-b2b9-d7d4761babde)**&lt;**[unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)**&gt;**


The computation to run asynchronously.


*cancellationToken*
Type: [CancellationToken](https://msdn.microsoft.com/library/31a3eafe-b61b-46c4-927d-bc9a3ae357c2)


The cancellation token to be associated with the computation. If one is not supplied, the default cancellation token is used.


## Remarks
If no cancellation token is provided then the default cancellation token is used.

## Example

The following code example shows how to start an asynchronous computation on the thread pool.

[!code-fsharp[Main](snippets/fsasyncapis/snippet31.fs)]

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.Async Class &#40;F&#35;&#41;](Control.Async-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)