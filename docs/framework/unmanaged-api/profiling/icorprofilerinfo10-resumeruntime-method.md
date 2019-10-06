---
title: "ICorProfilerInfo10::ResumeRuntime"
ms.date: "08/06/2019"
dev_langs:
  - "cpp"
api_name:
  - "ICorProfilerInfo10.ResumeRuntime"
api_location:
  - "mscorwks.dll"
api_type:
  - "COM"
author: "davmason"
ms.author: "davmason"
---
# ICorProfilerInfo10::ResumeRuntime Method

Resumes the runtime without performing a GC.

## Syntax

```cpp
HRESULT ResumeRuntime();
```

## Requirements

**Platforms:** See [.NET Core supported operating systems](../../../core/windows-prerequisites.md#net-core-supported-operating-systems).

**Header:** CorProf.idl, CorProf.h

**Library:** CorGuids.lib

**.NET Versions:** [!INCLUDE[net_core_22](../../../../includes/net-core-30-md.md)]

## See also

- [ICorProfilerInfo10 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo10-interface.md)
