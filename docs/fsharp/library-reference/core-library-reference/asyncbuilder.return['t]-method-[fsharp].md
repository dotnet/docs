---
title: AsyncBuilder.Return<'T> Method (F#)
description: AsyncBuilder.Return<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: cdae536d-ccac-47ad-97e8-9c39450786c5 
---

# AsyncBuilder.Return<'T> Method (F#)

Implements the `return` expression in asynchronous computations. Creates an asynchronous computation that returns a result.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Return : 'T -> Async<'T>

// Usage:
asyncBuilder.Return (value)
```

#### Parameters
*value*
Type: **'T**


The value to return from the computation.

## Return Value

An asynchronous computation ([`Async`](https://msdn.microsoft.com/library/03eb4d12-a01a-4565-a077-5e83f17cf6f7) object) that returns value when executed.
## Remarks
A cancellation check is performed when the computation is executed. The existence of this method permits the use of `return` in the `async { ... }` computation expression syntax.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.AsyncBuilder Class &#40;F&#35;&#41;](Control.AsyncBuilder-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)