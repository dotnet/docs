---
title: Control.Event<'T> Class (F#)
description: Control.Event<'T> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: fe4a3fc0-b394-4e77-8cf9-59d1b84c9f27 
---

# Control.Event<'T> Class (F#)

Event implementations for the [`IEvent`](https://msdn.microsoft.com/library/7976554f-9aa8-451f-a69d-d4670c064432) type.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type Event<'T> =
class
new Event : unit -> Event<'T>
member this.Trigger : 'T -> unit
member this.Publish :  IEvent<'T>
end
```

## Remarks
Functions that work with events are defined in the [Event module](https://msdn.microsoft.com/library/8b883baa-a460-4840-9baa-de8260351bc7).

This type is named `FSharpEvent` in compiled assemblies. If you are accessing the type from a language other than F#, or through reflection, use this name.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/4f9c6229-7502-4f4f-97ef-413a6c8501d1)|Creates an observable object.|

## Instance Members


|Member|Description|
|------|-----------|
|[Publish](https://msdn.microsoft.com/library/b0fdaad5-25e5-43d0-9c0c-ce37c4aeb68e)|Publishes an observation as a first class value.|
|[Trigger](https://msdn.microsoft.com/library/f8a418ad-72b4-4574-bdf8-b1e7e1f21459)|Triggers an observation using the given parameters.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)

[Control.IEvent&#60;'T&#62; Type Abbreviation &#40;F&#35;&#41;](Control.IEvent%5B%27T%5D-Type-Abbreviation-%5BFSharp%5D.md)

[Control.IEvent&#60;'Delegate,'Args&#62; Interface &#40;F&#35;&#41;](Control.IEvent%5B%27Delegate%2C%27Args%5D-Interface-%5BFSharp%5D.md)