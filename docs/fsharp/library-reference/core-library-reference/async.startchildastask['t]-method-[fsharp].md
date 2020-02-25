---
title: Async.StartChildAsTask<'T> Method (F#)
description: Async.StartChildAsTask<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: fcc51d5b-30fc-4486-a266-735099154310 
---

# Async.StartChildAsTask<'T> Method (F#)

Creates an asynchronous computation which starts the given computation as a [`System.Threading.Tasks.Task`](https://msdn.microsoft.com/library/system.threading.tasks.task.aspx).

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
static member StartChildAsTask : Async<'T> * ?TaskCreationOptions -> Async<Task<'T>>

// Usage:
Async.StartChildAsTask (computation)
Async.StartChildAsTask (computation, taskCreationOptions = taskCreationOptions)
```

#### Parameters

*computation*
Type: **[Async](https://msdn.microsoft.com/library/e0b28ea2-dea5-4021-b2b9-d7d4761babde)&lt;'T&gt;**

The computation to execute.

*taskCreationOptions*
Type: **System.Threading.Tasks.TaskCreationOptions**

Optional task creation options.

## Return Value

Returns the task wrapped as an asynchronous computation.

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also

[Control.Async Class &#40;F&#35;&#41;](Control.Async-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)