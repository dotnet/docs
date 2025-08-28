---
description: "Learn more about: ICorDebugMetaDataLocator Interface"
title: "ICorDebugMetaDataLocator Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugMetaDataLocator"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugMetaDataLocator"
helpviewer_keywords:
  - "ICorDebugMetaDataLocator interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugMetaDataLocator Interface

Provides metadata information to the debugger.

## Methods

|Method|Description|
|------------|-----------------|
|[GetMetaData Method](icordebugmetadatalocator-getmetadata-method.md)|Asks the debugger to return the full path to a module whose metadata is needed to complete an operation the debugger requested.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.0

## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
