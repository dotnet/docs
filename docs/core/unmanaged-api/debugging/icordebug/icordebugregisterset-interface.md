---
description: "Learn more about: ICorDebugRegisterSet Interface"
title: "ICorDebugRegisterSet Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugRegisterSet"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugRegisterSet"
helpviewer_keywords:
  - "ICorDebugRegisterSet interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugRegisterSet Interface

Represents the set of registers available on the computer that is currently executing code.

## Methods

|Method|Description|
|------------|-----------------|
|[GetRegisters Method](icordebugregisterset-getregisters-method.md)|Gets the value of each register (on the computer that is currently executing code) that is specified by the bit mask.|
|[GetRegistersAvailable Method](icordebugregisterset-getregistersavailable-method.md)|Gets a bit mask indicating which registers in this `ICorDebugRegisterSet` are currently available.|
|[GetThreadContext Method](icordebugregisterset-getthreadcontext-method.md)|Gets the context of the current thread.|
|[SetRegisters Method](icordebugregisterset-setregisters-method.md)|Not implemented for .NET Framework version 2.0.|
|[SetThreadContext Method](icordebugregisterset-setthreadcontext-method.md)|Not implemented for the .NET Framework 2.0.|

## Remarks

 The `ICorDebugRegisterSet` interface supports only 32-bit registers. Use the [ICorDebugRegisterSet2](icordebugregisterset2-interface.md) interface on platforms such as IA-64 that require additional registers.

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [ICorDebugRegisterSet2 Interface](icordebugregisterset2-interface.md)
