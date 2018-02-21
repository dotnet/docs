---
title: "ICorProfilerCallback::ObjectAllocated Method"
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
  - "ICorProfilerCallback.ObjectAllocated"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ObjectAllocated"
helpviewer_keywords: 
  - "ObjectAllocated method [.NET Framework profiling]"
  - "ICorProfilerCallback::ObjectAllocated method [.NET Framework profiling]"
ms.assetid: eb412622-77cc-4abd-a2cd-c910fe8edd54
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback::ObjectAllocated Method
Notifies the profiler that memory within the heap has been allocated for an object.  
  
## Syntax  
  
```  
HRESULT ObjectAllocated(  
    [in] ObjectID objectId,  
    [in] ClassID classId);  
```  
  
#### Parameters  
 `objectId`  
 [in] The ID of the object for which memory was allocated.  
  
 `classId`  
 [in] The ID of the class of which the object is an instance.  
  
## Remarks  
 The `ObjectedAllocated` method is not called for allocations from either the stack or unmanaged memory. The `classId` parameter can refer to a class in managed code that has not been loaded yet. The profiler will receive a class load callback for that class immediately after the `ObjectAllocated` callback.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)  
 [ClassLoadStarted Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-classloadstarted-method.md)  
 [ClassLoadFinished Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-classloadfinished-method.md)
