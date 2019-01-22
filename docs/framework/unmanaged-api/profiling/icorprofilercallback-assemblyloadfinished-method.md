---
title: "ICorProfilerCallback::AssemblyLoadFinished Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.AssemblyLoadFinished"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::AssemblyLoadFinished"
helpviewer_keywords: 
  - "ICorProfilerCallback::AssemblyLoadFinished method [.NET Framework profiling]"
  - "AssemblyLoadFinished method [.NET Framework profiling]"
ms.assetid: 86d98f39-52e6-4c61-a625-9760f695ff12
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ICorProfilerCallback::AssemblyLoadFinished Method
Notifies the profiler that an assembly has finished loading.  
  
## Syntax  
  
```  
HRESULT AssemblyLoadFinished(  
    [in] AssemblyID assemblyId,  
    [in] HRESULT    hrStatus);  
```  
  
#### Parameters  
 `assemblyId`  
 [in] Identifies the assembly that was loaded.  
  
 `hrStatus`  
 [in] An HRESULT that indicates whether the assembly finished loading successfully.  
  
## Remarks  
 The value of `assemblyId` is not valid for an information request until the `AssemblyLoadFinished` method is called.  
  
 Some parts of loading the assembly might continue after the `AssemblyLoadFinished` callback. A failure HRESULT in `hrStatus` indicates a failure. However, a success HRESULT in `hrStatus` indicates only that the first part of loading the assembly has succeeded.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
