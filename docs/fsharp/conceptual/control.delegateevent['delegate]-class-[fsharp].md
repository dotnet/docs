---
title: Control.DelegateEvent<'Delegate> Class (F#)
description: Control.DelegateEvent<'Delegate> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: c30fed8b-03d2-4bb5-9348-5165d0e75441 
---

# Control.DelegateEvent<'Delegate> Class (F#)

Event implementations for an arbitrary type of delegate.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type DelegateEvent<'Delegate> =
class
new DelegateEvent : unit -> DelegateEvent<'Delegate>
member this.Trigger : obj [] -> unit
member this.Publish :  IDelegateEvent<'Delegate>
end
```

## Remarks
This type is named `FSharpDelegateEvent` in compiled assemblies. If you are accessing the type from a language other than F#, or through reflection, use this name.


## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/dc240900-1e0a-440d-87a6-271a0fde2aa2)|Creates an event object suitable for implementing an arbitrary type of delegate.|

## Instance Members

|Member|Description|
|------|-----------|
|[Publish](https://msdn.microsoft.com/library/7773c3df-99de-43bd-9e11-1b5763651d27)|Publishes the event as a first class event value.|
|[Trigger](https://msdn.microsoft.com/library/81433778-b592-40d1-a5a6-c94e3ab3fd88)|Triggers the event using the given parameters.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)