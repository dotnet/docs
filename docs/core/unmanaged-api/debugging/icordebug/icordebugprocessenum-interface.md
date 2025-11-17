---
description: "Learn more about: ICorDebugProcessEnum Interface"
title: "ICorDebugProcessEnum Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugProcessEnum"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugProcessEnum"
helpviewer_keywords:
  - "ICorDebugProcessEnum interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugProcessEnum Interface

Implements ICorDebugEnum methods and enumerates ICorDebugProcess arrays.

## Methods

|Method|Description|
|------------|-----------------|
|[Next Method](icordebugprocessenum-next-method.md)|Gets the specified number of `ICorDebugProcess` instances from the enumeration, starting at the current position.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
