---
title: Async.Parallel<'T> Method (F#)
description: Async.Parallel<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e6e1b404-ac6c-40d2-843d-acaab83ad6ab 
---

# Async.Parallel<'T> Method (F#)

Creates an asynchronous computation that executes all the given asynchronous computations, initially queueing each as work items and using a fork/join pattern.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member Parallel : seq<Async<'T>> -> Async<'T []>

// Usage:
Async.Parallel (computations)
```

#### Parameters
*computations*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;**[Async](https://msdn.microsoft.com/library/e0b28ea2-dea5-4021-b2b9-d7d4761babde)**&lt;'T&gt;&gt;**


A sequence of distinct computations to be parallelized.

## Return Value

A computation that returns an array of values from the sequence of input computations.

## Remarks
If all child computations succeed, an array of results is passed to the success continuation. If any child computation raises an exception, then the overall computation will trigger an exception, and cancel the others. The overall computation will respond to cancellation while executing the child computations. If cancelled, the computation will cancel any remaining child computations but will still wait for the other child computations to complete.

## Example

The following code example shows how to use Async.Parallel to run computations that write to a number of files asynchronously.

[!code-fsharp[Main](snippets/fsasyncapis/snippet32.fs)]

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.Async Class &#40;F&#35;&#41;](Control.Async-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)