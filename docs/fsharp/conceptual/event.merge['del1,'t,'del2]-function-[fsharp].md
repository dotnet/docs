---
title: Event.merge<'Del1,'T,'Del2> Function (F#)
description: Event.merge<'Del1,'T,'Del2> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: f71568c7-71d9-4287-b1aa-3b13ed009c6c 
---

# Event.merge<'Del1,'T,'Del2> Function (F#)

Fires the output event when either of the input events fire.

**Namespace/Module Path:** Microsoft.FSharp.Control.Event

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Event.merge : IEvent<'Del1,'T> -> IEvent<'Del2,'T> -> IEvent<'T> (requires delegate and delegate)

// Usage:
Event.merge event1 event2
```

#### Parameters
*event1*
Type: [IEvent](https://msdn.microsoft.com/library/8dbca0df-f8a1-40bd-8d50-aa26f6a8b862)**&lt;'Del1,'T&gt;**


The first input event.


*event2*
Type: [IEvent](https://msdn.microsoft.com/library/8dbca0df-f8a1-40bd-8d50-aa26f6a8b862)**&lt;'Del2,'T&gt;**


The second input event.


## Return Value

An event that fires when either of the input events fire.

## Remarks
This function is named `Merge` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fsevents/snippet5.fs)]

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.Event Module &#40;F&#35;&#41;](Control.Event-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)