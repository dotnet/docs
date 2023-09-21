---
description: "Learn more about: ICorProfilerInfo10::EnumerateObjectReferences Method"
title: "ICorProfilerInfo10::EnumerateObjectReferences"
ms.date: "08/06/2019"
dev_langs:
  - "cpp"
api_name:
  - "ICorProfilerInfo10.EnumerateObjectReferences"
api_location:
  - "mscorwks.dll"
api_type:
  - "COM"
author: "davmason"
ms.author: "davmason"
---
# ICorProfilerInfo10::EnumerateObjectReferences method

Given an ObjectID, callback and clientData, enumerates each object reference (if any).

## Syntax

```cpp
HRESULT EnumerateObjectReferences( [in] ObjectID objectId,
                                   [in] ObjectReferenceCallback callback,
                                   [in] void* clientData);
```

## Parameters

`objectId`\
[in] The object to enumerate references on.

`callback`\
[in] The function that will be called with the references for the object.

`clientData`\
[in] Profiler-provided data to pass to the `callback` function.

## Remarks

The `EnumerateObjectReferences` method is similar to [ObjectReferences](../../../framework/unmanaged-api/profiling/icorprofilercallback-objectreferences-method.md), except that it walks the references on demand for the profiler instead of pre-allocating an array to store the references.

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

**Header:** CorProf.idl, CorProf.h

**Library:** CorGuids.lib

**.NET Versions:** Available since .NET Core 3.0

## See also

- [ICorProfilerInfo10 Interface](icorprofilerinfo10-interface.md)
