---
description: "Learn more about: ICorProfilerCallback3::ProfilerAttachComplete Method"
title: "ICorProfilerCallback3::ProfilerAttachComplete Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback3.ProfilerAttachComplete Method"
api_location: 
  - "Mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback3::ProfilerAttachComplete"
helpviewer_keywords: 
  - "ProfilerAttachComplete method [.NET Framework profiling]"
  - "ICorProfilerCallback3::ProfilerAttachComplete method [.NET Framework profiling]"
ms.assetid: 257d6076-06e0-4d93-bb33-651fbb2b92d7
topic_type: 
  - "apiref"
---
# ICorProfilerCallback3::ProfilerAttachComplete Method

Called by the common language runtime (CLR) to indicate that the profiler can now call the [ICorProfilerInfo3::EnumJITedFunctions](icorprofilerinfo3-enumjitedfunctions-method.md) and [ICorProfilerInfo3::EnumModules](icorprofilerinfo3-enummodules-method.md) catch-up methods.  
  
## Syntax  
  
```cpp  
HRESULT ProfilerAttachComplete ();  
```  
  
## Remarks  

 The `ProfilerAttachComplete` callback is issued after the [ICorProfilerCallback3::InitializeForAttach](icorprofilercallback3-initializeforattach-method.md) method is called. It indicates the following:  
  
- The callbacks that were requested by the profiler in `InitializeForAttach` have been activated.  
  
- The profiler can now perform catch-up on the associated IDs without being concerned about missing notifications.  
  
 The CLR ignores the return value from this callback.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [ICorProfilerInfo3 Interface](icorprofilerinfo3-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)
- [Profiling](index.md)
