---
title: Observable.pairwise<'T> Function (F#)
description: Observable.pairwise<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ed88e313-1b53-40c7-9833-ef9b98cab7d3
---

# Observable.pairwise<'T> Function (F#)

Returns a new observable that triggers on the second and subsequent triggerings of the input observable. The Nth triggering of the input observable passes the arguments from the N-1th and Nth triggering as a pair. The argument passed to the N-1th triggering is held in hidden internal state until the Nth triggering occurs.

**Namespace/Module Path**: Microsoft.FSharp.Control.Observable

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Observable.pairwise : IObservable<'T> -> IObservable<'T * 'T>

// Usage:
Observable.pairwise source
```

#### Parameters
*source*
Type: [IObservable](https://msdn.microsoft.com/library/04855e2b-42e4-4342-860a-b86566c4f2d9)**&lt;'T&gt;**


The input observable.

## Return Value

An `Observable` that triggers on successive pairs of observations from the input observable.

## Remarks
For each observer, the registered intermediate observing object is not thread safe. That is, observations arising from the source must not be triggered concurrently on different threads.

This function is named `Pairwise` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.Observable Module &#40;F&#35;&#41;](Control.Observable-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)
