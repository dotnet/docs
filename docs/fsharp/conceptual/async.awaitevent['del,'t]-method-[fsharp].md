---
title: Async.AwaitEvent<'Del,'T> Method (F#)
description: Async.AwaitEvent<'Del,'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 51f1fbee-4f88-486f-b5a9-e77c86146b5d 
---

# Async.AwaitEvent<'Del,'T> Method (F#)

Creates an asynchronous computation that waits for a single invocation of a CLI event by adding a handler to the event. Once the computation completes or is cancelled, the handler is removed from the event.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member AwaitEvent : IEvent<'Del,'T> * ?(unit -> unit) -> Async<'T> (requires delegate)

// Usage:
Async.AwaitEvent (event)
Async.AwaitEvent (event, cancelAction = cancelAction)
```

#### Parameters
*event*
Type: [IEvent](https://msdn.microsoft.com/library/8dbca0df-f8a1-40bd-8d50-aa26f6a8b862)**&lt;'Del,'T&gt;**


The event to handle once.


*cancelAction*
Type: **(**[unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)**-&gt;**[unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)**)**


An optional function to execute instead of cancelling when a cancellation is issued.

## Return Value

An asynchronous computation that waits for the event to be invoked.

## Remarks
The computation will respond to cancellation while waiting for the event. If a cancellation occurs, and `cancelAction` is specified, then it is executed, and the computation continues to wait for the event. If `cancelAction` is not specified, then cancellation causes the computation to cancel immediately.

## Example

The following code example demonstrates how to use `Async.AwaitEvent` to set up a file operation that runs in response to an event that indicates that a file is changed. In this case, waiting for the event prevents an attempt to access the file while it is locked.

[!code-fsharp[Main](snippets/fsasyncapis/snippet14.fs)]

**Sample Output**

```
Creating file Waiting for file sylongoutput.dat.
stem watcher notification.
Attempting to write to file longoutput.dat.
The file longoutput.dat is changed.
The file longoutput.dat is changed.
Attempting to open and read file longoutput.dat.
Successfully read file longoutput.dat.
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Control.Async Class &#40;F&#35;&#41;](Control.Async-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)