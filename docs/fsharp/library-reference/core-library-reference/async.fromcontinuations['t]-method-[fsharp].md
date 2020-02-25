---
title: Async.FromContinuations<'T> Method (F#)
description: Async.FromContinuations<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: fc3cba06-5f4a-4f21-bb48-d1b6e085811c 
---

# Async.FromContinuations<'T> Method (F#)

Creates an asynchronous computation that captures the current success, exception and cancellation continuations. The callback must eventually call exactly one of the given continuations.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member FromContinuations : (('T -> unit) * (exn -> unit) * (OperationCanceledException -> unit) -> unit) -> Async<'T>

// Usage:
Async.FromContinuations (callback)
```

#### Parameters

*callback*
Type: **('T -&gt; [unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)) &#42; ([exn](https://msdn.microsoft.com/library/e1569b69-3b30-440b-8c6f-966d1c6a06ab) -&gt; [unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)) &#42; (System.OperationCanceledException -&gt; [unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)) -&gt; [unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)**

The function that accepts the current success, exception, and cancellation continuations.

## Return Value

Returns an asynchronous computation that provides the callback with the current continuations.

## Remarks

The argument for this method is a lambda expression that takes three continuation functions, which are typically called `cont` (the success continuation), `ccont` (the cancel continuation) and `econt` (the error continuation), as the following code shows:

```fsharp
Async.FromContinuations (fun (cont, ccont, econt) -> ...)
```

>[!WARNING] 
If you use this method, you must call exactly one of the continuation functions or else throw an exception, in which case F# calls `econt` with the exception on your behalf. If you call more than one continuation, call any continuation more than once, or both call a continuation and throw an exception, any subsequent use of the resulting async object may have undefined behavior.

## Example

The following example illustrates how to use `Async.FromContinuations` to wrap an event-based asynchronous computation as an F# async.

[!code-fsharp[Main](snippets/fsasyncapis/snippet23.fs)]

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also

[Control.Async Class &#40;F&#35;&#41;](Control.Async-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)