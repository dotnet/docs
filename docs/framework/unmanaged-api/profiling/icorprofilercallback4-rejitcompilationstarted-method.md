---
description: "Learn more about: ICorProfilerCallback4::ReJITCompilationStarted Method"
title: "ICorProfilerCallback4::ReJITCompilationStarted Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback4.ReJITCompilationStarted"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback4::ReJITCompilationStarted"
helpviewer_keywords: 
  - "ReJITCompilationStarted method, ICorProfilerCallback4 interface [.NET Framework profiling]"
  - "ICorProfilerCallback4::ReJITCompilationStarted method [.NET Framework profiling]"
ms.assetid: 512fdd00-262a-4456-a075-365ef4133c4d
topic_type: 
  - "apiref"
---
# ICorProfilerCallback4::ReJITCompilationStarted Method

Notifies the profiler that the just-in-time (JIT) compiler has started to recompile a function.  
  
## Syntax  
  
```cpp  
HRESULT ReJITCompilationStarted(
    [in] FunctionID functionId,  
    [in] ReJITID    rejitId,  
    [in] BOOL       fIsSafeToBlock);  
```  
  
## Parameters  

 `functionId`  
 [in] The ID of the function that the JIT compiler has started to recompile.  
  
 `rejitId`  
 [in] The recompilation ID of the new version of the function.  
  
 `fIsSafeToBlock`  
 [in] `true` to indicate that blocking may cause the runtime to wait for the calling thread to return from this callback; `false` to indicate that blocking will not affect the operation of the runtime. A value of `true` does not harm the runtime, but can affect the profiling results.  
  
## Remarks  

 It is possible to receive more than one pair of `ReJITCompilationStarted` and [ReJITCompilationFinished](icorprofilercallback4-rejitcompilationfinished-method.md) method calls for each function because of the way the runtime handles class constructors. For example, the runtime starts to recompile method A, but the class constructor for class B needs to be run. Therefore, the runtime recompiles the constructor for class B and runs it. While the constructor is running, it makes a call to method A, which causes method A to be recompiled again. In this scenario, the first recompilation of method A is halted. However, both attempts to recompile method A are reported with JIT recompilation events.  
  
 Profilers must support the sequence of JIT recompilation callbacks in cases where two threads are simultaneously making callbacks. For example, thread A calls `ReJITCompilationStarted`; however, before thread A calls [ReJITCompilationFinished](icorprofilercallback4-rejitcompilationfinished-method.md), thread B calls [ICorProfilerCallback::ExceptionSearchFunctionEnter](icorprofilercallback-exceptionsearchfunctionenter-method.md) with the function ID from the `ReJITCompilationStarted` callback for thread A. It might appear that the function ID should not yet be valid because a call to [ReJITCompilationFinished](icorprofilercallback4-rejitcompilationfinished-method.md) had not yet been received by the profiler. However, in this case, the function ID is valid.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [ICorProfilerCallback4 Interface](icorprofilercallback4-interface.md)
- [JITCompilationFinished Method](icorprofilercallback-jitcompilationfinished-method.md)
- [ReJITCompilationFinished Method](icorprofilercallback4-rejitcompilationfinished-method.md)
