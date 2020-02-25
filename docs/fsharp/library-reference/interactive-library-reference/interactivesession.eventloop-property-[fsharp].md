---
title: InteractiveSession.EventLoop Property (F#)
description: InteractiveSession.EventLoop Property (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 563e5bc6-0538-4001-a7a2-fe1454bb62f0 
---

# InteractiveSession.EventLoop Property (F#)

Gets or sets the current event loop being used to process interactions.

**Namespace/Module Path:** Microsoft.FSharp.Compiler.Interactive

**Assembly:** FSharp.Compiler.Interactive.Settings (in FSharp.Compiler.Interactive.Settings.dll)


## Syntax

```
// Signatures:
member this.EventLoop :  IEventLoop
member this.EventLoop : IEventLoop with set :  IEventLoop

// Usage:
interactiveSession.EventLoop
interactiveSession.EventLoop <- eventLoop
```

#### Parameters
eventLoop
Type: [IEventLoop](https://msdn.microsoft.com/library/8d33b06b-8d6e-44d2-9de5-f3c5d54b9f0e)


An event loop for the interactive session.




## Remarks

## Platforms
Windows 7, Windows Vista SP2, Windows XP SP3, Windows XP x64 SP2, Windows Server 2008 R2, Windows Server 2008 SP2, Windows Server 2003 SP2


## Version Information
**F# Runtime**

Supported in: 2.0, 4.0



## See Also
[Interactive.InteractiveSession Class &#40;F&#35;&#41;](Interactive.InteractiveSession-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Compiler.Interactive Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Compiler.Interactive-Namespace-%5BFSharp%5D.md)

