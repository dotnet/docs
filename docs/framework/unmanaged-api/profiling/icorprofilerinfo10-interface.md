---
title: "ICorProfilerInfo10 Interface"
ms.date: "08/DD/YYYY"
ms.assetid: 61a5f3e3-9c99-43a8-ab1a-34118e970bb6
author: "davmason"
ms.author: "davmason"
---
# ICorProfilerInfo10 Interface

A subclass of [ICorProfilerInfo1-1](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo1-1-interface.md) that provides ***TODO: Placeholder***  

## Methods  

| Method|Description|  
| ------------|-----------------|  
|[EnumerateObjectReferences Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo10-enumerateobjectreferences-method.md)|Given an ObjectID, callback and clientData, enumerates each object reference (if any). |
|[IsFrozenObject Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo10-isfrozenobject-method.md)|Given an ObjectID, determines whether it is in a read only segment. |
|[GetLOHObjectSizeThreshold Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo10-getlohobjectsizethreshold-method.md)|Gets the value of the configured LOH Threshold. |
|[RequestReJITWithInliners Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo10-requestrejitwithinliners-method.md)| This method will ReJIT the methods requested, as well as any inliners of the methods requested.  RequestReJIT does not do any tracking of inlined methods. The profiler was expected to track inlining and call RequestReJIT for all inliners to make sure every instance of an inlined method was ReJITted. This poses a problem with ReJIT on attach, since the profiler was not present to monitor inlining. This method can be called to guarantee that the full set of inliners will be ReJITted as well.  |
|[SuspendRuntime Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo10-suspendruntime-method.md)|Suspend the runtime without performing a GC. |

## Requirements  
**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
**Header:** CorProf.idl, CorProf.h  
**.NET Framework Versions:** [!INCLUDE[net_core](../../../../includes/net-core.md)]  
## See also
- [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)
