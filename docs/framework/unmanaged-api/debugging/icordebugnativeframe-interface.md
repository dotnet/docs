---
description: "Learn more about: ICorDebugNativeFrame Interface"
title: "ICorDebugNativeFrame Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugNativeFrame"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugNativeFrame"
helpviewer_keywords:
  - "ICorDebugNativeFrame interface [.NET Framework debugging]"
ms.assetid: 04819c58-7246-4b32-befb-680cf1dbc436
topic_type:
  - "apiref"
---
# ICorDebugNativeFrame Interface

A specialized implementation of ICorDebugFrame used for native frames.

## Methods

|Method|Description|
|------------|-----------------|
|[CanSetIP Method](icordebugnativeframe-cansetip-method.md)|Gets a value that indicates whether it is safe to set the instruction pointer to the specified offset location in native code.|
|[GetIP Method](icordebugnativeframe-getip-method.md)|Gets the stack frame's offset into native code.|
|[GetLocalDoubleRegisterValue Method](icordebugnativeframe-getlocaldoubleregistervalue-method.md)|Gets a pointer to an ICorDebugValue that represents the value of an argument or local variable stored in two memory registers of a native frame.|
|[GetLocalMemoryRegisterValue Method](icordebugnativeframe-getlocalmemoryregistervalue-method.md)|Gets a pointer to an `ICorDebugValue` that represents the value of a local variable, of which the low bits are stored in the specified register and the high bits are stored at the specified memory address.|
|[GetLocalMemoryValue Method](icordebugnativeframe-getlocalmemoryvalue-method.md)|Gets a pointer to an `ICorDebugValue` that represents the value of a local variable stored at the specified memory address.|
|[GetLocalRegisterMemoryValue Method](icordebugnativeframe-getlocalregistermemoryvalue-method.md)|Gets a pointer to an `ICorDebugValue` that represents the value of a local variable, of which the high bits are stored in the specified register and the low bits are stored at the specified memory address|
|[GetLocalRegisterValue Method](icordebugnativeframe-getlocalregistervalue-method.md)|Gets a pointer to an `ICorDebugValue` that represents the value of an argument or a local variable stored in the specified native register.|
|[GetRegisterSet Method](icordebugnativeframe-getregisterset-method.md)|Gets a pointer to an [ICorDebugRegisterSet](icordebugregisterset-interface.md) that represents the register set for this `ICorDebugNativeFrame`.|
|[SetIP Method](icordebugnativeframe-setip-method.md)|Sets the instruction pointer to the specified offset location in native code.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]

## See also

- [Debugging Interfaces](debugging-interfaces.md)
