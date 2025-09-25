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
  - "ICorDebugFunctionBreakpoint interface [.NET debugging]"
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

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
