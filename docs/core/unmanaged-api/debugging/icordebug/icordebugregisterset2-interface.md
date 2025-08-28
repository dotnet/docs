---
description: "Learn more about: ICorDebugRegisterSet2 Interface"
title: "ICorDebugRegisterSet2 Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugRegisterSet2"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugRegisterSet2"
helpviewer_keywords:
  - "ICorDebugRegisterSet2 interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugRegisterSet2 Interface

Extends the capabilities of the [ICorDebugRegisterSet](icordebugregisterset-interface.md) interface for hardware platforms that have more than 64 registers.

## Methods

|Method|Description|
|------------|-----------------|
|[GetRegisters Method](icordebugregisterset2-getregisters-method.md)|Gets the value of each register (on the computer that is currently executing code) that is specified by the bit mask.|
|[GetRegistersAvailable Method](icordebugregisterset2-getregistersavailable-method.md)|Gets an array of bytes that provides a bitmap of the available registers.|
|[SetRegisters Method](icordebugregisterset2-setregisters-method.md)|Not implemented in .NET Framework version 2.0.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
- [ICorDebugRegisterSet Interface](icordebugregisterset-interface.md)
