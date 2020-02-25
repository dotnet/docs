---
title: Event.scan<'U,'T,'Del> Function (F#)
description: Event.scan<'U,'T,'Del> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 20a766cb-5c37-45e4-93b8-fcf79ddf0318 
---

# Event.scan<'U,'T,'Del> Function (F#)

Returns a new event that consists of the results of applying the given accumulating function to successive values triggered on the input event.

**Namespace/Module Path:** Microsoft.FSharp.Control.Event

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Event.scan : ('U -> 'T -> 'U) -> 'U -> IEvent<'Del,'T> -> IEvent<'U> (requires delegate)

// Usage:
Event.scan collector state sourceEvent
```

#### Parameters
*collector*
Type: **'U -&gt; 'T -&gt; 'U**


The function to update the state with each event value.


*state*
Type: **'U**


The initial state.


*sourceEvent*
Type: [IEvent](https://msdn.microsoft.com/library/8dbca0df-f8a1-40bd-8d50-aa26f6a8b862)**&lt;'Del,'T&gt;**


The input event.

## Return Value

An event that fires on the updated state values.

## Remarks
An item of internal state records the current value of the state parameter. The internal state is not locked during the execution of the accumulation function, so care should be taken that the input [`IEvent`](https://msdn.microsoft.com/library/8dbca0df-f8a1-40bd-8d50-aa26f6a8b862) is not triggered by multiple threads simultaneously.

This function is named `Scan` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example
This code implements a simple click counter. Every time the user clicks on the form, the state increments by 1 and the form's text is changed to display the new state.

[!code-fsharp[Main](snippets/fsevents/snippet8.fs)]

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.Event Module &#40;F&#35;&#41;](Control.Event-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)