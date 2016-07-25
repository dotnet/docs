---
title: Event.partition<'T,'Del> Function (F#)
description: Event.partition<'T,'Del> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 05a41455-4ce1-4fcf-a306-48aad906027d 
---

# Event.partition<'T,'Del> Function (F#)

Returns a new event that listens to the original event and triggers the first resulting event if the application of the predicate to the event arguments returned `true`, and the second event if it returned `false`.

**Namespace/Module Path**: Microsoft.FSharp.Control.Event

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Event.partition : ('T -> bool) -> IEvent<'Del,'T> -> IEvent<'T> * IEvent<'T> (requires delegate)

// Usage:
Event.partition predicate sourceEvent
```

#### Parameters
*predicate*
Type: **'T -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


The function to determine which output event to trigger.


*sourceEvent*
Type: [IEvent](https://msdn.microsoft.com/library/8dbca0df-f8a1-40bd-8d50-aa26f6a8b862)**&lt;'Del,'T&gt;**


The input event.

## Return Value

A tuple of events. The first is triggered when the predicate evaluates to `true` and the second when the predicate evaluates to `false`.

## Remarks
This function is named `Partition` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example
The following code shows how to use the Event.partition function to split an event into two events, each with its own event handling code.

[!code-fsharp[Main](snippets/fsevents/snippet7.fs)]

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.Event Module &#40;F&#35;&#41;](Control.Event-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)