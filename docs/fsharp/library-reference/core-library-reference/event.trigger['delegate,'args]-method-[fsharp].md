---
title: Event.Trigger<'Delegate,'Args> Method (F#)
description: Event.Trigger<'Delegate,'Args> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 95b781c7-07ac-43a3-9214-faf18bff1fe2 
---

# Event.Trigger<'Delegate,'Args> Method (F#)

Triggers the event using the given sender object and parameters. The sender object may be `null`.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Trigger : obj * 'Args -> unit (requires delegate)

// Usage:
event.Trigger (sender, args)
```

#### Parameters
*sender*
Type: [obj](https://msdn.microsoft.com/library/dcf2430f-702b-40e5-a0a1-97518bf137f7)


The object triggering the event.


*args*
Type: **'Args**


The parameters for the event.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Control.Event&#60;'Delegate,'Args&#62; Class &#40;F&#35;&#41;](Control.Event%5B%27Delegate%2C%27Args%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)