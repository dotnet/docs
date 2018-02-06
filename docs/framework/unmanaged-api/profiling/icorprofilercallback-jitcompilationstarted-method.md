---
title: "ICorProfilerCallback::JITCompilationStarted Method"
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
  - "ICorProfilerCallback.JITCompilationStarted"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::JITCompilationStarted"
helpviewer_keywords: 
  - "JITCompilationStarted method [.NET Framework profiling]"
  - "ICorProfilerCallback::JITCompilationStarted method [.NET Framework profiling]"
ms.assetid: 31782b36-d311-4518-8f45-25f65385af5b
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback::JITCompilationStarted Method
Notifies the profiler that the just-in-time (JIT) compiler has started to compile a function.  
  
## Syntax  
  
```  
HRESULT JITCompilationStarted(  
    [in] FunctionID functionId,  
    [in] BOOL       fIsSafeToBlock);  
```  
  
#### Parameters  
 `functionId`  
 [in] The ID of the function for which the compilation is starting.  
  
 `fIsSafeToBlock`  
 [in] A value indicating to the profiler whether blocking will affect the operation of the runtime. The value is `true` if blocking may cause the runtime to wait for the calling thread to return from this callback; otherwise, `false`.  
  
 Although a value of `true` will not harm the runtime, it can skew the profiling results.  
  
## Remarks  
 It is possible to receive more than one pair of `JITCompilationStarted` and [ICorProfilerCallback::JITCompilationFinished](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-jitcompilationfinished-method.md) calls for each function because of the way the runtime handles class constructors. For example, the runtime starts to JIT-compile method A, but the class constructor for class B needs to be run. Therefore, the runtime JIT-compiles the constructor for class B and runs it. While the constructor is running, it makes a call to method A, which causes method A to be JIT-compiled again. In this scenario, the first JIT compilation of method A is halted. However, both attempts to JIT-compile method A are reported with JIT-compilation events. If the profiler is going to replace Microsoft intermediate language (MSIL) code for method A by calling the [ICorProfilerInfo::SetILFunctionBody](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-setilfunctionbody-method.md) method, it must do so for both `JITCompilationStarted` events, but it may use the same MSIL block for both.  
  
 Profilers must support the sequence of JIT callbacks in cases where two threads are simultaneously making callbacks. For example, thread A calls `JITCompilationStarted`. However, before thread A calls `JITCompilationFinished`, thread B calls [ICorProfilerCallback::ExceptionSearchFunctionEnter](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-exceptionsearchfunctionenter-method.md) with the function ID from thread A's `JITCompilationStarted` callback. It might appear that the function ID should not yet be valid because a call to `JITCompilationFinished` had not yet been received by the profiler. However, in a case like this one, the function ID is valid.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)  
 [JITCompilationFinished Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-jitcompilationfinished-method.md)
