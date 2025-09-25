---
description: "Learn more about: ICorDebugValue2 Interface"
title: "ICorDebugValue2 Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugValue2"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugValue2"
helpviewer_keywords:
  - "ICorDebugValue2 interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugValue2 Interface

Extends the "ICorDebugValue" interface to provide support for "ICorDebugType" objects.

## Methods

|Method|Description|
|------------|-----------------|
|[GetExactType Method](icordebugvalue2-getexacttype-method.md)|Gets an interface pointer to an `ICorDebugType` object that represents the <xref:System.Type> of this value.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

- [ICorDebugValue3 Interface](icordebugvalue3-interface.md)
