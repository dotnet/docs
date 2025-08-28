---
description: "Learn more about: ICorDebugHeapEnum::Next Method"
title: "ICorDebugHeapEnum::Next Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugHeapEnum.Next"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugHeapEnum::Next"
helpviewer_keywords:
  - "ICorDebugHeapEnum::Next method [.NET debugging]"
  - "Next method, ICorDebugHeapEnum interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugHeapEnum::Next Method

Gets the specified number of [COR_HEAPOBJECT](cor-heapobject-structure.md) instances that contain information about objects on the managed heap.

## Syntax

```cpp
HRESULT Next(
    [in] ULONG celt,    [out, size_is(celt), length_is(*pceltFetched)] COR_HEAPOBJECT  objects[],
    [out] ULONG *pceltFetched
);
```

## Parameters

 celt
 [in] The number of objects to be retrieved.

 objects
 [out] An array of pointers, each of which points to a [COR_HEAPOBJECT](cor-heapobject-structure.md) object that provides information about an object on the managed heap.

 pceltFetched
 [out] A pointer to the number of [COR_HEAPOBJECT](cor-heapobject-structure.md) objects actually returned in `objects`. This value may be `null` if `celt` is 1.

## Remarks

 The `COR_HEAPOBJECT.type` field is the identifier of a nested reference-counted COM interface. This reference must be released by the caller of `ICorDebugHeapEnum::Next`.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5

## See also

- [ICorDebugHeapEnum Interface](icordebugheapenum-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
