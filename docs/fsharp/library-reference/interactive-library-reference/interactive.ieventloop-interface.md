---
title: Interactive.IEventLoop Interface
description: Interactive.IEventLoop Interface
ms.date: 02/26/2020
---

# Interactive.IEventLoop Interface

An event loop used by the currently executing F# Interactive session to execute code in the context of a GUI or another event-based system.

**Namespace/Module Path:** Microsoft.FSharp.Compiler.Interactive

**Assembly:** FSharp.Compiler.Interactive.Settings (in FSharp.Compiler.Interactive.Settings.dll)

## Syntax

```fsharp
type IEventLoop =
    abstract this.Invoke : (unit -> 'T) -> 'T
    abstract this.Run : unit -> bool
    abstract this.ScheduleRestart : unit -> unit
```

## Instance Members


|Member|Description|
|------|-----------|
|[`Invoke`](ieventloop.invoke['t]-method.md)|Requests that the given operation be run synchronously on the event loop.|
|[`Run`](ieventloop.run-method.md)|Runs the event loop. A return of **true** indicates that the event loop was restarted.|
|[`ScheduleRestart`](ieventloop.schedulerestart-method.md)|Schedule a restart for the event loop.|

## See Also
[Microsoft.FSharp.Compiler.Interactive Namespace](index.md)
