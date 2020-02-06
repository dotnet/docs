---
title: AsyncBuilder.Using<'T,'U> Method (F#)
description: AsyncBuilder.Using<'T,'U> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 9e0198f1-2ee5-4f78-9cd0-d73f5aae17b4 
---

# AsyncBuilder.Using<'T,'U> Method (F#)

Implements the `use` and `use!` keywords in asynchronous computation expressions.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Using : 'T * ('T -> Async<'U>) -> Async<'U> (requires 'T :> IDisposable)

// Usage:
asyncBuilder.Using (resource, binder)
```

#### Parameters
*resource*
Type: **'T**


The resource to be used and disposed.


*binder*
Type: **'T -&gt;**[Async](https://msdn.microsoft.com/library/e0b28ea2-dea5-4021-b2b9-d7d4761babde)**&lt;'U&gt;**


The function that takes the resource and returns an asynchronous computation.

## Return Value

An asynchronous computation that binds and eventually disposes resource.

## Remarks
Creates an asynchronous computation that runs `binder(resource)`. The action `resource.Dispose()` is executed as this computation yields its result or if the asynchronous computation exits by an exception or by cancellation.

A cancellation check is performed when the computation is executed. The existence of this method permits the use of `use` and `use!` in the `async { ... }` computation expression syntax.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.AsyncBuilder Class &#40;F&#35;&#41;](Control.AsyncBuilder-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)