---
description: "Learn more about: ICorProfilerInfo13::DestroyHandle Method"
title: "ICorProfilerInfo13::DestroyHandle Method"
ms.date: "03/19/2021"
api_name:
  - "ICorProfilerInfo13.DestroyHandle"
api_location:
  - "coreclr.dll"
  - "corprof.idl"
api_type:
  - "COM"
---
# ICorProfilerInfo13::DestroyHandle method

Destroys a handle that wraps an object.

## Syntax

```cpp
    HRESULT DestroyHandle([in] ObjectHandleID handle);
```

## Parameters

`handle`\
[in] The handle returned by `CreateHandle`.

## Remarks

Once destroyed, a handle can no longer be used.

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

**Header:** CorProf.idl, CorProf.h

**.NET Versions:** Available since .NET 7.0

## See also

- [ICorProfilerInfo13 Interface](icorprofilerinfo13-interface.md)
- [CreateHandle Method](icorprofilerinfo13-createhandle-method.md)
