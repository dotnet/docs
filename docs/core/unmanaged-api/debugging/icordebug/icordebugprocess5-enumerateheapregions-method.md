---
description: "Learn more about: ICorDebugProcess5::EnumerateHeapRegions Method"
title: "ICorDebugProcess5::EnumerateHeapRegions Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugProcess5.EnumerateHeapRegions"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugProcess5::EnumerateHeapRegions"
helpviewer_keywords:
  - "EnumerateHeapRegions method, ICorDebugProcess5 interface [.NET debugging]"
  - "ICorDebugProcess5::EnumerateHeapRegions method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugProcess5::EnumerateHeapRegions Method

Gets an enumerator for the memory ranges of the managed heap.

## Syntax

```cpp
HRESULT EnumerateHeapRegions(
   [out] ICorDebugHeapSegmentEnum **ppRegions
);
```

## Parameters

 `ppRegions`
 [out] A pointer to the address of an [ICorDebugHeapSegmentEnum](icordebugheapsegmentenum-interface.md) interface object that is an enumerator for the ranges of memory in which objects reside in the managed heap.

## Remarks

 Before calling the `ICorDebugProcess5::EnumerateHeapRegions` method, you should call the [ICorDebugProcess5::GetGCHeapInformation](icordebugprocess5-getgcheapinformation-method.md) method and examine the value of the `areGCStructuresValid` field of the returned [COR_HEAPINFO](cor-heapinfo-structure.md) object to ensure that the garbage collection heap in its current state is enumerable. In addition, the `ICorDebugProcess5::EnumerateHeapRegions` method returns `E_FAIL` if you attach too early in the lifetime of the process, before memory regions are created.

 This method is guaranteed to enumerate all memory regions that may contain managed objects, but it does not guarantee that managed objects actually reside in those regions. The [ICorDebugHeapSegmentEnum](icordebugheapsegmentenum-interface.md) collection object may include empty or reserved memory regions.

 The [ICorDebugHeapSegmentEnum](icordebugheapsegmentenum-interface.md) interface object is a standard enumerator derived from the ICorDebugEnum interface that allows you to enumerate [COR_SEGMENT](cor-segment-structure.md) objects. Each [COR_SEGMENT](cor-segment-structure.md) object provides information about the memory range of a particular segment, along with the generation of the objects in that segment.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5

## See also

- [ICorDebugProcess5 Interface](icordebugprocess5-interface.md)
