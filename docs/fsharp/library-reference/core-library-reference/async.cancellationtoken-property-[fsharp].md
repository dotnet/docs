---
title: Async.CancellationToken Property (F#)
description: Async.CancellationToken Property (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b2408dc0-213f-4763-a0b0-bcddb3598414 
---

# Async.CancellationToken Property (F#)

Creates an asynchronous computation that returns the cancellation token governing the execution of the computation.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member CancellationToken :  Async<CancellationToken>

// Usage:
Async.CancellationToken
```

## Return Value

Returns an asynchronous computation capable of retrieving the [`System.Threading.CancellationToken`](https://msdn.microsoft.com/library/dd384802.aspx) from a computation expression.

## Remarks

In an asynchronous computation such as the following, a cancellation token can be used to initiate other asynchronous operations that will cancel cooperatively with this workflow.

```fsharp
async { let! token = Async.CancellationToken ...}
```

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also

[Control.Async Class &#40;F&#35;&#41;](Control.Async-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)
