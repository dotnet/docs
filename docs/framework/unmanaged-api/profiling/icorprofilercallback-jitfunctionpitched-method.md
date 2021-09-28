---
description: "Learn more about: ICorProfilerCallback::JITFunctionPitched Method"
title: "ICorProfilerCallback::JITFunctionPitched Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.JITFunctionPitched"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::JITFunctionPitched"
helpviewer_keywords: 
  - "JITFunctionPitched method [.NET Framework profiling]"
  - "ICorProfilerCallback::JITFunctionPitched method [.NET Framework profiling]"
ms.assetid: 116085df-7a77-404a-afac-d0557a12b986
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::JITFunctionPitched Method

Notifies the profiler that a function that has been just-in-time (JIT)-compiled has been removed from memory.  
  
## Syntax  
  
```cpp  
HRESULT JITFunctionPitched(  
    [in] FunctionID functionId);  
```  
  
## Parameters  

 `functionId`  
 [in] The ID of the function that was removed.  
  
## Remarks  

 If the removed function is called, the profiler will receive new JIT-compilation events when the function is recompiled. Currently, the common language runtime (CLR) JIT compiler does not remove functions from memory, so this callback is currently not used and will not be received by the profiler.  
  
 The value of `functionId` is not valid until the function is recompiled. When the function is recompiled, the same `functionId` value will be used.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
