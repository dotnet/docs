---
description: "Learn more about: ICorProfilerInfo10::GetLOHObjectSizeThreshold Method"
title: "ICorProfilerInfo10::GetLOHObjectSizeThreshold"
ms.date: "08/06/2019"
dev_langs:
  - "cpp"
api_name:
  - "ICorProfilerInfo10.GetLOHObjectSizeThreshold"
api_location:
  - "mscorwks.dll"
api_type:
  - "COM"
author: "davmason"
ms.author: "davmason"
---
# ICorProfilerInfo10::GetLOHObjectSizeThreshold method

Gets the value of the configured large object heap (LOH) threshold.

## Syntax

```cpp
HRESULT GetLOHObjectSizeThreshold( [out] DWORD *pThreshold );
```

## Parameters

`pThreshold`\
[out] The large object heap threshold in bytes.

## Remarks

Objects larger than the large object heap threshold will be allocated on the large object heap. Starting with .NET Core 3.0 the large object heap threshold is configurable, `pThreshold` will contain the active large object heap threshold size in bytes.

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

**Header:** CorProf.idl, CorProf.h

**Library:** CorGuids.lib

**.NET Versions:** Available since .NET Core 3.0

## See also

- [ICorProfilerInfo10 Interface](icorprofilerinfo10-interface.md)
