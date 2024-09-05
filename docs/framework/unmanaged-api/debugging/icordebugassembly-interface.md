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
  - "ICorDebugAssembly interface [.NET Framework debugging]"
ms.assetid: 9d657a28-6984-4c5e-8a54-89d20080baff
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

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]

## See also

- [Debugging Interfaces](debugging-interfaces.md)
