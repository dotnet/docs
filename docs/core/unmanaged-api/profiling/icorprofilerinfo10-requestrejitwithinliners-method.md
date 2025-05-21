---
description: "Learn more about: ICorProfilerInfo10::RequestReJITWithInliners Method"
title: "ICorProfilerInfo10::RequestReJITWithInliners"
ms.date: "08/06/2019"
dev_langs:
  - "cpp"
api_name:
  - "ICorProfilerInfo10.RequestReJITWithInliners"
api_location:
  - "mscorwks.dll"
api_type:
  - "COM"
author: "davmason"
ms.author: "davmason"
ms.topic: article
---
# ICorProfilerInfo10::RequestReJITWithInliners method

ReJITs the methods requested, as well as any inliners of the methods requested.

## Syntax

```cpp
HRESULT RequestReJITWithInliners( [in]                       DWORD       dwRejitFlags,
                                  [in]                       ULONG       cFunctions,
                                  [in, size_is(cFunctions)]  ModuleID    moduleIds[],
                                  [in, size_is(cFunctions)]  mdMethodDef methodIds[]);
```

## Parameters

`dwRejitFlags`\
[in] A bitmask of [COR_PRF_REJIT_FLAGS](cor-prf-rejit-flags-enumeration.md).

`cFunctions`\
[in] The number of functions to recompile.

`moduleIds`\
[in] Specifies the `moduleId` portion of the (`module`, `methodDef`) pairs that identify the functions to be recompiled.

`methodIds`\
[in] Specifies the `methodId` portion of the (`module`, `methodDef`) pairs that identify the functions to be recompiled.

## Remarks

[RequestReJIT](../../../framework/unmanaged-api/profiling/icorprofilerinfo4-requestrejit-method.md) doesn't track inlined methods. The profiler is expected to either block inlining or track inlining and call `RequestReJIT` for all inliners to make sure every instance of an inlined method was ReJITted. This poses a problem with ReJIT on attach, since the profiler is not present to monitor inlining. This method, `RequestReJITWithInliners`, can be called to guarantee that the full set of inliners is ReJITted as well.

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

**Header:** CorProf.idl, CorProf.h

**Library:** CorGuids.lib

**.NET Versions:** Available since .NET Core 3.0

## See also

- [ICorProfilerInfo10 Interface](icorprofilerinfo10-interface.md)
