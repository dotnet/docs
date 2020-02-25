---
title: Async.RunSynchronously<'T> Method (F#)
description: Async.RunSynchronously<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 91918839-311a-40d3-98c8-43fa6d0317f0 
---

# Async.RunSynchronously<'T> Method (F#)

Runs the provided asynchronous computation and awaits its result.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
static member RunSynchronously : Async<'T> * ?int * ?CancellationToken -> 'T

// Usage:
Async.RunSynchronously (computation)
Async.RunSynchronously (computation, timeout = timeout, cancellationToken = cancellationToken)
```

#### Parameters

*computation*
Type: **[Async](https://msdn.microsoft.com/library/e0b28ea2-dea5-4021-b2b9-d7d4761babde)&lt;'T&gt;**

The computation to run.

*timeout*
Type: **[int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**

The amount of time in milliseconds to wait for the result of the computation before raising a **System.TimeoutException**. If no value is provided for timeout then a default of -1 is used to correspond to **System.Threading.Timeout.Infinite**.

*cancellationToken*
Type: **[CancellationToken](https://msdn.microsoft.com/library/31a3eafe-b61b-46c4-927d-bc9a3ae357c2)**

The cancellation token to be associated with the computation. If one is not supplied, the default cancellation token is used.

## Return Value

Returns the result of the computation.

## Remarks

If an exception occurs in the asynchronous computation then an exception is re-raised by this function. If no cancellation token is provided then the default cancellation token is used. The timeout parameter is given in milliseconds. A value of -1 is equivalent to [`System.Threading.Timeout.Infinite`](https://msdn.microsoft.com/library/system.threading.timeout.infinite.aspx).

If you provide a cancelable cancellation token, the timeout is ignored. Instead, you can implement your own timeout by canceling the operation. A cancellation token is cancelable if its [`System.Threading.CancellationToken.CanBeCanceled`](https://msdn.microsoft.com/library/system.threading.cancellationtoken.canbecanceled.aspx) property is set to `true`.

`Async.RunSynchronously` should not be used on the main thread in asynchronous programming environments, such as request handlers in a web server.

## Example

The following example shows how to use `Async.RunSynchronously` to run an asynchronous computation created by using [`Async.Parallel`](https://msdn.microsoft.com/library/aa9b0355-2d55-4858-b943-cbe428de9dc4), with no timeout.

[!code-fsharp[Main](snippets/fsasyncapis/snippet1.fs)]

[!code-fsharp[Main](snippets/fsasyncapis/snippet2.fs)]

**Sample Output**

```
The operation has timed out.420 write operations completed successfully.
```

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also

[Control.Async Class &#40;F&#35;&#41;](Control.Async-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)
