---
description: "Learn more about: ICorProfilerCallback5 Interface"
title: "ICorProfilerCallback5 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback5"
api_location: 
  - "Mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback5"
helpviewer_keywords: 
  - "ICorProfilerCallback5 interface [.NET Framework profiling]"
ms.assetid: 61d2e9ef-5f1f-4771-8847-239616e35d84
topic_type: 
  - "apiref"
---
# ICorProfilerCallback5 Interface

Supplements information to help a profiler identify the full closure of live objects, when used with either the [ICorProfilerCallback::RootReferences](icorprofilercallback-rootreferences-method.md) or [ICorProfilerCallback2::RootReferences2](icorprofilercallback2-rootreferences2-method.md) method together with the [ICorProfilerCallback::ObjectReferences](icorprofilercallback-objectreferences-method.md) and [ConditionalWeakTableElementReferences](icorprofilercallback5-conditionalweaktableelementreferences-method.md) methods.  
  
 `ICorProfilerCallback5` must be implemented by a managed memory profiler to subscribe to notifications related to dependent handles.  
  
## Remarks  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[ConditionalWeakTableElementReferences Method](icorprofilercallback5-conditionalweaktableelementreferences-method.md)|Identifies the transitive closure of objects referenced by those roots through both direct member field references and through `ConditionalWeakTable` dependencies.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [Profiling Interfaces](profiling-interfaces.md)
- [ICorProfilerCallback2 Interface](icorprofilercallback2-interface.md)
