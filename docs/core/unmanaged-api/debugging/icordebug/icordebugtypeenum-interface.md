---
description: "Learn more about: ICorDebugTypeEnum Interface"
title: "ICorDebugTypeEnum Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugTypeEnum"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugTypeEnum"
helpviewer_keywords:
  - "ICorDebugTypeEnum interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugTypeEnum Interface

Implements "ICorDebugEnum" methods and enumerates "ICorDebugType" arrays.

## Methods

|Method|Description|
|------------|-----------------|
|[Next Method](icordebugtypeenum-next-method.md)|Gets the specified number of `ICorDebugType` instances from the enumeration, starting at the current position.|

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
