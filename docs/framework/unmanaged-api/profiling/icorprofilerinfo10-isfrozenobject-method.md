---
description: "Learn more about: ICorProfilerInfo10::IsFrozenObject Method"
title: "ICorProfilerInfo10::IsFrozenObject"
ms.date: "08/06/2019"
dev_langs:
  - "cpp"
api_name:
  - "ICorProfilerInfo10.IsFrozenObject"
api_location:
  - "mscorwks.dll"
api_type:
  - "COM"
author: "davmason"
ms.author: "davmason"
---
# ICorProfilerInfo10::IsFrozenObject Method

Given an ObjectID, determines whether the object is in a read-only segment.

## Syntax

```cpp
HRESULT IsFrozenObject( [in]  ObjectID objectId,
                        [out] BOOL *pbFrozen);
```

## Parameters

`objectId`
[in] The object to examine.

`pbFrozen`
[out] A `BOOL` indicating if the object is in a read-only segment.

## Requirements

**Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).

**Header:** CorProf.idl, CorProf.h

**Library:** CorGuids.lib

**.NET Versions:** [!INCLUDE[net_core_30](../../../../includes/net-core-30-md.md)]

## See also

- [ICorProfilerInfo10 Interface](icorprofilerinfo10-interface.md)
