---
description: "Learn more about: ICorDebugStringValue Interface"
title: "ICorDebugStringValue Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugStringValue"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugStringValue"
helpviewer_keywords:
  - "ICorDebugStringValue interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugStringValue Interface

A subclass of ICorDebugHeapValue that applies to string values.

## Methods

|Method|Description|
|------------|-----------------|
|[GetLength Method](icordebugstringvalue-getlength-method.md)|Gets the number of characters in the string referenced by this `ICorDebugStringValue`.|
|[GetString Method](icordebugstringvalue-getstring-method.md)|Gets the string referenced by this `ICorDebugStringValue`.|

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
