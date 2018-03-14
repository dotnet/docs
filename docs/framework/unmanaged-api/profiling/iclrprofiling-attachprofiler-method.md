---
title: "ICLRProfiling::AttachProfiler Method"
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
  - "IClrProfiling.AttachProfiler Method"
api_location: 
  - "Mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IClrProfiling::AttachProfiler"
helpviewer_keywords: 
  - "AttachProfiler method [.NET Framework profiling]"
  - "IClrProfiling::AttachProfiler method [.NET Framework profiling]"
ms.assetid: 535a6839-c443-405b-a6f4-e2af90725d5b
topic_type: 
  - "apiref"
caps.latest.revision: 15
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRProfiling::AttachProfiler Method
Attaches the specified profiler to the specified process.  
  
## Syntax  
  
```  
HRESULT AttachProfiler(  
  [in] DWORD dwProfileeProcessID,  
  [in] DWORD dwMillisecondsMax,                     // optional  
  [in] const CLSID * pClsidProfiler,  
  [in] LPCWSTR wszProfilerPath,                     // optional  
  [in] size_is(cbClientData)] void * pvClientData,  // optional  
  [in] UINT cbClientData);                          // optional  
```  
  
#### Parameters  
 `dwProfileeProcessID`  
 [in] The process ID of the process to which the profiler should be attached. On a 64-bit machine, the profiled process's bitness must match the bitness of the trigger process that is calling `AttachProfiler`. If the user account under which `AttachProfiler` is called has administrative privileges, the target process may be any process on the system. Otherwise, the target process must be owned by the same user account.  
  
 `dwMillisecondsMax`  
 [in] The time duration, in milliseconds, for `AttachProfiler` to complete. The trigger process should pass a timeout that is known to be sufficient for the particular profiler to complete its initialization.  
  
 `pClsidProfiler`  
 [in] A pointer to the CLSID of the profiler to be loaded. The trigger process can reuse this memory after `AttachProfiler` returns.  
  
 `wszProfilerPath`  
 [in] The full path to the profiler’s DLL file to be loaded. This string should contain no more than 260 characters, including the null terminator. If `wszProfilerPath` is null or an empty string, the common language runtime (CLR) will try to find the location of the profiler’s DLL file by looking in the registry for the CLSID that `pClsidProfiler` points to.  
  
 `pvClientData`  
 [in] A pointer to data to be passed to the profiler by the [ICorProfilerCallback3::InitializeForAttach](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback3-initializeforattach-method.md) method. The trigger process can reuse this memory after `AttachProfiler` returns. If `pvClientData` is null, `cbClientData` must be 0 (zero).  
  
 `cbClientData`  
 [in] The size, in bytes, of the data that `pvClientData` points to.  
  
## Return Value  
 This method returns the following HRESULTs.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The specified profiler has successfully attached to the target process.|  
|CORPROF_E_PROFILER_ALREADY_ACTIVE|There is already a profiler active or attaching to the target process.|  
|CORPROF_E_PROFILER_NOT_ATTACHABLE|The specified profiler does not support attachment. The trigger process may attempt to attach a different profiler.|  
|CORPROF_E_PROFILEE_INCOMPATIBLE_WITH_TRIGGER|Unable to request a profiler attachment, because the version of the target process is incompatible with the current process that is calling `AttachProfiler`.|  
|HRESULT_FROM_WIN32(ERROR_ACCESS_DENIED)|The user of the trigger process does not have access to the target process.|  
|HRESULT_FROM_WIN32(ERROR_PRIVILEGE_NOT_HELD)|The user of the trigger process does not have the privileges necessary to attach a profiler to the given target process. The application event log may contain more information.|  
|CORPROF_E_IPC_FAILED|A failure occurred when communicating with the target process. This commonly happens if the target process was shutting down.|  
|HRESULT_FROM_WIN32(ERROR_FILE_NOT_FOUND)|The target process does not exist or is not running a CLR that supports attachment. This may indicate that the CLR was unloaded since the call to the runtime enumeration method.|  
|HRESULT_FROM_WIN32(ERROR_TIMEOUT)|The timeout expired without beginning to load the profiler. You can retry the attach operation. Timeouts occur when a finalizer in the target process runs for a longer time than the timeout value.|  
|E_INVALIDARG|One or more parameters have invalid values.|  
|E_FAIL|Some other, unspecified failure occurred.|  
|Other error codes|If the profiler’s [ICorProfilerCallback3::InitializeForAttach](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback3-initializeforattach-method.md) method returns an HRESULT that indicates failure, `AttachProfiler` returns that same HRESULT. In this case, E_NOTIMPL is converted to CORPROF_E_PROFILER_NOT_ATTACHABLE.|  
  
## Remarks  
  
## Memory Management  
 In keeping with COM conventions, the caller of `AttachProfiler` (for example, the trigger code authored by the profiler developer) is responsible for allocating and de-allocating the memory for the data that the `pvClientData` parameter points to. When the CLR executes the `AttachProfiler` call, it makes a copy of the memory that `pvClientData` points to and transmits it to the target process. When the CLR inside the target process receives its own copy of the `pvClientData` block, it passes the block to the profiler through the `InitializeForAttach` method, and then deallocates its copy of the `pvClientData` block from the target process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)  
 [ICorProfilerInfo3 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-interface.md)  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)  
 [Profiling](../../../../docs/framework/unmanaged-api/profiling/index.md)
