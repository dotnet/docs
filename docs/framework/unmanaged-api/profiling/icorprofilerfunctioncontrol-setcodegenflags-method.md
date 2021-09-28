---
description: "Learn more about: ICorProfilerFunctionControl::SetCodegenFlags Method"
title: "ICorProfilerFunctionControl::SetCodegenFlags Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerFunctionControl.SetCodegenFlags"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerFunctionControl::SetCodegenFlags"
helpviewer_keywords: 
  - "ICorProfilerFunctionControl::SetCodegenFlags method [.NET Framework profiling]"
  - "SetCodegenFlags method, ICorProfilerFunctionControl interface [.NET Framework profiling]"
ms.assetid: a2d5daa5-b990-4ae5-bf2a-c0862fe58bd7
topic_type: 
  - "apiref"
---
# ICorProfilerFunctionControl::SetCodegenFlags Method

Sets one or more flags from the [COR_PRF_CODEGEN_FLAGS](cor-prf-codegen-flags-enumeration.md) enumeration to control code generation for a just-in-time (JIT) recompiled function.  
  
## Syntax  
  
```cpp  
HRESULT SetCodegenFlags(  
    [in] DWORD flags);  
```  
  
## Parameters  

 `flags`  
 [in] One or more flags from the [COR_PRF_CODEGEN_FLAGS](cor-prf-codegen-flags-enumeration.md) enumeration.  
  
## Remarks  

 The profiler obtains an instance of this interface through the [ICorProfilerCallback4::GetReJITParameters](icorprofilercallback4-getrejitparameters-method.md) callback. `SetCodegenFlags` allows the profiler to control the code generation for the recompiled function. As with all other JIT recompilation parameters, the code generation flags apply to all instances of the function.  
  
 The JIT compiler considers these compilation flags, along with other flags specified by other sources, when compiling a function.  The other sources include the debugger, global flags set by the profiler on startup by using the [ICorProfilerInfo::SetEventMask](icorprofilerinfo-seteventmask-method.md) method (with the values `COR_PRF_DISABLE_INLINING` and `COR_PRF_DISABLE_OPTIMIZATIONS`), and the profiler’s [ICorProfilerCallback::JITInlining](icorprofilercallback-jitinlining-method.md) callback.  The JIT compiler gives precedence to a source that requests the least amount of optimizing.  For example, if the profiler specifies `COR_PRF_DISABLE_INLINING` on startup, but does not specify `COR_PRF_CODEGEN_DISABLE_INLINING` in the [ICorProfilerFunctionControl::SetCodegenFlags](icorprofilerfunctioncontrol-setcodegenflags-method.md) callback, inlining is still disabled.  Similarly, if the profiler does not specify `COR_PRF_CODEGEN_DISABLE_INLINING` in `SetCodegenFlags`, but then disables inlining by using the [ICorProfilerCallback::JITInlining](icorprofilercallback-jitinlining-method.md) callback, inlining is disabled.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [ICorProfilerFunctionControl Interface](icorprofilerfunctioncontrol-interface.md)
