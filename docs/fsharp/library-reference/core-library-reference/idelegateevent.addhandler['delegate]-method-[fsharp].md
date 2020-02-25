---
title: IDelegateEvent.AddHandler<'Delegate> Method (F#)
description: IDelegateEvent.AddHandler<'Delegate> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ba9f40e9-e2f1-4469-9340-051333d591bb 
---

# IDelegateEvent.AddHandler<'Delegate> Method (F#)

Connect a handler delegate object to the event. A handler can be later removed using [`RemoveHandler`](https://msdn.microsoft.com/library/a5fd2289-29ef-4c8e-bf67-14d6fbed38b2). The listener will be invoked when the event is fired.

**Namespace/Module Path**: Microsoft.FSharp.Control

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
abstract this.AddHandler : 'Delegate -> unit

// Usage:
iDelegateEvent.AddHandler (handler)
```

#### Parameters
*handler*
Type: **'Delegate**


A delegate to be invoked when the event is fired.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.IDelegateEvent&#60;'Delegate&#62; Interface &#40;F&#35;&#41;](Control.IDelegateEvent%5B%27Delegate%5D-Interface-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)