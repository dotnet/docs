---
title: AsyncBuilder.Bind<'T,'U> Method (F#)
description: AsyncBuilder.Bind<'T,'U> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 5fb69d93-44aa-4c8f-8511-153513efb388 
---

# AsyncBuilder.Bind<'T,'U> Method (F#)

Implements **let!** in asynchronous computations.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Bind : Async<'T> * ('T -> Async<'U>) -> Async<'U>

// Usage:
asyncBuilder.Bind (computation, binder)
```

#### Parameters
*computation*
Type: [Async](https://msdn.microsoft.com/library/e0b28ea2-dea5-4021-b2b9-d7d4761babde)**&lt;'T&gt;**


The computation to provide an unbound result.


*binder*
Type: **'T -&gt;**[Async](https://msdn.microsoft.com/library/e0b28ea2-dea5-4021-b2b9-d7d4761babde)**&lt;'U&gt;**


The function to bind the result of `computation`.

## Return Value

An asynchronous computation that performs a monadic bind on the result of computation.

## Remarks
Creates an asynchronous computation that runs `computation`, and when the computation generates a result, passes the result to `binder` that binds the result of the computation to a value.

A cancellation check is performed when the computation is executed. The existence of this method permits the use of `let!` in the `async { ... }` computation expression syntax.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.AsyncBuilder Class &#40;F&#35;&#41;](Control.AsyncBuilder-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)