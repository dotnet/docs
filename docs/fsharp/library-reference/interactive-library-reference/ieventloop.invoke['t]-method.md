---
title: IEventLoop.Invoke<'T> Method
description: IEventLoop.Invoke<'T> Method
ms.date: 02/26/2020
---

# IEventLoop.Invoke<'T> Method

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
Type: `[unit](../core-library-reference/core.unit-type-abbreviation-[fsharp].md) -> 'T`

A function to run on the event loop.

## See Also
[Interactive.IEventLoop Interface](Interactive.IEventLoop-Interface.md)

[Microsoft.FSharp.Compiler.Interactive Namespace](index.md)
