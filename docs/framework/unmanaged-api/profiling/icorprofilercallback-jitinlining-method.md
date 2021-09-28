---
description: "Learn more about: ICorProfilerCallback::JITInlining Method"
title: "ICorProfilerCallback::JITInlining Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.JITInlining"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::JITInlining"
helpviewer_keywords: 
  - "JITInlining method [.NET Framework profiling]"
  - "ICorProfilerCallback::JITInlining method [.NET Framework profiling]"
ms.assetid: c2f45801-dd38-4b78-b6b7-64397dc73f83
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::JITInlining Method

Notifies the profiler that the just-in-time (JIT) compiler is about to insert a function in line with another function.  
  
## Syntax  
  
```cpp  
HRESULT JITInlining(  
    [in]  FunctionID callerId,  
    [in]  FunctionID calleeId,  
    [out] BOOL      *pfShouldInline);  
```  
  
## Parameters  

 `callerId`  
 [in] The ID of the function into which the `calleeId` function will be inserted.  
  
 `calleeId`  
 [in] The ID of the function to be inserted.  
  
 `pfShouldInline`  
 [out] `true` to allow the insertion to occur; otherwise, `false`.  
  
## Remarks  

 The profiler can set `pfShouldInline` to `false` to prevent the `calleeId` function from being inserted into the `callerId` function. Also, the profiler can globally disable inline insertion by using the COR_PRF_DISABLE_INLINING value of the [COR_PRF_MONITOR](cor-prf-monitor-enumeration.md) enumeration.  
  
 Functions inserted inline do not raise events for entering or leaving. Therefore, the profiler must set `pfShouldInline` to `false` in order to produce an accurate callgraph. Setting `pfShouldInline` to `false` will affect performance, because inline insertion typically increases speed and reduces the number of separate JIT compilation events for the inserted method.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
