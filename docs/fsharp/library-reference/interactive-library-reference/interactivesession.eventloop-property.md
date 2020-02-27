---
title: InteractiveSession.EventLoop Property
description: InteractiveSession.EventLoop Property
ms.date: 02/26/2020
---

# InteractiveSession.EventLoop Property

Gets or sets the current event loop being used to process interactions.

**Namespace/Module Path:** Microsoft.FSharp.Compiler.Interactive

**Assembly:** FSharp.Compiler.Interactive.Settings (in FSharp.Compiler.Interactive.Settings.dll)

## Syntax

```fsharp
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

## See Also
[Interactive.InteractiveSession Class](Interactive.InteractiveSession-Class.md)

[Microsoft.FSharp.Compiler.Interactive Namespace](index.md)
