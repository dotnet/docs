---
title: "ICorProfilerInfo8::IsFunctionDynamic"
ms.date: "08/06/2019"
dev_langs:
  - "cpp"
api_name:
  - "ICorProfilerInfo8.IsFunctionDynamic"
api_location:
  - "mscorwks.dll"
api_type:
  - "COM"
author: "davmason"
ms.author: "davmason"
---
# ICorProfilerInfo8::IsFunctionDynamic Method

Determines if a function does not have associated metadata.

## Syntax

```cpp
HRESULT IsFunctionDynamic( [in]  FunctionID  functionId,
                           [out] BOOL        *isDynamic);
```

#### Parameters

`functionId` \
[in]  The `FunctionID` that identifies the function in question.

`isDynamic` \
[out] A pointer to a `BOOL` that will contain a value indicating if the function has no metadata.

## Remarks

A function is considered dynamic if it has no metadata. Certain methods like IL Stubs or LCG Methods do not have associated metadata that can be retrieved using the IMetaDataImport APIs. These methods can be encountered by profilers through instruction pointers or by listening to [ICorProfilerCallback::DynamicMethodJITCompilationStarted](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback8-dynamicmethodjitcompilationstarted-method.md).

## Requirements

**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).

**Header:** CorProf.idl, CorProf.h

**Library:** CorGuids.lib

**.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)

## See also

- [ICorProfilerInfo8 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo8-interface.md)
