---
title: Async.StartAsTask<'T> Method (F#)
description: Async.StartAsTask<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 401ec537-0d71-4729-9b84-0b6a8f612f3e 
---

# Async.StartAsTask<'T> Method (F#)

Executes a computation in the thread pool. Returns a [`System.Threading.Tasks.Task`](https://msdn.microsoft.com/library/system.threading.tasks.task.aspx) that will be completed in the corresponding state once the computation terminates (produces the result, throws exception or gets canceled) If no cancellation token is provided then the default cancellation token is used.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
static member StartAsTask : Async<'T> * ?TaskCreationOptions * ?CancellationToken -> Task<'T>

// Usage:
Async.StartAsTask (computation)
Async.StartAsTask (computation, taskCreationOptions = taskCreationOptions, cancellationToken = cancellationToken)
```

#### Parameters

*computation*
Type: **[Async](https://msdn.microsoft.com/library/e0b28ea2-dea5-4021-b2b9-d7d4761babde)&lt;'T&gt;**

The computation to execute.

*taskCreationOptions*
Type: **System.Threading.Tasks.TaskCreationOptions**

Optional task creation options.

*cancellationToken*
Type: **System.Threading.CancellationToken**

Optional cancellation token.

## Return Value

Returns a System.Threading.Tasks.Task&lt;'T&gt; object that represents the given computation.

## Example

The following code example demonstrates the use of `Async.StartAsTask`.

[!code-fsharp[Main](snippets/fsasyncapis/snippet330.fs)]

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also

[Control.Async Class &#40;F&#35;&#41;](Control.Async-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)
