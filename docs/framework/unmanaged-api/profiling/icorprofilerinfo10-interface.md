---
title: "ICorProfilerInfo10 Interface"
ms.date: "08/06/2019"
author: "davmason"
ms.author: "davmason"
---
# ICorProfilerInfo10 Interface

A subclass of [ICorProfilerInfo9](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo9-interface.md) that provides methods to modify function IL, query information from the runtime, and suspend and resume the runtime.

## Methods  

| Method|Description|  
| ------------|-----------------|  
|[EnumerateObjectReferences Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo10-enumerateobjectreferences-method.md)|Given an ObjectID, callback and clientData, enumerates each object reference (if any). |
|[IsFrozenObject Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo10-isfrozenobject-method.md)|Given an ObjectID, determines whether the object is in a read-only segment. |
|[GetLOHObjectSizeThreshold Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo10-getlohobjectsizethreshold-method.md)|Gets the value of the configured LOH threshold. |
|[RequestReJITWithInliners Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo10-requestrejitwithinliners-method.md)| ReJITs the methods requested, as well as any inliners of the methods requested.  |
|[SuspendRuntime Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo10-suspendruntime-method.md)| Suspends the runtime without performing a GC. |
|[ResumeRuntime Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo10-resumeruntime-method.md)| Resumes the runtime without performing a GC. |

## Requirements  
**Platforms:** See [.NET Core supported operating systems](../../../core/windows-prerequisites.md#net-core-supported-operating-systems).  
**Header:** CorProf.idl, CorProf.h  
**.NET Versions:** [!INCLUDE[net_core_22](../../../../includes/net-core-30-md.md)] 

## See also

- [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)
