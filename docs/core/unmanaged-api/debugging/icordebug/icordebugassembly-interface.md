---
description: "Learn more about: ICorDebugAssembly Interface"
title: "ICorDebugAssembly Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugAssembly"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugAssembly"
helpviewer_keywords:
  - "ICorDebugAssembly interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugAssembly Interface

Represents an assembly.

## Methods

|Method|Description|
|------------|-----------------|
|[EnumerateModules Method](icordebugassembly-enumeratemodules-method.md)|Gets an enumerator for the modules contained in the assembly.|
|[GetAppDomain Method](icordebugassembly-getappdomain-method.md)|Gets an interface pointer to the application domain that contains this `ICorDebugAssembly` instance.|
|[GetCodeBase Method](icordebugassembly-getcodebase-method.md)|Not implemented in the current version of the .NET Framework.|
|[GetName Method](icordebugassembly-getname-method.md)|Gets the name of the assembly.|
|[GetProcess Method](icordebugassembly-getprocess-method.md)|Gets the ICorDebugProcess instance in which the assembly is running.|

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
