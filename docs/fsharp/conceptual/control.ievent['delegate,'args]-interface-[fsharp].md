---
title: Control.IEvent<'Delegate,'Args> Interface (F#)
description: Control.IEvent<'Delegate,'Args> Interface (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 5eb31ef5-7be0-442a-b21e-3e859b03e323 
---

# Control.IEvent<'Delegate,'Args> Interface (F#)

First class event values for CLI events conforming to CLI Framework standards.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type IEvent<'Delegate,'Args when 'Delegate : delegate<'Args,unit> and 'Delegate :> System.Delegate> =
interface
inherit IObservable<'Args>
inherit IDelegateEvent<'Delegate>
end
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)

[Control.IDelegateEvent&#60;'Delegate&#62; Interface &#40;F&#35;&#41;](Control.IDelegateEvent%5B%27Delegate%5D-Interface-%5BFSharp%5D.md)

[System.IObservable&#60;'T&#62; Interface &#40;F&#35;&#41;](System.IObservable%5B%27T%5D-Interface-%5BFSharp%5D.md)