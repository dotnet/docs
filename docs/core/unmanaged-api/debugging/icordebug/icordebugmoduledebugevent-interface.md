---
description: "Learn more about: ICorDebugModuleDebugEvent Interface"
title: "ICorDebugModuleDebugEvent Interface"
ms.date: "03/30/2017"
---
# ICorDebugModuleDebugEvent Interface

Extends the [ICorDebugDebugEvent](icordebugdebugevent-interface.md) interface to support module-level events.

## Methods

|Method|Description|
|------------|-----------------|
|[GetModule Method](icordebugmoduledebugevent-getmodule-method.md)|Gets the merged module that was just loaded or unloaded.|

## Remarks

 The [MODULE_LOADED](cordebugdebugeventkind-enumeration.md) and [MODULE_UNLOADED](cordebugdebugeventkind-enumeration.md) event types implement this interface.

> [!NOTE]
> The interface is available with .NET Native only. Attempting to call `QueryInterface` to retrieve an interface pointer returns `E_NOINTERFACE` for ICorDebug scenarios outside of .NET Native.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
