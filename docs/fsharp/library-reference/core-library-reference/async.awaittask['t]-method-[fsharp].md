---
title: Async.AwaitTask<'T> Method (F#)
description: Async.AwaitTask<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: cfbd5b98-9557-42bd-b7ef-70826c95a623 
---

# Async.AwaitTask<'T> Method (F#)

Returns an asynchronous computation that waits for the given task to complete and returns its result.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
static member AwaitTask : Task<'T> -> Async<'T>

// Usage:
Async.AwaitTask (task)
```

#### Parameters

*task*

Type: **System.Threading.Tasks.Task&#96;1**

The task to wait for.

## Return Value

Returns an asynchronous computation object.

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information

**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also

[Control.Async Class &#40;F&#35;&#41;](Control.Async-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)

