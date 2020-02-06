---
title: AsyncBuilder.TryFinally<'T> Method (F#)
description: AsyncBuilder.TryFinally<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a1a3f314-a637-41a8-aca7-573a9d91f366 
---

# AsyncBuilder.TryFinally<'T> Method (F#)

Implements `try...finally` in asynchronous computations.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.TryFinally : Async<'T> * (unit -> unit) -> Async<'T>

// Usage:
asyncBuilder.TryFinally (computation, compensation)
```

#### Parameters
*computation*
Type: [Async](https://msdn.microsoft.com/library/e0b28ea2-dea5-4021-b2b9-d7d4761babde)**&lt;'T&gt;**


The input computation.


*compensation*
Type: [unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)**-&gt;**[unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)


The action to be run after `computation` completes or raises an exception (including cancellation).

## Return Value

An asynchronous computation that executes computation and compensation aftewards or when an exception is raised.

## Remarks
Creates an asynchronous computation that runs `computation`. The action `compensation` is executed after `computation` completes, whether `computation` exits normally or by an exception. If `compensation` raises an exception itself the original exception is discarded and the new exception becomes the overall result of the computation.

A cancellation check is performed when the computation is executed. The existence of this method permits the use of `try...finally` in the `async { ... }` computation expression syntax.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.AsyncBuilder Class &#40;F&#35;&#41;](Control.AsyncBuilder-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)