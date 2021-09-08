---
description: "Learn more about: ICorProfilerInfo9::GetCodeInfo4 Method"
title: "ICorProfilerInfo9::GetCodeInfo4"
ms.date: "08/06/2019"
dev_langs:
  - "cpp"
api_name:
  - "ICorProfilerInfo9.GetCodeInfo4"
api_location:
  - "mscorwks.dll"
api_type:
  - "COM"
author: "davmason"
ms.author: "davmason"
---
# ICorProfilerInfo9::GetCodeInfo4 Method

Given the native code start address, returns the blocks of virtual memory that store this code.

## Syntax

```cpp
HRESULT GetCodeInfo4( [in]  UINT_PTR pNativeCodeStartAddress,
                      [in]  ULONG32 cCodeInfos,
                      [out] ULONG32* pcCodeInfos,
                      [out] COR_PRF_CODE_INFO codeInfos[]);
```

## Parameters

`pNativeCodeStartAddress`
[in] A pointer to the start of a native function.

`cCodeInfos`
[in] The size of the `codeInfos` array.

`pcCodeInfos`
[out] A pointer to the total number of [COR_PRF_CODE_INFO](cor-prf-code-info-structure.md) structures available.

`codeInfos`
[out] A caller-provided buffer. After the method returns, it contains an array of `COR_PRF_CODE_INFO` structures, each of which describes a block of native code.

## Remarks

The `GetCodeInfo4` method is similar to [GetCodeInfo3](icorprofilerinfo4-getcodeinfo3-method.md), except that it can look up code information for different native versions of a method.

> [!NOTE]
> `GetCodeInfo4` can trigger a garbage collection.

The extents are sorted in order of increasing Common Intermediate Language (CIL) offset.

After `GetCodeInfo4` returns, you must verify that the `codeInfos` buffer was large enough to contain all the [COR_PRF_CODE_INFO](cor-prf-code-info-structure.md) structures. To do this, compare the value of `cCodeInfos` with the value of the `cchName` parameter. If `cCodeInfos` divided by the size of a [COR_PRF_CODE_INFO](cor-prf-code-info-structure.md) structure is smaller than `pcCodeInfos`, allocate a larger `codeInfos` buffer, update `cCodeInfos` with the new, larger size, and call `GetCodeInfo4` again.

Alternatively, you can first call `GetCodeInfo4` with a zero-length `codeInfos` buffer to obtain the correct buffer size. You can then set the `codeInfos` buffer size to the value returned in `pcCodeInfos`, multiplied by the size of a [COR_PRF_CODE_INFO](cor-prf-code-info-structure.md) structure, and call `GetCodeInfo4` again.

## Requirements

**Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).

**Header:** CorProf.idl, CorProf.h

**Library:** CorGuids.lib

**.NET Versions:** [!INCLUDE[net_core_21](../../../../includes/net-core-21-md.md)]

## See also

- [ICorProfilerInfo9 Interface](icorprofilerinfo9-interface.md)
