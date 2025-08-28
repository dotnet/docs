---
description: "Learn more about: ICorDebugAppDomain2 Interface"
title: "ICorDebugAppDomain2 Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugAppDomain2"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugAppDomain2"
helpviewer_keywords:
  - "ICorDebugAppDomain2 interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugAppDomain2 Interface

Provides methods to work with arrays, pointers, function pointers, and reference types. This interface is an extension of the ICorDebugAppDomain interface.

## Methods

|Method|Description|
|------------|-----------------|
|[GetArrayOrPointerType Method](icordebugappdomain2-getarrayorpointertype-method.md)|Gets an array of the specified type, or a pointer or reference to the specified type.|
|[GetFunctionPointerType](icordebugappdomain2-getfunctionpointertype-method.md)|Gets a pointer to a function that has a given signature.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
