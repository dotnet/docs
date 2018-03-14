---
title: "ICorProfilerCallback::ThreadAssignedToOSThread Method"
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
  - "ICorProfilerCallback.ThreadAssignedToOSThread"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ThreadAssignedToOSThread"
helpviewer_keywords: 
  - "ThreadAssignedToOSThread method [.NET Framework profiling]"
  - "ICorProfilerCallback::ThreadAssignedToOSThread method [.NET Framework profiling]"
ms.assetid: f9671e5a-7b14-4f5b-8404-58136422c8b2
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback::ThreadAssignedToOSThread Method
Notifies the profiler that a managed thread is being implemented using a particular operating system thread.  
  
## Syntax  
  
```  
HRESULT ThreadAssignedToOSThread(  
    [in] ThreadID managedThreadId,  
    [in] DWORD    osThreadId);  
```  
  
#### Parameters  
 `managedThreadId`  
 [in] The identifier of the managed thread.  
  
 `osThreadId`  
 [in] The identifier of the operating system thread.  
  
## Remarks  
 The `ThreadAssignedToOSThread` callback exists so that the profiler can maintain an accurate mapping across fibers of operating system threads to managed threads.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
