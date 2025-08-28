---
description: "Learn more about: ICorDebugUnmanagedCallback Interface"
title: "ICorDebugUnmanagedCallback Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugUnmanagedCallback"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugUnmanagedCallback"
helpviewer_keywords:
  - "ICorDebugUnmanagedCallback interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugUnmanagedCallback Interface

Provides notification of native events that are not directly related to the common language runtime (CLR).

## Methods

|Method|Description|
|------------|-----------------|
|[DebugEvent Method](icordebugunmanagedcallback-debugevent-method.md)|Notifies the debugger that a native event has been fired.|

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
