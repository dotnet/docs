---
title: "ICorProfilerCallback::AssemblyUnloadFinished Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.AssemblyUnloadFinished"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::AssemblyUnloadFinished"
helpviewer_keywords: 
  - "AssemblyUnloadFinished method [.NET Framework profiling]"
  - "ICorProfilerCallback::AssemblyUnloadFinished method [.NET Framework profiling]"
ms.assetid: 53fca564-84b1-44d4-9e21-17a492d2aae7
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::AssemblyUnloadFinished Method
Notifies the profiler that an assembly has been unloaded.  
  
## Syntax  
  
```cpp  
HRESULT AssemblyUnloadFinished(  
    [in] AssemblyID assemblyId,  
    [in] HRESULT    hrStatus);  
```  
  
## Parameters  
 `assemblyId`  
 [in] Identifies the assembly that is being unloaded.  
  
 `hrStatus`  
 [in] An HRESULT that indicates whether the assembly was unloaded successfully.  
  
## Remarks  
 The value of `assemblyId` is not valid for an information request after the [ICorProfilerCallback::AssemblyUnloadStarted](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-assemblyunloadstarted-method.md) method returns.  
  
 Some parts of unloading the assembly might continue after the `AssemblyUnloadFinished` callback. A failure HRESULT in `hrStatus` indicates a failure. However, a success HRESULT in `hrStatus` indicates only that the first part of unloading the assembly has succeeded.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
