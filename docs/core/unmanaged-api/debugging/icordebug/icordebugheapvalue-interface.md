---
description: "Learn more about: ICorDebugHeapValue Interface"
title: "ICorDebugHeapValue Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugHeapValue"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugHeapValue"
helpviewer_keywords:
  - "ICorDebugHeapValue interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugHeapValue Interface

A subclass of "ICorDebugValue" that represents an object that has been collected by the common language runtime (CLR) garbage collector.

## Methods

|Method|Description|
|------------|-----------------|
|[CreateRelocBreakpoint Method](icordebugheapvalue-createrelocbreakpoint-method.md)|Not implemented.|
|[IsValid Method](icordebugheapvalue-isvalid-method.md)|Gets a value that indicates whether the object represented by this `ICorDebugHeapValue` is valid, or has been reclaimed by the garbage collector. This method has been deprecated.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
