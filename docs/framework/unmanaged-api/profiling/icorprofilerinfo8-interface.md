---
title: "ICorProfilerInfo8 Interface"
ms.date: "08/06/2019"
author: "davmason"
ms.author: "davmason"
---
# ICorProfilerInfo8 Interface

A subclass of [ICorProfilerInfo7](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo7-interface.md) that provides methods to query information about dynamic methods.

## Methods  

| Method|Description|  
| ------------|-----------------|  
|[IsFunctionDynamic Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo8-isfunctiondynamic-method.md)| Determines if a function does not have associated metadata.|
|[GetFunctionFromIP3 Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo8-getfunctionfromip3-method.md)| Maps a managed code instruction pointer to a FunctionID. This method works for both dynamic and non-dynamic methods. |
|[GetDynamicFunctionInfo Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo8-getdynamicfunctioninfo-method.md)| Retrieves information about dynamic methods. |

## Requirements  
**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
**Header:** CorProf.idl, CorProf.h  
**.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  

## See also

- [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)
