---
description: "Learn more about: ICorProfilerModuleEnum Interface"
title: "ICorProfilerModuleEnum Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerModuleEnum"
api_location: 
  - "mscorwks.cll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerModuleEnum"
helpviewer_keywords: 
  - "ICorProfilerModuleEnum interface [.NET Framework profiling]"
ms.assetid: 24d0fcfa-1601-4fba-868f-da8c97303467
topic_type: 
  - "apiref"
---
# ICorProfilerModuleEnum Interface

Provides methods to sequentially iterate through a collection of modules loaded by the application or the profiler.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Clone Method](icorprofilermoduleenum-clone-method.md)|Gets an interface pointer to a copy of this `ICorProfilerModuleEnum` interface.|  
|[GetCount Method](icorprofilermoduleenum-getcount-method.md)|Gets the number of managed modules that were loaded into the application.|  
|[Next Method](icorprofilermoduleenum-next-method.md)|Gets the specified number of contiguous modules from a sequential collection of objects, starting at the enumerator's current position in the sequence.|  
|[Reset Method](icorprofilermoduleenum-reset-method.md)|Moves the enumerator's cursor to the starting position of the sequence.|  
|[Skip Method](icorprofilermoduleenum-skip-method.md)|Advances the position of the enumerator's cursor so that the specified number of elements are skipped.|  
  
## Remarks  

 The `ICorProfilerModuleEnum` interface is an enumerator. It allows the receiver of an array to pull elements from the sender at a rate that is appropriate for the receiver. In other words, the receiver is able to explicitly control the flow of array elements, thereby avoiding the problems associated with passing large arrays as method parameters.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)
- [EnumModules Method](icorprofilerinfo3-enummodules-method.md)
