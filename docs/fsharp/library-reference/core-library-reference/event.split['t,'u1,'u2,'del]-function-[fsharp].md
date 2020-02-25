---
title: Event.split<'T,'U1,'U2,'Del> Function (F#)
description: Event.split<'T,'U1,'U2,'Del> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: f74911ae-2d7e-463a-8c4d-7f29b81fe0bd 
---

# Event.split<'T,'U1,'U2,'Del> Function (F#)

Returns a new event that listens to the original event and triggers the first resulting event if the application of the function to the event arguments returned a `Choice1Of2`, and the second event if it returns a `Choice2Of2`.

**Namespace/Module Path:** Microsoft.FSharp.Control.Event

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Event.split : ('T -> Choice<'U1,'U2>) -> IEvent<'Del,'T> -> IEvent<'U1> * IEvent<'U2> (requires delegate)

// Usage:
Event.split splitter sourceEvent
```

#### Parameters
*splitter*
Type: **'T -&gt;**[Choice](https://msdn.microsoft.com/library/2ab2513e-e307-4360-96cd-8b682a8d64f0)**&lt;'U1,'U2&gt;**


A function, typically an active pattern recognizer, that transforms event values into one of two types.


*sourceEvent*
Type: [IEvent](https://msdn.microsoft.com/library/8dbca0df-f8a1-40bd-8d50-aa26f6a8b862)**&lt;'Del,'T&gt;**


The input event.


## Return Value

A tuple of events. The first fires whenever splitter evaluates to Choice1of1 and the second fires whenever splitter evaluates to Choice2of2.

## Remarks
This function is named `Split` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example
The following code shows how to use the Event.split function to implement the ability to move a control on a form. The splitter function is the active pattern recognizer (|Down|Up|), which represents the state of the mouse buttons. If a user presses the mouse button while moving the mouse when it is over the button, the button moves. There is also code that sometimes changes the color of the button while it is moving, depending on which mouse button is used. This test uses a different color for each mouse button. The other event path, which is used when the mouse button is not down, restores the original color of the button after the button is released.

[!code-fsharp[Main](snippets/fsevents/snippet9.fs)]

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.Event Module &#40;F&#35;&#41;](Control.Event-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)