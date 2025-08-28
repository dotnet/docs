---
description: "Learn more about: ICorDebugExceptionDebugEvent Interface"
title: "ICorDebugExceptionDebugEvent Interface"
ms.date: "03/30/2017"
---
# ICorDebugExceptionDebugEvent Interface

Extends the [ICorDebugDebugEvent](icordebugdebugevent-interface.md) interface to support exception events.

## Methods

|Method|Description|
|------------|-----------------|
|[GetFlags Method](icordebugexceptiondebugevent-getflags-method.md)|Gets a flag that indicates whether the exception is can be intercepted.|
|[GetNativeIP Method](icordebugexceptiondebugevent-getnativeip-method.md)|Gets the native interface pointer for this exception debug event.|
|[GetStackPointer Method](icordebugexceptiondebugevent-getstackpointer-method.md)|Gets the stack pointer for this exception debug event.|

## Remarks

 The `ICorDebugExceptionDebugEvent` interface is implemented by the following event types:

- [MANAGED_EXCEPTION_FIRST_CHANCE](cordebugrecordformat-enumeration.md)

- [MANAGED_EXCEPTION_USER_FIRST_CHANCE](cordebugrecordformat-enumeration.md)

- [MANAGED_EXCEPTION_CATCH_HANDLER_FOUND](cordebugrecordformat-enumeration.md)

- [MANAGED_EXCEPTION_UNHANDLED](cordebugrecordformat-enumeration.md)

> [!NOTE]
> The interface is available with .NET Native only. Attempting to call `QueryInterface` to retrieve an interface pointer returns `E_NOINTERFACE` for ICorDebug scenarios outside of .NET Native.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6
