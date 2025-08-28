---
description: "Learn more about: ICorDebugModuleBreakpoint Interface"
title: "ICorDebugModuleBreakpoint Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugModuleBreakpoint"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugModuleBreakpoint"
helpviewer_keywords:
  - "ICorDebugModuleBreakpoint interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugModuleBreakpoint Interface

Provides access to specific modules. This interface is a subclass of the ICorDebugBreakpoint interface.

## Methods

|Method|Description|
|------------|-----------------|
|[GetModule Method](icordebugmodulebreakpoint-getmodule-method.md)|Gets an interface pointer to an ICorDebugModule that references the module where this breakpoint is set.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Debugging Interfaces](debugging-interfaces.md)
