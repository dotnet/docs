---
title: Event.filter<'T,'Del> Function (F#)
description: Event.filter<'T,'Del> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 7ca818b5-40b1-4d5a-8d3b-53a930cd5eca 
---

# Event.filter<'T,'Del> Function (F#)

Returns a new event that listens to the original event and triggers the resulting event only when the argument to the event passes the given function.

**Namespace/Module Path:** Microsoft.FSharp.Control.Event

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Event.filter : ('T -> bool) -> IEvent<'Del,'T> -> IEvent<'T> (requires delegate)

// Usage:
Event.filter predicate sourceEvent
```

#### Parameters
*predicate*
Type: **'T -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


The function to determine which triggers from the event to propagate.


*sourceEvent*
Type: [IEvent](https://msdn.microsoft.com/library/8dbca0df-f8a1-40bd-8d50-aa26f6a8b862)**&lt;'Del,'T&gt;**


The input event.


## Return Value

An event that only passes values that pass the predicate.

## Remarks
This function is named `Filter` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code example shows how to use the Event.filter function. In this example, mouse events are passed on only when the mouse pointer is in a certain region.

[!code-fsharp[Main](snippets/fsevents/snippet3.fs)]

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Control.Event Module &#40;F&#35;&#41;](Control.Event-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)