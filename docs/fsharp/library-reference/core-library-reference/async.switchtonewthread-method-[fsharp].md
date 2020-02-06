---
title: Async.SwitchToNewThread Method (F#)
description: Async.SwitchToNewThread Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: dbe91455-1e84-41ca-a5c0-f69af1f9e2aa 
---

# Async.SwitchToNewThread Method (F#)

Creates an asynchronous computation that creates a new thread and runs its continuation in that thread.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member SwitchToNewThread : unit -> Async<unit>

// Usage:
Async.SwitchToNewThread ()
```

## Return Value

A computation that will execute on a new thread.

## Example

The following code example shows how to use `Async.SwitchToNewThread` and [`Async.SwitchToThreadPool`](https://msdn.microsoft.com/library/c2708739-5389-487a-a3c9-490f417bcdc6) to wrap a synchronous method call as an asynchronous method.

[!code-fsharp[Main](snippets/fsasyncapis/snippet28.fs)]

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.Async Class &#40;F&#35;&#41;](Control.Async-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)