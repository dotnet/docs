---
title: IObservable.Subscribe<'T> Extension Method (F#)
description: IObservable.Subscribe<'T> Extension Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 658bec4d-b5b8-4bd4-b066-0bf6d187661a 
---

# IObservable.Subscribe<'T> Extension Method (F#)

Connects a listener function to the observable. The listener will be invoked for each observation. The listener can be removed by calling `Dispose` on the returned `IDisposable` object.

**Namespace/Module Path**: Microsoft.FSharp.Control.CommonExtensions

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
type System.IObservable with
member Subscribe : ('T -> unit) -> IDisposable

// Usage:
iObservable.Subscribe (callback)
```

#### Parameters
*callback*
Type: **'T -&gt;**[unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)


The function to be called for each observation.

## Remarks
This member is named `SubscribeToObservable` in the .NET assembly. If accessing the member from a .NET language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0

## See Also
[Control.CommonExtensions Module &#40;F&#35;&#41;](Control.CommonExtensions-Module-%5BFSharp%5D.md)