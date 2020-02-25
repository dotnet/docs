---
title: RuntimeHelpers.CreateEvent<'Delegate,'Args> Function (F#)
description: RuntimeHelpers.CreateEvent<'Delegate,'Args> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 2e1a83fa-0384-4fc4-841c-a119d6b838fb
---

# RuntimeHelpers.CreateEvent<'Delegate,'Args> Function (F#)

Creates an anonymous event with the given handlers.

**Namespace/Module Path:** Microsoft.FSharp.Core.CompilerServices.RuntimeHelpers

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
RuntimeHelpers.CreateEvent : ('Delegate -> unit) -> ('Delegate -> unit) -> ((obj -> 'Args -> unit) -> 'Delegate) -> IEvent<'Delegate,'Args> (requires delegate)

// Usage:
RuntimeHelpers.CreateEvent addHandler removeHandler createHandler
```

#### Parameters
*addHandler*
Type: **'Delegate -&gt;**[unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)


A function to handle adding a delegate for the event to trigger.


*removeHandler*
Type: **'Delegate -&gt;**[unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)


A function to handle removing a delegate that the event triggers.


*createHandler*
Type: **(**[obj](https://msdn.microsoft.com/library/dcf2430f-702b-40e5-a0a1-97518bf137f7)**-&gt; 'Args -&gt;**[unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)**) -&gt;   'Delegate**


A function to produce the delegate type the event can trigger.

## Return Value

The initialized event as an object that implements [IEvent](https://msdn.microsoft.com/library/8dbca0df-f8a1-40bd-8d50-aa26f6a8b862).

## Remarks

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[CompilerServices.RuntimeHelpers Module &#40;F&#35;&#41;](CompilerServices.RuntimeHelpers-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core.CompilerServices Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core.CompilerServices-Namespace-%5BFSharp%5D.md)
