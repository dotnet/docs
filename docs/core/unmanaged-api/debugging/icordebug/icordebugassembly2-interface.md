---
description: "Learn more about: ICorDebugAssembly2 Interface"
title: "ICorDebugAssembly2 Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugAssembly2"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugAssembly2"
helpviewer_keywords:
  - "ICorDebugAssembly2 interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugAssembly2 Interface

Represents an assembly. This interface is an extension of the ICorDebugAssembly interface.

## Methods

|Method|Description|
|------------|-----------------|
|[IsFullyTrusted Method](icordebugassembly2-isfullytrusted-method.md)|Gets a value that indicates whether the assembly has been granted full trust by the runtime security system.|

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
