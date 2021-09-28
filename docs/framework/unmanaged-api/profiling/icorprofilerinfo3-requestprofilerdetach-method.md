---
description: "Learn more about: ICorProfilerInfo3::RequestProfilerDetach Method"
title: "ICorProfilerInfo3::RequestProfilerDetach Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo3.RequestProfilerDetach Method"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo3::RequestProfilerDetach"
helpviewer_keywords: 
  - "RequestProfilerDetach method [.NET Framework profiling]"
  - "ICorProfilerInfo3::RequestProfilerDetach method [.NET Framework profiling]"
ms.assetid: ea102e62-0454-4477-bcf3-126773acd184
topic_type: 
  - "apiref"
---
# ICorProfilerInfo3::RequestProfilerDetach Method

Instructs the runtime to detach the profiler.  
  
## Syntax  
  
```cpp  
HRESULT RequestProfilerDetach(  
   [in] DWORD    dwExpectedCompletionMilliseconds);  
```  
  
## Parameters  

 `dwExpectedCompletionMilliseconds`  
 [in] The length of time, in milliseconds, the common language runtime (CLR) should wait before checking to see whether it is safe to unload the profiler.  
  
## Return Value  

 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The detach request is valid, and the detach procedure is now continuing on another thread. When the detach is fully complete, a `ProfilerDetachSucceeded` event is issued.|  
|E_CORPROF_E_CALLBACK3_REQUIRED|The profiler failed an [IUnknown::QueryInterface](/windows/win32/api/unknwn/nf-unknwn-iunknown-queryinterface(q)) attempt for the [ICorProfilerCallback3](icorprofilercallback3-interface.md) interface, which it must implement to support the detach operation. Detach was not attempted.|  
|CORPROF_E_IMMUTABLE_FLAGS_SET|Detachment is impossible because the profiler set immutable flags at startup. Detachment was not attempted; the profiler is still fully attached.|  
|CORPROF_E_IRREVERSIBLE_INSTRUMENTATION_PRESENT|Detachment is impossible because the profiler used instrumented Microsoft intermediate language (MSIL) code, or inserted `enter`/`leave` hooks. Detachment was not attempted; the profiler is still fully attached.<br /><br /> **Note** Instrumented MSIL is code is code that is provided by the profiler using the [SetILFunctionBody](icorprofilerinfo-setilfunctionbody-method.md) method.|  
|CORPROF_E_RUNTIME_UNINITIALIZED|The runtime has not been initialized yet in the managed application. (That is, the runtime has not been fully loaded.) This error code may be returned when detachment is requested inside the profiler callback's [ICorProfilerCallback::Initialize](icorprofilercallback-initialize-method.md) method.|  
|CORPROF_E_UNSUPPORTED_CALL_SEQUENCE|`RequestProfilerDetach` was called at an unsupported time. This occurs if the method is called on a managed thread but not from within an [ICorProfilerCallback](icorprofilercallback-interface.md) method or from within an [ICorProfilerCallback](icorprofilercallback-interface.md) method that cannot tolerate a garbage collection. For more information, see [CORPROF_E_UNSUPPORTED_CALL_SEQUENCE HRESULT](corprof-e-unsupported-call-sequence-hresult.md).|  
  
## Remarks  

 During the detach procedure, the detach thread (the thread created specifically for detaching the profiler) occasionally checks whether all threads have exited the profiler’s code. The profiler should provide an estimate of how long this should take through the `dwExpectedCompletionMilliseconds` parameter. A good value to use is the typical amount of time the profiler spends inside any given `ICorProfilerCallback*` method; this value should not be less than half of the maximum amount of time the profiler expects to spend.  
  
 The detach thread uses `dwExpectedCompletionMilliseconds` to decide how long to sleep before checking whether profiler callback code has been popped off all stacks. Although the details of the following algorithm may change in future releases of the CLR, it illustrates one way `dwExpectedCompletionMilliseconds` can be used when determining when it is safe to unload the profiler. The detach thread first sleeps for `dwExpectedCompletionMilliseconds` milliseconds. If, after awakening from the sleep, the CLR finds that profiler callback code is still present, the detach thread sleeps again, this time for two times `dwExpectedCompletionMilliseconds` milliseconds. If, after awakening from this second sleep, the detach thread finds that profiler callback code is still present, it sleeps for 10 minutes before checking again. The detach thread continues to recheck every 10 minutes.  
  
 If the profiler specifies `dwExpectedCompletionMilliseconds` as 0 (zero), the CLR uses a default value of 5000, which means that it will perform a check after 5 seconds, again after 10 seconds, and then every 10 minutes thereafter.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICorProfilerInfo3 Interface](icorprofilerinfo3-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)
- [Profiling](index.md)
