---
description: "Learn more about: ICorDebugObjectEnum Interface"
title: "ICorDebugObjectEnum Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugObjectEnum"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugObjectEnum"
helpviewer_keywords:
  - "ICorDebugObjectEnum interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugObjectEnum Interface

Implements ICorDebugEnum methods, and enumerates arrays of objects by their relative virtual addresses (RVAs).

## Methods

|Method|Description|
|------------|-----------------|
|[Next Method](icordebugobjectenum-next-method.md)|Gets the RVAs of the specified number of objects from the enumeration, starting at the current position.|

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
