---
description: "Learn more about: ICorDebugDebugEvent Interface"
title: "ICorDebugDebugEvent Interface"
ms.date: "03/30/2017"
---
# ICorDebugDebugEvent Interface

Defines the base interface from which all `ICorDebug` debug events derive.

## Methods

|Method|Description|
|------------|-----------------|
|[GetEventKind Method](icordebugdebugevent-geteventkind-method.md)|Indicates what kind of event this `ICorDebugDebugEvent` object represents.|
|[GetThread Method](icordebugdebugevent-getthread-method.md)|Gets the thread on which the event occurred.|

## Remarks

 The following interfaces are derived from the `ICorDebugDebugEvent` interface:

- [ICorDebugExceptionDebugEvent](icordebugexceptiondebugevent-interface.md)

- [ICorDebugModuleDebugEvent](icordebugmoduledebugevent-interface.md)

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
