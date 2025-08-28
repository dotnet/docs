---
description: "Learn more about: ICorDebugAssemblyEnum Interface"
title: "ICorDebugAssemblyEnum Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugAssemblyEnum"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugAssemblyEnum"
helpviewer_keywords:
  - "ICorDebugAssemblyEnum interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugAssemblyEnum Interface

Implements ICorDebugEnum methods and enumerates ICorDebugAssembly arrays.

## Methods

|Method|Description|
|------------|-----------------|
|[Next Method](icordebugassemblyenum-next-method.md)|Gets the specified number of `ICorDebugAssembly` instances in the enumeration, starting from the current position.|

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
