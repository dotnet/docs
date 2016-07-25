---
title: Event.choose<'T,'U,'Del> Function (F#)
description: Event.choose<'T,'U,'Del> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 32171cc8-dc19-47d6-acaa-4a18acd71b3d 
---

# Event.choose<'T,'U,'Del> Function (F#)

Returns a new event which fires on a selection of messages from the original event. The selection function takes an original message to an optional new message.

**Namespace/Module Path:** Microsoft.FSharp.Control.Event

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Event.choose : ('T -> 'U option) -> IEvent<'Del,'T> -> IEvent<'U> (requires delegate)

// Usage:
Event.choose chooser sourceEvent
```

#### Parameters
*chooser*
Type: **'T -&gt; 'U**[option](https://msdn.microsoft.com/library/b08add48-34bf-4410-80a1-ef6a8daddc58)


The function to select and transform event values to pass on.


*sourceEvent*
Type: [IEvent](https://msdn.microsoft.com/library/8dbca0df-f8a1-40bd-8d50-aa26f6a8b862)**&lt;'Del,'T&gt;**


The input event.

## Return Value

An event that fires only when the chooser returns Some.

## Remarks
This function is named `Choose` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## Example

In this example, the function is used to select only events when the mouse button is down. At the same time, the function transforms the input data of type MouseEventArgs into a more convenient format, a tuple of two integers that represent the current mouse position.

[!code-fsharp[Main](snippets/fsevents/snippet2.fs)]

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.Event Module &#40;F&#35;&#41;](Control.Event-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)