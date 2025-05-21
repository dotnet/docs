---
description: "Learn more about: ICorProfilerInfo10::SuspendRuntime Method"
title: "ICorProfilerInfo10::SuspendRuntime"
ms.date: "08/06/2019"
dev_langs:
  - "cpp"
api_name:
  - "ICorProfilerInfo10.SuspendRuntime"
api_location:
  - "mscorwks.dll"
api_type:
  - "COM"
author: "davmason"
ms.author: "davmason"
ms.topic: article
---
# ICorProfilerInfo10::SuspendRuntime method

Suspends the runtime without performing a GC.

## Syntax

```cpp
HRESULT SuspendRuntime();
```

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

**Header:** CorProf.idl, CorProf.h

**Library:** CorGuids.lib

**.NET Versions:** Available since .NET Core 3.0

## See also

- [ICorProfilerInfo10 Interface](icorprofilerinfo10-interface.md)
