---
description: "Learn more about: ICorDebugHeapValue2 Interface"
title: "ICorDebugHeapValue2 Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugHeapValue2"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugHeapValue2"
helpviewer_keywords:
  - "ICorDebugHeapValue2 interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugHeapValue2 Interface

An extension of ICorDebugHeapValue that provides support for common language runtime (CLR) handles.

## Methods

|Method|Description|
|------------|-----------------|
|[CreateHandle Method](icordebugheapvalue2-createhandle-method.md)|Creates a handle of the specified type for this `ICorDebugHeapValue2` object.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
