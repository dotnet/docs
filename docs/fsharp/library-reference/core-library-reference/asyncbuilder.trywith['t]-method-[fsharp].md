---
title: AsyncBuilder.TryWith<'T> Method (F#)
description: AsyncBuilder.TryWith<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 43015ec0-93c8-4b78-841d-2be332daaf44 
---

# AsyncBuilder.TryWith<'T> Method (F#)

Implements **try...with** in asynchronous computations.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.TryWith : Async<'T> * (exn -> Async<'T>) -> Async<'T>

// Usage:
asyncBuilder.TryWith (computation, catchHandler)
```

#### Parameters
*computation*
Type: [Async](https://msdn.microsoft.com/library/e0b28ea2-dea5-4021-b2b9-d7d4761babde)**&lt;'T&gt;**


The input computation.


*catchHandler*
Type: [exn](https://msdn.microsoft.com/library/e1569b69-3b30-440b-8c6f-966d1c6a06ab)**-&gt;**[Async](https://msdn.microsoft.com/library/e0b28ea2-dea5-4021-b2b9-d7d4761babde)**&lt;'T&gt;**


The function to run when `computation` throws an exception.

## Return Value

An asynchronous computation that executes computation and calls catchHandler if an exception is thrown.

## Remarks
This function creates an asynchronous computation that runs `computation` and returns its result. If an exception happens then `catchHandler(exn)` is called and the resulting computation executed instead.

A cancellation check is performed when the computation is executed. The existence of this method permits the use of `try...with` in the `async { ... }` computation expression syntax.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.AsyncBuilder Class &#40;F&#35;&#41;](Control.AsyncBuilder-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)