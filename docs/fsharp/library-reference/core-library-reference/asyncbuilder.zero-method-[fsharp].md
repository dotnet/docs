---
title: AsyncBuilder.Zero Method (F#)
description: AsyncBuilder.Zero Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 50a43b6a-da58-4baa-8fd4-e270042eccc0 
---

# AsyncBuilder.Zero Method (F#)

Creates an asynchronous computation that does nothing and returns `()`.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Zero : unit -> Async<unit>

// Usage:
asyncBuilder.Zero ()
```

## Return Value

An asynchronous computation ([`Async`](https://msdn.microsoft.com/library/03eb4d12-a01a-4565-a077-5e83f17cf6f7) object) that returns `()`.

## Remarks
A cancellation check is performed when the computation is executed. The existence of this method permits the use of empty `else` branches in the `async { ... }` computation expression syntax.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.AsyncBuilder Class &#40;F&#35;&#41;](Control.AsyncBuilder-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)