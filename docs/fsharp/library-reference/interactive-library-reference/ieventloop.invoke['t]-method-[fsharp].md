---
title: IEventLoop.Invoke<'T> Method (F#)
description: IEventLoop.Invoke<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 00b071d2-ba92-4b87-b291-5ca5f837b357 
---

# IEventLoop.Invoke<'T> Method (F#)

Request that the given operation be run synchronously on the event loop.

**Namespace/Module Path:** Microsoft.FSharp.Compiler.Interactive

**Assembly:** FSharp.Compiler.Interactive.Settings (in FSharp.Compiler.Interactive.Settings.dll)


## Syntax

```fsharp
// Signature:
abstract this.Invoke : (unit -> 'T) -> 'T

// Usage:
iEventLoop.Invoke (func)
```

#### Parameters
*func*
Type: [unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)**-&gt; 'T**


A function to run on the event loop.

## Platforms
Windows 7, Windows Vista SP2, Windows XP SP3, Windows XP x64 SP2, Windows Server 2008 R2, Windows Server 2008 SP2, Windows Server 2003 SP2


## Version Information
**F# Runtime**

Supported in: 2.0, 4.0

## See Also
[Interactive.IEventLoop Interface &#40;F&#35;&#41;](Interactive.IEventLoop-Interface-%5BFSharp%5D.md)

[Microsoft.FSharp.Compiler.Interactive Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Compiler.Interactive-Namespace-%5BFSharp%5D.md)