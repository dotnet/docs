---
description: "Learn more about: ICorDebugModuleDebugEvent Interface"
title: "ICorDebugModuleDebugEvent Interface"
ms.date: "03/30/2017"
ms.assetid: 41950c52-1ac8-4212-b814-c77e20879f91
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

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]

## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
