---
description: "Learn more about: ICorProfilerInfo13::GetObjectIDFromHandle Method"
title: "ICorProfilerInfo13::GetObjectIDFromHandle Method"
ms.date: "03/19/2021"
api_name:
  - "ICorProfilerInfo13.GetObjectIDFromHandle"
api_location:
  - "coreclr.dll"
  - "corprof.idl"
api_type:
  - "COM"
---
# ICorProfilerInfo13::GetObjectIDFromHandle method

Returns the object wrapped by a specified handle.

## Syntax

```cpp
    HRESULT GetObjectIDFromHandle(
                [in] ObjectHandleID handle,
                [out] ObjectID*     pObject);
```

## Parameters

`handle`\
[in] The handle wrapping an object.

`pObject`\
[out] A caller-provided pointer that will point to the object wrapped by the specified `handle`.

## Remarks

If `*pObject` is null, the object wrapped by this handle is no longer alive and has been collected.

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

**Header:** CorProf.idl, CorProf.h

**.NET Versions:** Available since .NET 7.0

## See also

- [Profiling Interfaces](profiling-interfaces.md)
- [ICorProfilerInfo13 Interface](icorprofilerinfo13-interface.md)
