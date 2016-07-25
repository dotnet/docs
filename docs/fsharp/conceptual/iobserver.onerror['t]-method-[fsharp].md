---
title: IObserver.OnError<'T> Method (F#)
description: IObserver.OnError<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a6ff59ee-edf8-4982-9d26-1cb279645f8e 
---

# IObserver.OnError<'T> Method (F#)

Notify an observer of an error

**Namespace/Module Path**: System

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
abstract this.OnError : exn -> unit

// Usage:
iObserver.OnError (error)
```

#### Parameters
*error*
Type: [exn](https://msdn.microsoft.com/library/e1569b69-3b30-440b-8c6f-966d1c6a06ab)


The exception to notify observers.

## Remarks
This API is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 API with the same name, `System.IObserver.OnError(System.Exception)`.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0

## See Also
[System.IObserver&#60;'T&#62; Interface &#40;F&#35;&#41;](System.IObserver%5B%27T%5D-Interface-%5BFSharp%5D.md)

[System Namespace &#40;F&#35;&#41;](System-Namespace-%5BFSharp%5D.md)