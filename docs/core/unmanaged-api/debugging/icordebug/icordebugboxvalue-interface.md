---
description: "Learn more about: ICorDebugBoxValue Interface"
title: "ICorDebugBoxValue Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugBoxValue"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugBoxValue"
helpviewer_keywords:
  - "ICorDebugBoxValue interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugBoxValue Interface

A subclass of "ICorDebugHeapValue" that represents a boxed value class object.

## Methods

|Method|Description|
|------------|-----------------|
|[GetObject Method](icordebugboxvalue-getobject-method.md)|Gets an interface pointer to the boxed "ICorDebugObjectValue" instance.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
