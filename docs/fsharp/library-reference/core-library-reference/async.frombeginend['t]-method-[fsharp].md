---
title: Async.FromBeginEnd<'T> Method (F#)
description: Async.FromBeginEnd<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d2885861-44a6-444e-b220-f8288882d4ac 
---

# Async.FromBeginEnd<'T> Method (F#)

Creates an asynchronous computation in terms of a `Begin`/`End` pair of actions in the style used in CLI APIs.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
static member FromBeginEnd : (AsyncCallback * obj -> IAsyncResult) * (IAsyncResult -> 'T) * ?(unit -> unit) -> Async<'T>

// Usage:
Async.FromBeginEnd (beginAction, endAction)
Async.FromBeginEnd (beginAction, endAction, cancelAction = cancelAction)
```

#### Parameters

*beginAction*
Type: **System.AsyncCallback &#42; [obj](https://msdn.microsoft.com/library/dcf2430f-702b-40e5-a0a1-97518bf137f7) -&gt; System.IAsyncResult**

The function initiating a traditional CLI asynchronous operation.

*endAction*
Type: **System.IAsyncResult -&gt; 'T**

The function completing a traditional CLI asynchronous operation.

*cancelAction*
Type: **[unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7) -&gt; [unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)**

An optional function to be executed when a cancellation is requested.

## Return Value

Returns an asynchronous computation wrapping the given `Begin`/`End` functions.

## Remarks

For example, the following code creates an asynchronous computation that wraps a web service call.

```fsharp
Async.FromBeginEnd(ws.BeginGetWeather,ws.EndGetWeather)
```

When the computation is run, `beginFunc` is executed, with a callback which represents the continuation of the computation. When the callback is invoked, the overall result is fetched using `endFunc`.

The computation will respond to cancellation while waiting for the completion of the operation. If a cancellation occurs, and `cancelAction` is specified, then it is executed, and the computation continues to wait for the completion of the operation. If `cancelAction` is not specified, cancellation causes the computation to stop immediately, and subsequent invocations of the callback are ignored.

## Example

The following code example shows how to create an F# asynchronous computation from a .NET asynchronous API that uses the Begin/End pattern. The example uses the .NET socket API in `System.Net.Sockets`. It is an implementation of a simple server application that accepts a connection, receives data from a client, and sends a response.

[!code-fsharp[Main](snippets/fsasyncapis/snippet200.fs)]

**Output**

```
Listening...
Accepting...
Receiving...
Received 256 bytes from client computer.
Sending...
Completed.
```

The following code example shows the client code that can be used together with the server code in the previous example.

[!code-fsharp[Main](snippets/fsasyncapis/snippet20.fs)]

**Sample Output**

```
Server address: 192.168.0.1
Connected to remote host.
Sending data...
Receiving data...
Received data from remote host.
255 254 253 252 251 250 249 248 247 246 ...
```

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also

[Control.Async Class &#40;F&#35;&#41;](Control.Async-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)
