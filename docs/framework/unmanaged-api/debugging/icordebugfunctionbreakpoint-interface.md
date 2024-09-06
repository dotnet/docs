---
description: "Learn more about: ICorDebugFunctionBreakpoint Interface"
title: "ICorDebugFunctionBreakpoint Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugFunctionBreakpoint"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugFunctionBreakpoint"
helpviewer_keywords:
  - "ICorDebugFunctionBreakpoint interface [.NET Framework debugging]"
ms.assetid: 9c149303-14b1-4138-83d7-e8c3e0fcd332
topic_type:
  - "apiref"
---
# ICorDebugFunctionBreakpoint Interface

Extends the ICorDebugBreakpoint interface to support breakpoints within functions.

## Methods

|Method|Description|
|------------|-----------------|
|[GetFunction Method](icordebugfunctionbreakpoint-getfunction-method.md)|Gets an interface pointer to an ICorDebugFunction that references the function in which the breakpoint is set.|
|[GetOffset Method](icordebugfunctionbreakpoint-getoffset-method.md)|Gets the offset of the breakpoint within the function.|

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
