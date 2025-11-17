---
description: "Learn more about: ICorDebugBreakpointEnum Interface"
title: "ICorDebugBreakpointEnum Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugBreakpointEnum"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugBreakpointEnum"
helpviewer_keywords:
  - "ICorDebugBreakpointEnum interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugBreakpointEnum Interface

Implements ICorDebugEnum methods, and enumerates ICorDebugBreakpoint arrays.

## Methods

|Method|Description|
|------------|-----------------|
|[Next Method](icordebugbreakpointenum-next-method.md)|Gets the specified number of `ICorDebugBreakpoint` instances from the enumeration, starting at the current position.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
