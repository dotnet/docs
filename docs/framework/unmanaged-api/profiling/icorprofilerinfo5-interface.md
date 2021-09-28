---
description: "Learn more about: ICorProfilerInfo5 Interface"
title: "ICorProfilerInfo5 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo5"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
ms.assetid: 7bd48c34-37ed-4230-9eec-39a17280f05d
topic_type: 
  - "apiref"
---
# ICorProfilerInfo5 Interface

[Supported in the .NET Framework 4.5.2 and later versions]  
  
 A subclass of [ICorProfilerInfo4](icorprofilerinfo4-interface.md) that provides methods for use by code profilers to communicate with the common language runtime (CLR) to control event monitoring.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetEventMask2 Method](icorprofilerinfo5-geteventmask2-method.md)|Gets the current event categories for which the profiler wants to receive notifications from the CLR.|  
|[SetEventMask2 Method](icorprofilerinfo5-seteventmask2-method.md)|Sets a value that specifies the types of events for which the profiler wants to receive event notifications from the CLR.|  
  
## Remarks  

 The methods available on this interface are intended to replace the [ICorProfilerInfo::GetEventMask](icorprofilerinfo-geteventmask-method.md) and [ICorProfilerInfo::SetEventMask](icorprofilerinfo-seteventmask-method.md) methods.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v452plus](../../../../includes/net-current-v452plus-md.md)]  
  
## See also

- [Profiling Interfaces](profiling-interfaces.md)
