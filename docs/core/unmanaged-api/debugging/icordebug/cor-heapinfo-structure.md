---
description: "Learn more about: COR_HEAPINFO Structure"
title: "COR_HEAPINFO Structure"
ms.date: "03/30/2017"
api_name:
  - "COR_HEAPINFO"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "COR_HEAPINFO"
helpviewer_keywords:
  - "COR_HEAPINFO structure [.NET debugging]"
topic_type:
  - "apiref"
---
# COR_HEAPINFO Structure

Provides general information about the garbage collection heap, including whether it is enumerable.

## Syntax

```cpp
typedef struct _COR_HEAPINFO {
    BOOL areGCStructuresValid;
    DWORD pointerSize;
    DWORD numHeaps;
    BOOL concurrent;
    CorDebugGCType gcType;
} COR_HEAPINFO;
```

## Members

| Member                 | Description                                                    |
|------------------------|----------------------------------------------------------------|
| `areGCStructuresValid` | `true` if garbage collection structures are valid and the heap can be enumerated; otherwise, `false`. |
| `pointerSize`          | The size, in bytes, of pointers on the target architecture.    |
| `numHeaps`             | The number of logical garbage collection heaps in the process. |
| `concurrent`           | `true` if concurrent (background) garbage collection is enabled; otherwise, `false`. |
| `gcType`               | A member of the [CorDebugGCType](cordebuggctype-enumeration.md) enumeration that indicates whether the garbage collector is running on a workstation or a server. |

## Remarks

 An instance of the `COR_HEAPINFO` structure is returned by calling the [ICorDebugProcess5::GetGCHeapInformation](icordebugprocess5-getgcheapinformation-method.md) method.

 Before enumerating objects on the garbage collection heap, you must always check the `areGCStructuresValid` field to ensure that the heap is in an enumerable state. For more information, see the [ICorDebugProcess5::GetGCHeapInformation](icordebugprocess5-getgcheapinformation-method.md) method.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5
