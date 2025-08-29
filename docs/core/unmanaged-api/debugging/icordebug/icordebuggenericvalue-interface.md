---
description: "Learn more about: ICorDebugGenericValue Interface"
title: "ICorDebugGenericValue Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugGenericValue"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugGenericValue"
helpviewer_keywords:
  - "ICorDebugGenericValue interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugGenericValue Interface

A subclass of "ICorDebugValue" that applies to all values. This interface provides Get and Set methods for the value.

## Methods

|Method|Description|
|------------|-----------------|
|[GetValue Method](icordebuggenericvalue-getvalue-method.md)|Copies the value into the specified buffer.|
|[SetValue Method](icordebuggenericvalue-setvalue-method.md)|Copies a new value from the specified buffer.|

## Remarks

 `ICorDebugGenericValue` is a sub-interface because it is non-remotable.

For reference types, the value is the reference rather than the contents of the reference.

This interface does not support being called remotely, either cross-machine or cross-process.

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
