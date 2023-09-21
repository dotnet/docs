---
description: "Learn more about: ICorProfilerInfo10 Interface"
title: "ICorProfilerInfo10 Interface"
ms.date: "08/06/2019"
author: "davmason"
ms.author: "davmason"
---
# ICorProfilerInfo10 interface

A subclass of [ICorProfilerInfo9](icorprofilerinfo9-interface.md) that provides methods to modify function IL, query information from the runtime, and suspend and resume the runtime.

## Methods

| Method|Description|
| ------------|-----------------|
|[EnumerateObjectReferences Method](icorprofilerinfo10-enumerateobjectreferences-method.md)|Given an ObjectID, callback and clientData, enumerates each object reference (if any). |
|[IsFrozenObject Method](icorprofilerinfo10-isfrozenobject-method.md)|Given an ObjectID, determines whether the object is in a read-only segment. |
|[GetLOHObjectSizeThreshold Method](icorprofilerinfo10-getlohobjectsizethreshold-method.md)|Gets the value of the configured LOH threshold. |
|[RequestReJITWithInliners Method](icorprofilerinfo10-requestrejitwithinliners-method.md)| ReJITs the methods requested, as well as any inliners of the methods requested.  |
|[SuspendRuntime Method](icorprofilerinfo10-suspendruntime-method.md)| Suspends the runtime without performing a GC. |
|[ResumeRuntime Method](icorprofilerinfo10-resumeruntime-method.md)| Resumes the runtime without performing a GC. |

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).
**Header:** CorProf.idl, CorProf.h
**.NET Versions:** [!INCLUDE[net_core_30](../../../../includes/net-core-30-md.md)]

## See also

- [Profiling Interfaces](profiling-interfaces.md)
