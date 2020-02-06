---
title: Control.IEvent<'T> Type Abbreviation (F#)
description: Control.IEvent<'T> Type Abbreviation (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b34cb05d-44a8-4f47-b81a-04a6a025948f 
---

# Control.IEvent<'T> Type Abbreviation (F#)

Represents first-class listening points, that is, objects that permit you to register a callback activated when the event is triggered).

This type is an abbreviation for [`Control.IEvent<Handler<'T>,'Args>`](https://msdn.microsoft.com/library/8dbca0df-f8a1-40bd-8d50-aa26f6a8b862).

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type IEvent<'T> = IEvent<'Delegate,'Args (requires delegate)>
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)

[Control.IEvent&#60;'Delegate,'Args&#62; Interface &#40;F&#35;&#41;](Control.IEvent%5B%27Delegate%2C%27Args%5D-Interface-%5BFSharp%5D.md)