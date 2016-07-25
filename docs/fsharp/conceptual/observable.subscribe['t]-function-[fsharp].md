---
title: Observable.subscribe<'T> Function (F#)
description: Observable.subscribe<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a2f7ba2d-25ce-40d6-bf15-0895271f1429
---

# Observable.subscribe<'T> Function (F#)

Creates an observer which subscribes to the given observable and which calls the given function for each observation.

**Namespace/Module Path**: Microsoft.FSharp.Control.Observable

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Observable.subscribe : ('T -> unit) -> IObservable<'T> -> IDisposable

// Usage:
Observable.subscribe callback source
```

#### Parameters
*callback*
Type: **'T -&gt;**[unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)


The function to be called on each observation.


*source*
Type: [IObservable](https://msdn.microsoft.com/library/04855e2b-42e4-4342-860a-b86566c4f2d9)**&lt;'T&gt;**

The input Observable.

## Return Value

An object that will remove the callback if disposed.

## Remarks
This function is named `Subscribe` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.Observable Module &#40;F&#35;&#41;](Control.Observable-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)
