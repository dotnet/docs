---
title: AsyncBuilder.Combine<'T> Method (F#)
description: AsyncBuilder.Combine<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 231e83d2-49a1-4549-9429-1f494ee92d50 
---

# AsyncBuilder.Combine<'T> Method (F#)

Creates an asynchronous computation that first runs one computation and then runs another computation, returning the result of the second computation.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Combine : Async<unit> * Async<'T> -> Async<'T>

// Usage:
asyncBuilder.Combine (computation1, computation2)
```

#### Parameters
*computation1*
Type: [Async](https://msdn.microsoft.com/library/e0b28ea2-dea5-4021-b2b9-d7d4761babde)**&lt;**[unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)**&gt;**


The first part of the sequenced computation.


*computation2*
Type: [Async](https://msdn.microsoft.com/library/e0b28ea2-dea5-4021-b2b9-d7d4761babde)**&lt;'T&gt;**


The second part of the sequenced computation.

## Return Value

An asynchronous computation that runs both of the computations sequentially.

## Remarks
A cancellation check is performed when the computation is executed. The existence of this method permits the use of expression sequencing in the `async { ... }` computation expression syntax.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.AsyncBuilder Class &#40;F&#35;&#41;](Control.AsyncBuilder-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)