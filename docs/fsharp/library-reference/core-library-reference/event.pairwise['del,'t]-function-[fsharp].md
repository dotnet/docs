---
title: Event.pairwise<'Del,'T> Function (F#)
description: Event.pairwise<'Del,'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 13a58bed-95ca-4747-a73f-5edc9bab05cb 
---

# Event.pairwise<'Del,'T> Function (F#)

Returns a new event that triggers on the second and subsequent triggerings of the input event. The Nth triggering of the input event passes the arguments from the N-1th and Nth triggering as a pair. The argument passed to the N-1th triggering is held in hidden internal state until the Nth triggering occurs.

**Namespace/Module Path**: Microsoft.FSharp.Control.Event

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Event.pairwise : IEvent<'Del,'T> -> IEvent<'T * 'T> (requires delegate)

// Usage:
Event.pairwise sourceEvent
```

#### Parameters
*sourceEvent*
Type: [IEvent](https://msdn.microsoft.com/library/8dbca0df-f8a1-40bd-8d50-aa26f6a8b862)**&lt;'Del,'T&gt;**


The input event.

## Return Value

An event that triggers on pairs of consecutive values passed from the source event.

## Remarks
This function is named `Pairwise` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

In this example, the function makes data available from more than one MouseMove event, and the data is used to draw a line between consecutive mouse positions.

[!code-fsharp[Main](snippets/fsevents/snippet6.fs)]

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.Event Module &#40;F&#35;&#41;](Control.Event-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)