---
description: "Learn more about: ICorProfilerAssemblyReferenceProvider Interface"
title: "ICorProfilerAssemblyReferenceProvider Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerAssemblyReferenceProvider"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
ms.assetid: 17205116-66e1-4acc-8f01-532fb3867028
topic_type: 
  - "apiref"
---
# ICorProfilerAssemblyReferenceProvider Interface

[Supported in the .NET Framework 4.5.2 and later versions]  
  
 Enables the profiler to inform the common language runtime (CLR) of assembly references that the profiler will add in the [ICorProfilerCallback::ModuleLoadFinished](icorprofilercallback-moduleloadfinished-method.md) callback.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[AddAssemblyReference Method](icorprofilerassemblyreferenceprovider-addassemblyreference-method.md)|Informs the CLR of an assembly reference that the profiler plans to add in the [ModuleLoadFinished](icorprofilercallback-moduleloadfinished-method.md) callback.|  
  
## Remarks  

 The CLR passes the profiler an `ICorProfilerAssemblyReferenceProvider` interface object in the [ICorProfilerCallback6::GetAssemblyReferences](icorprofilercallback6-getassemblyreferences-method.md) callback. This enables the profiler to inform the CLR of assembly references that the profiler plans to add later in the [ICorProfilerCallback::ModuleLoadFinished](icorprofilercallback-moduleloadfinished-method.md). callback. This improves the accuracy of the CLR's assembly reference closure walker and its algorithms for determining whether assemblies may be shared.  
  
 This interface can be used only in the [ICorProfilerCallback6::GetAssemblyReferences](icorprofilercallback6-getassemblyreferences-method.md) callback that passes this interface object to the profiler.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v452plus](../../../../includes/net-current-v452plus-md.md)]  
  
## See also

- [Profiling Interfaces](profiling-interfaces.md)
