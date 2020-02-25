---
title: Async.SwitchToThreadPool Method (F#)
description: Async.SwitchToThreadPool Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 503061a5-aa90-4a81-9a80-6dce0fe5c265 
---

# Async.SwitchToThreadPool Method (F#)

Creates an asynchronous computation that queues a work item that runs its continuation.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member SwitchToThreadPool : unit -> Async<unit>

// Usage:
Async.SwitchToThreadPool ()
```

## Return Value

A computation that generates a new work item in the thread pool.

## Remarks
For examples of the use of this method, see [Async.SwitchToContext Method &#40;F&#35;&#41;](Async.SwitchToContext-Method-%5BFSharp%5D.md) and [Async.SwitchToNewThread Method &#40;F&#35;&#41;](Async.SwitchToNewThread-Method-%5BFSharp%5D.md).

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.Async Class &#40;F&#35;&#41;](Control.Async-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)