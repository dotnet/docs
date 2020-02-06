---
title: Control.Event<'Delegate,'Args> Class (F#)
description: Control.Event<'Delegate,'Args> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ca298dd3-940f-42d9-8cec-aa835fe0113a 
---

# Control.Event<'Delegate,'Args> Class (F#)

Event implementations for a delegate types following the standard .NET Framework convention of a first *sender* argument.

**Namespace/Module Path**: Microsoft.FSharp.Control

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type Event<'Delegate,'Args (requires delegate)> =
class
new Event : unit -> Event<'Delegate,'Args>
member this.Trigger : obj * 'Args -> unit
member this.Publish :  IEvent<'Delegate,'Args>
end
```

## Remarks
This type is named `FSharpEvent` in compiled assemblies. If you are accessing the type from a language other than F#, or through reflection, use this name.


## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/2f112efb-a288-4640-87ec-414d6c607d31)|Creates an event object suitable for delegate types following the standard .NET Framework convention of a first 'sender' argument.|

## Instance Members

|Member|Description|
|------|-----------|
|[Publish](https://msdn.microsoft.com/library/99fb267f-7751-40b4-a137-1279edf5b303)|Publishes the event as a first class event value.|
|[Trigger](https://msdn.microsoft.com/library/e73a5a2b-7d5f-425b-8ff6-f35780c84968)|Triggers the event using the given sender object and parameters. The sender object may be **null**.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)