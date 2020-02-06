---
title: Event.map<'T,'U,'Del> Function (F#)
description: Event.map<'T,'U,'Del> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 9aa6e15a-b575-4d22-a5dd-f364f4508eb4 
---

# Event.map<'T,'U,'Del> Function (F#)

Returns a new event that passes values transformed by the given function.

**Namespace/Module Path:** Microsoft.FSharp.Control.Event

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Event.map : ('T -> 'U) -> IEvent<'Del,'T> -> IEvent<'U> (requires delegate)

// Usage:
Event.map mapping sourceEvent
```

#### Parameters
*mapping*
Type: **'T -&gt; 'U**


The function to transform event values.


*sourceEvent*
Type: [IEvent](https://msdn.microsoft.com/library/8dbca0df-f8a1-40bd-8d50-aa26f6a8b862)**&lt;'Del,'T&gt;**


The input event.

## Return Value

An event that passes the transformed values.

## Remarks
This function is named `Map` in the compiled assembly. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

In this example, the event handler arguments are transformed into a more convenient format.

[!code-fsharp[Main](snippets/fsevents/snippet4.fs)]

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library VersionsF# Core Library Versions**

Supported in: 2.0, 4.0, Portable2.0, 4.0, Portable, Portable

## See Also
[Control.Event Module &#40;F&#35;&#41;](Control.Event-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)