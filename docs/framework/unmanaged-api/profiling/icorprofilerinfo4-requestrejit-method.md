---
title: "ICorProfilerInfo4::RequestReJIT Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ICorProfilerInfo4.RequestReJIT"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo4::RequestReJIT"
helpviewer_keywords: 
  - "RequestReJIT method, ICorProfilerInfo4 interface [.NET Framework profiling]"
  - "ICorProfilerInfo4::RequestReJIT method [.NET Framework profiling]"
ms.assetid: 781ed736-f30c-4816-920e-3552e36542c6
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo4::RequestReJIT Method
Requests a JIT recompilation of all instances of the specified functions.  
  
## Syntax  
  
```  
HRESULT RequestReJIT (  
   [in] ULONG    cFunctions,  
   [in, size_is(cFunctions)]  ModuleID    moduleIds[],  
   [in, size_is(cFunctions)]  mdMethodDef methodIds[]);  
```  
  
#### Parameters  
 `cFunctions`  
 [in] The number of functions to recompile.  
  
 `moduleIds`  
 [in] Specifies the `moduleId` portion of the (`module`, `methodDef`) pairs that identify the functions to be recompiled.  
  
 `methodIds`  
 [in] Specifies the `methodId` portion of the (`module`, `methodDef`) pairs that identify the functions to be recompiled.  
  
## Return Value  
 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|An attempt was made to mark all the methods for JIT recompilation. The profiler must implement the [ICorProfilerCallback4::ReJITError](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback4-rejiterror-method.md) method to determine which methods were successfully marked for JIT recompilation.|  
|CORPROF_E_CALLBACK4_REQUIRED|The profiler must implement the [ICorProfilerCallback4](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback4-interface.md) interface for this call to be supported.|  
|CORPROF_E_REJIT_NOT_ENABLED|JIT recompilation has not been enabled. You must enable JIT recompilation during initialization by using the [ICorProfilerInfo::SetEventMask](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-seteventmask-method.md) method to set the `COR_PRF_ENABLE_REJIT` flag.|  
|E_INVALIDARG|`cFunctions` is 0, or `moduleIds` or `methodIds` is `NULL`.|  
|||  
|E_OUTOFMEMORY|The CLR was unable to complete the request because it ran out of memory.|  
  
## Remarks  
 Call `RequestReJIT` to have the runtime recompile a specified set of functions. A code profiler can then use the [ICorProfilerFunctionControl](../../../../docs/framework/unmanaged-api/profiling/icorprofilerfunctioncontrol-interface.md) interface to adjust the code that is generated when the functions are recompiled. This does not affect currently executing functions, only future function invocations. If any of the specified functions has previously been JIT-recompiled, requesting a recompilation is equivalent to reverting and recompiling the function. To preserve reversibility, when the JIT compiler compiles the original version of a function, it considers only the original versions of its callees for inlining decisions. When the JIT compiler recompiles a function, it considers the current versions (recompiled or original) of its callees for inlining.  
  
 A profiler typically calls `RequestReJIT` in response to user input requesting that the profiler instrument one or more methods. `RequestReJIT` typically suspends the runtime in order to do some of its work, and can potentially trigger a garbage collection. As such, the profiler should call `RequestReJIT` from a thread it previously created, and not from a CLR-created thread that is currently executing a profiler callback.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo4 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo4-interface.md)  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)  
 [Profiling](../../../../docs/framework/unmanaged-api/profiling/index.md)
