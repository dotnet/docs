---
title: Observable.choose<'T,'U> Function (F#)
description: Observable.choose<'T,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 121aa175-5dc0-43fa-939e-cd38169eb3b6
---

# Observable.choose<'T,'U> Function (F#)

Returns an observable which chooses a projection of observations from the source using the given function. The returned object will trigger observations for which the splitter returns a `Some` value. The returned object also propagates all errors arising from the source and completes when the source completes.

**Namespace/Module Path:** Microsoft.FSharp.Control.Observable

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Observable.choose : ('T -> 'U option) -> IObservable<'T> -> IObservable<'U>

// Usage:
Observable.choose chooser source
```

#### Parameters
*chooser*
Type: **'T -&gt; 'U**[option](https://msdn.microsoft.com/library/b08add48-34bf-4410-80a1-ef6a8daddc58)


The function that returns **Some** for observations to be propagated and None for observations to ignore.


*source*
Type: [IObservable](https://msdn.microsoft.com/library/04855e2b-42e4-4342-860a-b86566c4f2d9)**&lt;'T&gt;**


The input Observable.

## Return Value

An `Observable` that only propagates some of the observations from the source.

## Remarks
This function is named `Choose` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.Observable Module &#40;F&#35;&#41;](Control.Observable-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)
