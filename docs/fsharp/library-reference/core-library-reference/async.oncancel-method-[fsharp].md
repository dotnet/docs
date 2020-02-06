---
title: Async.OnCancel Method (F#)
description: Async.OnCancel Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: c7065610-10e7-42db-9503-68a534dff61e 
---

# Async.OnCancel Method (F#)

Generates a scoped, cooperative cancellation handler for use within an asynchronous workflow.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member OnCancel : (unit -> unit) -> Async<IDisposable>

// Usage:
Async.OnCancel (interruption)
```

#### Parameters
*interruption*
Type: [unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)**-&gt;**[unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)


The function that is executed on the thread performing the cancellation.

## Return Value

An asynchronous computation that triggers the interruption if it is cancelled before being disposed.

## Remarks
For example, the following code generates an asynchronous computation where, if a cancellation happens any time during the execution of the asynchronous computation in the scope of `holder`, then action `interruption` is executed on the thread that is performing the cancellation. This can be used to arrange for a computation to be asynchronously notified that a cancellation has occurred, for example, by setting a flag, or deregistering a pending I/O action.

```fsharp
async { use! holder = Async.OnCancel interruption ... }
```

## Example

The following code example demonstrates the use of `Async.OnCancel`.

[!code-fsharp[Main](snippets/fsasyncapis/snippet8.fs)]

**Output**

```
Started computations.
Sending cancellation signal.
Canceling operation.
Canceling operation.
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.Async Class &#40;F&#35;&#41;](Control.Async-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)