---
description: "Learn more about: ICorProfilerInfo4 Interface"
title: "ICorProfilerInfo4 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo4"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo4"
helpviewer_keywords: 
  - "ICorProfilerInfo4 interface [.NET Framework profiling]"
ms.assetid: 80a5308e-c22f-4201-ba89-31cc8562515b
topic_type: 
  - "apiref"
---
# ICorProfilerInfo4 Interface

Provides methods that code profilers use to communicate with the common language runtime (CLR) to control event monitoring and request information. . The `ICorProfilerInfo4` interface is an extension of the other `ICorProfilerInfo` interfaces. It provides new methods to support just-in-time (JIT) recompilation, added in the .NET Framework 4.5.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[EnumJITedFunctions2 Method](icorprofilerinfo4-enumjitedfunctions2-method.md)|Returns an enumerator for all functions that were previously JIT-compiled and JIT-recompiled.|  
|[EnumThreads Method](icorprofilerinfo4-enumthreads-method.md)|Gets an enumerator that provides methods to sequentially iterate through the collection of all managed threads in the profiled process.|  
|[GetCodeInfo3 Method](icorprofilerinfo4-getcodeinfo3-method.md)|Gets the extents of native code associated with the JIT-recompiled version of the specified function.|  
|[GetFunctionFromIP2 Method](icorprofilerinfo4-getfunctionfromip2-method.md)|Maps a managed code instruction pointer to the JIT-recompiled version of a specified function.|  
|[GetILToNativeMapping2 Method](icorprofilerinfo4-getiltonativemapping2-method.md)|Gets a map from Microsoft intermediate language (MSIL) offsets to native offsets for the code contained in the JIT-recompiled version of the specified function .|  
|[GetObjectSize2 Method](icorprofilerinfo4-getobjectsize2-method.md)|Returns the size of a specified object.|  
|[GetReJITIDs Method](icorprofilerinfo4-getrejitids-method.md)|Returns an array of IDs that identify all JIT-recompiled versions of the specified function that are still allocated.|  
|[InitializeCurrentThread Method](icorprofilerinfo4-initializecurrentthread-method.md)|Initializes the current thread in advance of subsequent profiler API calls on the same thread, so that deadlock can be avoided.|  
|[RequestReJIT Method](icorprofilerinfo4-requestrejit-method.md)|Requests a JIT recompilation of all instances of the specified functions.|  
|[RequestRevert Method](icorprofilerinfo4-requestrevert-method.md)|Reverts all instances of the specified functions to their original versions.|  
  
## Remarks  

 The CLR implements the methods of the `ICorProfilerInfo4` interface by using the free-threaded model. Each method returns an HRESULT to indicate success or failure. For a list of possible return codes, see the CorError.h file.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [Profiling Interfaces](profiling-interfaces.md)
- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
