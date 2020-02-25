---
title: Interactive.IEventLoop Interface (F#)
description: Interactive.IEventLoop Interface (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ad7e29ac-ea2a-4749-9576-41af006115cb 
---

# Interactive.IEventLoop Interface (F#)

An event loop used by the currently executing F# Interactive session to execute code in the context of a GUI or another event-based system.

**Namespace/Module Path:** Microsoft.FSharp.Compiler.Interactive

**Assembly:** FSharp.Compiler.Interactive.Settings (in FSharp.Compiler.Interactive.Settings.dll)


## Syntax

```fsharp
type IEventLoop =
interface
abstract this.Invoke : (unit -> 'T) -> 'T
abstract this.Run : unit -> bool
abstract this.ScheduleRestart : unit -> unit
end
```

## Instance Members


|Member|Description|
|------|-----------|
|[Invoke](https://msdn.microsoft.com/library/f9002b6e-d525-4abc-ad4b-0ff0888c16d6)|Requests that the given operation be run synchronously on the event loop.|
|[Run](https://msdn.microsoft.com/library/24209128-a677-41e5-97e2-b8e95a0369d8)|Runs the event loop. A return of **true** indicates that the event loop was restarted.|
|[ScheduleRestart](https://msdn.microsoft.com/library/d9d408fe-47d5-45bf-807a-b5d856231e4b)|Schedule a restart for the event loop.|

## Platforms
Windows 7, Windows Vista SP2, Windows XP SP3, Windows XP x64 SP2, Windows Server 2008 R2, Windows Server 2008 SP2, Windows Server 2003 SP2


## Version Information
**F# Runtime**

Supported in: 2.0, 4.0

## See Also
[Microsoft.FSharp.Compiler.Interactive Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Compiler.Interactive-Namespace-%5BFSharp%5D.md)