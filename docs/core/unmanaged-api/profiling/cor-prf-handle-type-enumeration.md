---
description: "Learn more about: COR_PRF_HANDLE_TYPE Enumeration"
title: "COR_PRF_HANDLE_TYPE Enumeration"
ms.date: "03/19/2021"
api_name:
  - "COR_PRF_HANDLE_TYPE"
api_location:
  - "coreclr.dll"
  - "corprof.idl"
api_type:
  - "COM"
---
# COR_PRF_HANDLE_TYPE enumeration

Describes the type of an object handle.

## Syntax

```cpp
typedef enum
{
    COR_PRF_HANDLE_TYPE_WEAK = 0x1,
    COR_PRF_HANDLE_TYPE_STRONG = 0x2,
    COR_PRF_HANDLE_TYPE_PINNED = 0x3
} COR_PRF_HANDLE_TYPE;
```

## Members

|Member|Description|
|------------|-----------------|
|`COR_PRF_HANDLE_TYPE_WEAK`|The handle tracks an object as long as it is alive. It does not act as a root for the garbage collector.|
|`COR_PRF_HANDLE_TYPE_STRONG`|The handle acts as a normal object reference. The object will stay alive and be promoted during the next garbage collection.|
|`COR_PRF_HANDLE_TYPE_PINNED`|The handle acts as a strong handle with an added property to prevent the object from moving in memory during any garbage collection.|

## Remarks

 The `COR_PRF_HANDLE_TYPE` enumeration is used by the [ICorProfilerInfo13::CreateHandle](icorprofilerinfo13-createhandle-method.md) method to indicate the type of handle being created.

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

**Header:** CorProf.idl, CorProf.h

**.NET Versions:** Available since .NET 7.0

## See also

- [ICorProfilerInfo13::CreateHandle](icorprofilerinfo13-createhandle-method.md)
