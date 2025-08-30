---
description: "Learn more about: ICorDebugHeapSegmentEnum Interface"
title: "ICorDebugHeapSegmentEnum Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugHealRegionEnum"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugHeapSegmentEnum"
helpviewer_keywords:
  - "ICorDebugHeapSegmentEnum interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugHeapSegmentEnum Interface

Provides an enumerator for the memory regions of the managed heap. This interface is a subclass of the ICorDebugEnum interface.

## Methods

|Method|Description|
|------------|-----------------|
|[Next Method](icordebugheapsegmentenum-next-method.md)|Gets the specified number of [COR_SEGMENT](cor-segment-structure.md) instances that contain information about regions of the managed heap.|

## Remarks

The `ICorDebugHeapSegmentEnum` interface implements the ICorDebugEnum interface.

An `ICorDebugHeapSegmentEnum` instance is populated with [COR_SEGMENT](cor-segment-structure.md) instances by calling the [ICorDebugProcess5::EnumerateHeapRegions](icordebugprocess5-enumerateheapregions-method.md) method. The [COR_SEGMENT](cor-segment-structure.md) objects in the collection can be enumerated by calling the [ICorDebugHeapSegmentEnum::Next](icordebugheapsegmentenum-next-method.md) method.

An `ICorDebugHeapSegmentEnum` collection object enumerates all memory regions that may contain managed objects, but it does not guarantee that managed objects actually reside in those regions. It may include information about empty or reserved memory regions.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5
