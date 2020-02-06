---
title: IObservable.Subscribe<'T> Method (F#)
description: IObservable.Subscribe<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 310319b9-32d7-4179-b342-df9ab9a23d93 
---

# IObservable.Subscribe<'T> Method (F#)

Subscribe an observer to the source of results

**Namespace/Module Path**: System

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
abstract this.Subscribe : IObserver<'T> -> IDisposable

// Usage:
iObservable.Subscribe (observer)
```

#### Parameters
*observer*
Type: [IObserver](https://msdn.microsoft.com/library/38436152-0d4c-4b0f-9916-440b34f377fb)**&lt;'T&gt;**


The observer to be added to those that are notified.

## Return Value

An `IDisposable` to allow for unsubscription.

## Remarks
This API is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 API with the same name, `System.IObservable.Subscribe(System.IObserver)`.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0

## See Also
[System.IObservable&#60;'T&#62; Interface &#40;F&#35;&#41;](System.IObservable%5B%27T%5D-Interface-%5BFSharp%5D.md)

[System Namespace &#40;F&#35;&#41;](System-Namespace-%5BFSharp%5D.md)