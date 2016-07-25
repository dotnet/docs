---
title: Async.FromBeginEnd<'Arg1,'T> Method (F#)
description: Async.FromBeginEnd<'Arg1,'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: c9b96191-8dbf-4345-8c70-4779d7acc52d 
---

# Async.FromBeginEnd<'Arg1,'T> Method (F#)

Creates an asynchronous computation in terms of a `Begin`/`End` pair of actions in the style used in CLI APIs.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
static member FromBeginEnd : 'Arg1 * ('Arg1 * AsyncCallback * obj -> IAsyncResult) * (IAsyncResult -> 'T) * ?(unit -> unit) -> Async<'T>

// Usage:
Async.FromBeginEnd (arg, beginAction, endAction)
Async.FromBeginEnd (arg, beginAction, endAction, cancelAction = cancelAction)
```

#### Parameters

*arg*
Type: **'Arg1**

The argument for the operation.

*beginAction*
Type: **'Arg1 &#42; System.AsyncCallback &#42; [obj](https://msdn.microsoft.com/library/dcf2430f-702b-40e5-a0a1-97518bf137f7) -&gt; System.IAsyncResult**

The function initiating a traditional CLI asynchronous operation.

*endAction*
Type: **System.IAsyncResult -&gt; 'T**

The function completing a traditional CLI asynchronous operation.

*cancelAction*
Type: **[unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7) -&gt; [unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)**

An optional function to be executed when a cancellation is requested.

## Return Value

An asynchronous computation wrapping the given Begin/End functions.


## Remarks

This overload should be used if the operation is qualified by one argument. For example, you can create an asynchronous computation for a web service call with the following code.

```fsharp
Async.FromBeginEnd(place,ws.BeginGetWeather,ws.EndGetWeather)
```

When the computation is run, `beginFunc` is executed, with a callback which represents the continuation of the computation. When the callback is invoked, the overall result is fetched using `endFunc`.

The computation will respond to cancellation while waiting for the completion of the operation. If a cancellation occurs, and `cancelAction` is specified, then it is executed, and the computation continues to wait for the completion of the operation. If `cancelAction` is not specified, then cancellation causes the computation to stop immediately, and subsequent invocations of the callback are ignored.

For an example, see [Async.FromBeginEnd&lt;'T&gt; Method (F#)](https://msdn.microsoft.com/library/eb24fcb5-36fb-4c9b-8343-02148b327b56).

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also

[Control.Async Class &#40;F&#35;&#41;](Control.Async-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)