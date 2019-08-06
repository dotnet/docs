---
title: "ICorProfilerInfo10 Interface"
ms.date: "08/06/2019"
ms.assetid: 61a5f3e3-9c99-43a8-ab1a-34118e970bb6
author: "davmason"
ms.author: "davmason"
---
# ICorProfilerInfo10 Interface

A subclass of [ICorProfilerInfo9](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo9-interface.md) that provides methods to modify function IL, query information from the runtime, and suspend and resume the runtime.

## Methods  

| Method|Description|  
| ------------|-----------------|  
|[EnumerateObjectReferences Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo10-enumerateobjectreferences-method.md)|Given an ObjectID, callback and clientData, enumerates each object reference (if any). |
|[IsFrozenObject Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo10-isfrozenobject-method.md)|Given an ObjectID, determines whether it is in a read only segment. |
|[GetLOHObjectSizeThreshold Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo10-getlohobjectsizethreshold-method.md)|Gets the value of the configured LOH Threshold. |
|[RequestReJITWithInliners Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo10-requestrejitwithinliners-method.md)| This method will ReJIT the methods requested, as well as any inliners of the methods requested.  |
|[SuspendRuntime Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo10-suspendruntime-method.md)| Suspend the runtime without performing a GC. |
|[ResumeRuntime Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo10-resumeruntime-method.md)| Resume the runtime without performing a GC. |

## Requirements  
**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
**Header:** CorProf.idl, CorProf.h  
**.NET Framework Versions:** [!INCLUDE[net_core_22](../../../../includes/net-core-30-md.md)] 
## See also
- [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)
