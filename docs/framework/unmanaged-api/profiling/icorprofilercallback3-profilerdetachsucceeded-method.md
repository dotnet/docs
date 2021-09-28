---
description: "Learn more about: ICorProfilerCallback3::ProfilerDetachSucceeded Method"
title: "ICorProfilerCallback3::ProfilerDetachSucceeded Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback3.ProfilerDetachSucceeded Method"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback3::ProfilerDetachSucceeded"
helpviewer_keywords: 
  - "ProfilerDetachSucceeded method [.NET Framework profiling]"
  - "ICorProfilerCallback3::ProfilerDetachSucceeded method [.NET Framework profiling]"
ms.assetid: 05164966-16ce-4cc9-a530-43a640c00711
topic_type: 
  - "apiref"
---
# ICorProfilerCallback3::ProfilerDetachSucceeded Method

Notifies the profiler that the common language runtime (CLR) is about to unload the profiler DLL.  
  
## Syntax  
  
```cpp  
HRESULT ProfilerDetachSucceeded();  
```  
  
## Return Value  

 The return value from this callback is ignored.  
  
## Remarks  

 The `ProfilerDetachSucceeded` callback is issued after all threads have exited the profiler's code. When this method is called, the profiler should perform any last-minute tasks that are not appropriate for its destructor, such as notifying its UI or logging component. However, the profiler must not call functions on interfaces that are provided by the CLR during this callback (such as the [ICorProfilerInfo](icorprofilerinfo-interface.md) or `IMetaData*` interfaces).  
  
 The CLR creates an entry in the Windows Application event log to indicate that the detach operation is successful.  
  
 After the profiler returns from this callback, the CLR releases the profiler object and unloads the profiler DLL. Therefore, the profiler must not perform any actions that would cause execution to occur inside the profiler DLL after it returns from this callback. For example, it must not create threads or register timer callbacks.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [Metadata Interfaces](../metadata/metadata-interfaces.md)
- [ICorProfilerInfo3 Interface](icorprofilerinfo3-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)
- [Profiling](index.md)
