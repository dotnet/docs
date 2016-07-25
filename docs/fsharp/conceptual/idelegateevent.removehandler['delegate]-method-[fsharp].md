---
title: IDelegateEvent.RemoveHandler<'Delegate> Method (F#)
description: IDelegateEvent.RemoveHandler<'Delegate> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 75ec5188-721c-4eb1-af66-1812cc85e164 
---

# IDelegateEvent.RemoveHandler<'Delegate> Method (F#)

Remove a listener delegate from an event listener store.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
abstract this.RemoveHandler : 'Delegate -> unit

// Usage:
iDelegateEvent.RemoveHandler (handler)
```

#### Parameters
*handler*
Type: **'Delegate**


The delegate to be removed from the event listener store.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.IDelegateEvent&#60;'Delegate&#62; Interface &#40;F&#35;&#41;](Control.IDelegateEvent%5B%27Delegate%5D-Interface-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)