---
title: Observable.split<'T,'U1,'U2> Function (F#)
description: Observable.split<'T,'U1,'U2> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 9817ee59-c63a-4ab3-b86d-19be8df82f74
---

# Observable.split<'T,'U1,'U2> Function (F#)

Returns two observables which split the observations of the source by the given function. The first will trigger observations for which the splitter returns `Choice1Of2`. The second will trigger observations `y` for which the splitter returns `Choice2Of2`. The splitter is executed once for each subscribed observer. Both also propagate error observations arising from the source and each completes when the source completes.

**Namespace/Module Path**: Microsoft.FSharp.Control.Observable

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Observable.split : ('T -> Choice<'U1,'U2>) -> IObservable<'T> -> IObservable<'U1> * IObservable<'U2>

// Usage:
Observable.split splitter source
```

#### Parameters
*splitter*
Type: **'T -&gt;**[Choice](https://msdn.microsoft.com/library/2ab2513e-e307-4360-96cd-8b682a8d64f0)**&lt;'U1,'U2&gt;**


The function that takes an observation and transforms it into one of the two output [Choice](https://msdn.microsoft.com/library/2ab2513e-e307-4360-96cd-8b682a8d64f0) types.


*source*
Type: [IObservable](https://msdn.microsoft.com/library/04855e2b-42e4-4342-860a-b86566c4f2d9)**&lt;'T&gt;**

The input Observable.

## Return Value

A tuple of Observables. The first triggers when splitter returns `Choice1of2` and the second triggers when splitter returns `Choice2of2`.

## Remarks
This function is named `Split` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.Observable Module &#40;F&#35;&#41;](Control.Observable-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)
