---
description: "Learn more about: ICorProfilerFunctionEnum Interface"
title: "ICorProfilerFunctionEnum Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerFunctionEnum"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerFunctionEnum"
helpviewer_keywords: 
  - "ICorProfilerFunctionEnum interface [.NET Framework profiling]"
ms.assetid: 0a1d4a38-cd0b-4231-91df-13646218ae72
topic_type: 
  - "apiref"
---
# ICorProfilerFunctionEnum Interface

Provides methods to sequentially iterate through a collection of functions in the common language runtime.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Clone Method](icorprofilerfunctionenum-clone-method.md)|Gets an interface pointer to a copy of this `ICorProfilerFunctionEnum` interface.|  
|[GetCount Method](icorprofilerfunctionenum-getcount-method.md)|Gets the number of functions that were loaded by the application or forcibly loaded by the profiler.|  
|[Next Method](icorprofilerfunctionenum-next-method.md)|Gets the specified number of contiguous functions from a sequential collection of functions, starting at the enumerator's current position in the sequence.|  
|[Reset Method](icorprofilerfunctionenum-reset-method.md)|Moves the enumerator's cursor to the starting position of the sequence.|  
|[Skip Method](icorprofilerfunctionenum-skip-method.md)|Advances the enumerator's cursor from its current position so that the specified number of elements are skipped.|  
  
## Remarks  

 The `ICorProfilerFunctionEnum` interface is an enumerator. It allows the receiver of an array to pull elements from the sender at a rate that is appropriate for the receiver. In other words, the receiver is able to explicitly control the flow of array elements, thereby avoiding the problems associated with passing large arrays as method parameters.  
  
 `ICorProfilerFunctionEnum` enumerates over functions that have already been JIT-compiled, but does not include functions that are loaded from native images generated with Ngen.exe.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)
- [EnumJITedFunctions Method](icorprofilerinfo3-enumjitedfunctions-method.md)
