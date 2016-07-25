---
title: Async.StartChild<'T> Method (F#)
description: Async.StartChild<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: bf0a42ca-4aca-4ab9-8519-335f52d7c4de 
---

# Async.StartChild<'T> Method (F#)

Starts a child computation within an asynchronous workflow. This allows multiple asynchronous computations to be executed simultaneously.

**Namespace/Module Path**: Microsoft.FSharp.Control

**Assembly**: FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
static member StartChild : Async<'T> * ?int -> Async<Async<'T>>

// Usage:
Async.StartChild (computation)
Async.StartChild (computation, millisecondsTimeout = millisecondsTimeout)
```

#### Parameters

*computation*
Type: **[Async](https://msdn.microsoft.com/library/e0b28ea2-dea5-4021-b2b9-d7d4761babde)&lt;'T&gt;**

The child computation.

*millisecondsTimeout*
Type: **[int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**

The timeout value in milliseconds. If one is not provided then the default value is -1, which corresponds to [`System.Threading.Timeout.Infinite`](https://msdn.microsoft.com/library/system.threading.timeout.infinite.aspx).

## Return Value

Returns a new computation that waits for the input computation to finish.

## Remarks

This method should normally be used as the immediate right-hand-side of a `let!` binding in an F# asynchronous workflow, that is:

```fsharp
async { 
...
let! completor1 = childComputation1
|> Async.StartChild
let! completor2 = childComputation2
|> Async.StartChild
... 
let! result1 = completor1
let! result2 = completor2
... }
```

When used in this way, each use of `StartChild` starts an instance of `childComputation` and returns a `completor` object representing a computation to wait for the completion of the operation. When executed, the `completor` awaits the completion of `childComputation`.

## Example

The following code example illustrates the use of `Async.StartChild`.

[!code-fsharp[Main](snippets/fsasyncapis/snippet4.fs)]

**Sample Output**

```
The output is interleaved because the jobs are running simultaneously.
ComplParent job start.
eted execution.
Child job start: Child job slongoutput1.dat
tart: longoutput2.dat
Child job end: longoutput2.dat
Child job end: longoutput1.dat
Parent job end.
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also

[Control.Async Class &#40;F&#35;&#41;](Control.Async-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)
