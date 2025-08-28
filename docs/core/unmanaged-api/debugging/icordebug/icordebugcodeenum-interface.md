---
description: "Learn more about: ICorDebugCodeEnum Interface"
title: "ICorDebugCodeEnum Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugCodeEnum"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugCodeEnum"
helpviewer_keywords:
  - "ICorDebugCodeEnum interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugCodeEnum Interface

Implements "ICorDebugEnum" methods, and enumerates "ICorDebugCode" arrays.

## Methods

|Method|Description|
|------------|-----------------|
|[Next Method](icordebugcodeenum-next-method.md)|Gets the specified number of `ICorDebugCode` instances from the enumeration, starting at the current position.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [Debugging Interfaces](debugging-interfaces.md)
