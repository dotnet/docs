---
title: "ICorProfilerCallback::ThreadDestroyed Method"
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
  - "ICorProfilerCallback.ThreadDestroyed"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ThreadDestroyed"
helpviewer_keywords: 
  - "ThreadDestroyed method [.NET Framework profiling]"
  - "ICorProfilerCallback::ThreadDestroyed method [.NET Framework profiling]"
ms.assetid: 4c2b66fd-0595-40a3-8931-f9c4fff97ac8
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback::ThreadDestroyed Method
Notifies the profiler that a thread has been destroyed.  
  
## Syntax  
  
```  
HRESULT ThreadDestroyed(  
    [in] ThreadID threadId);  
```  
  
#### Parameters  
 `threadId`  
 [in] The ID of the thread that has been destroyed.  
  
## Remarks  
 The `threadId` value is no longer valid at the time of this call.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)  
 [ThreadCreated Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-threadcreated-method.md)
