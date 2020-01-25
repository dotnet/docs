---
title: "ICorProfilerInfo9::GetNativeCodeStartAddresses"
ms.date: "08/06/2019"
dev_langs:
  - "cpp"
api_name:
  - "ICorProfilerInfo9.GetNativeCodeStartAddresses"
api_location:
  - "mscorwks.dll"
api_type:
  - "COM"
author: "davmason"
ms.author: "davmason"
---
# ICorProfilerInfo9::GetNativeCodeStartAddresses Method

Given a functionId and rejitId, enumerates the native code start address of all jitted versions of this code that currently exist.

## Syntax

```cpp
HRESULT GetNativeCodeStartAddresses( [in]  FunctionID functionID,
                                     [in]  ReJITID reJitId,
                                     [in]  ULONG32 cCodeStartAddresses,
                                     [out] ULONG32 *pcCodeStartAddresses,
                                     [out] UINT_PTR codeStartAddresses[]);
```

#### Parameters

`functionId` \
[in] The ID of the function whose native code start addresses should be returned.

`reJitId` \
[in] The identity of the JIT-recompiled function.

`cCodeStartAddresses` \
[in] The maximum size of the `codeStartAddresses` array.

`pcCodeStartAddresses` \
[out] The number of available addresses.

`codeStartAddresses` \
[out] An array of `UINT_PTR`, each one of which is the start address for a native body for the specified function.

## Remarks

When tiered compilation is enabled, a function may have more than one native code body.

## Requirements

**Platforms:** See [.NET Core supported operating systems](../../../core/install/dependencies.md?tabs=netcore30&pivots=os-windows).

**Header:** CorProf.idl, CorProf.h

**Library:** CorGuids.lib

**.NET Versions:** [!INCLUDE[net_core_22](../../../../includes/net-core-22-md.md)]

## See also

- [ICorProfilerInfo9 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo9-interface.md)
