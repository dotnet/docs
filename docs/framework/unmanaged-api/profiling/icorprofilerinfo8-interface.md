---
title: "ICorProfilerInfo8 Interface"
ms.date: "08/DD/YYYY"
ms.assetid: b5674edb-043b-4476-9d0f-b44ded110dd5
author: "davmason"
ms.author: "davmason"
---
# ICorProfilerInfo8 Interface

A subclass of [ICorProfilerInfo7](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo7-interface.md) that provides ***TODO: Placeholder***  

## Methods  

| Method|Description|  
| ------------|-----------------|  
|[IsFunctionDynamic Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo8-isfunctiondynamic-method.md)| Determines if a function has associated metadata  Certain methods like IL Stubs or LCG Methods do not have associated metadata that can be retrieved using the IMetaDataImport APIs.  Such methods can be encountered by profilers through instruction pointers or by listening to ICorProfilerCallback::DynamicMethodJITCompilationStarted  This API can be used to determine whether a FunctionID is dynamic.  |
|[GetFunctionFromIP3 Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo8-getfunctionfromip3-method.md)| Maps a managed code instruction pointer to a FunctionID.  GetFunctionFromIP2 fails for dynamic methods, this method works for both dynamic and non-dynamic methods. It is a superset of GetFunctionFromIP2  |

## Requirements  
**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
**Header:** CorProf.idl, CorProf.h  
**.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
## See also
- [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)
