---
description: "Learn more about: ICorDebugValue3 Interface"
title: "ICorDebugValue3 Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugValue3"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugValue3"
helpviewer_keywords:
  - "ICorDebugValue3 interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugValue3 Interface

Extends the "ICorDebugValue" and "ICorDebugValue2" interfaces to provide support for arrays that are larger than 2 GB.

## Methods

|Method|Description|
|------------|-----------------|
|[GetSize64 Method](icordebugvalue3-getsize64-method.md)|Gets the size, in bytes, of this `ICorDebugValue3` object.|

## Remarks

 The [ICorDebugValue::GetSize](icordebugvalue3-getsize64-method.md) method returns an object size that ranges from 0 to 2,147,483,647 bytes. In .NET Framework 4.5, the size of arrays can exceed 2 GB. The `ICorDebugValue3` interface enables you to determine the size of these arrays.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5
