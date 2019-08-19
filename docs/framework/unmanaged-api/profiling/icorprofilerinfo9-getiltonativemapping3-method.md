---
title: "ICorProfilerInfo9::GetILToNativeMapping3"
ms.date: "08/06/2019"
dev_langs:
  - "cpp"
api_name:
  - "ICorProfilerInfo9.GetILToNativeMapping3"
api_location:
  - "mscorwks.dll"
api_type:
  - "COM"
author: "davmason"
ms.author: "davmason"
---
# ICorProfilerInfo9::GetILToNativeMapping3 Method

Given the native code start address, returns the native to IL mapping information for this jitted version of the code.

## Syntax

```cpp
HRESULT GetILToNativeMapping3( [in]  UINT_PTR pNativeCodeStartAddress,
                               [in]  ULONG32 cMap,
                               [out] ULONG32 *pcMap,
                               [out] COR_DEBUG_IL_TO_NATIVE_MAP map[]);
```

#### Parameters

`pNativeCodeStartAddress` \
[in] A pointer to the start of a native function.

`cMap` \
[in] The maximum size of the `map` array.

`pcMap` \
[out] The total number of available COR_DEBUG_IL_TO_NATIVE_MAP structures.

`map` \
[out] An array of [COR_DEBUG_IL_TO_NATIVE_MAP](../debugging/cor-debug-il-to-native-map-structure.md) structures, each of which specifies the offsets. After the `GetILToNativeMapping3` method returns, `map` will contain some or all of the `COR_DEBUG_IL_TO_NATIVE_MAP` structures.

## Remarks

When tiered compilation is enabled, a method may have more than one native code body. [ICorProfilerInfo9::GetNativeCodeStartAddresses](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo9-getnativecodestartaddresses-method.md) will return the start addresses for all of the native code bodies.

## Requirements

**Platforms:** See [.NET Core supported operating systems](../../../core/windows-prerequisites.md#net-core-supported-operating-systems).

**Header:** CorProf.idl, CorProf.h

**Library:** CorGuids.lib

**.NET Framework Versions:** [!INCLUDE[net_core_22](../../../../includes/net-core-22-md.md)]

## See also

- [ICorProfilerInfo9 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo9-interface.md)
