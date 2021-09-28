---
description: "Learn more about: ICorProfilerInfo4::InitializeCurrentThread Method"
title: "ICorProfilerInfo4::InitializeCurrentThread Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo4::InitializeCurrentThread"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo4::InitializeCurrentThread"
helpviewer_keywords: 
  - "ICorProfilerInfo4::InitializeCurrentThread method [.NET Framework profiling]"
  - "InitializeCurrentThread method, ICorProfilerInfo4 interface [.NET Framework profiling]"
ms.assetid: 18a3335c-8c75-476c-b6de-72c0bfedae5d
topic_type: 
  - "apiref"
---
# ICorProfilerInfo4::InitializeCurrentThread Method

Initializes the current thread in advance of subsequent profiler API calls on the same thread, so that deadlock can be avoided.  
  
## Syntax  
  
```cpp  
HRESULT InitializeCurrentThread ();  
```  
  
## Remarks  

 We recommend that you call `InitializeCurrentThread` on any thread that will call a profiler API while there are suspended threads. This method is typically used by sampling profilers that create their own thread to call the [ICorProfilerInfo2::DoStackSnapshot](icorprofilerinfo2-dostacksnapshot-method.md) method to perform stack walks while the target thread is suspended. By calling `InitializeCurrentThread` once when the profiler first creates the sampling thread, profilers can ensure that lazy per-thread initialization that the CLR would otherwise perform during the first call to `DoStackSnapshot` can now occur safely when no other threads are suspended.  
  
> [!NOTE]
> `InitializeCurrentThread` does the initialization in advance to finish tasks that take locks, and may deadlock. Call `InitializeCurrentThread` only when there are no suspended threads.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [ICorProfilerInfo4 Interface](icorprofilerinfo4-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)
- [Profiling](index.md)
