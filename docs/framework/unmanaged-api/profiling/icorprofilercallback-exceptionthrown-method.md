---
title: "ICorProfilerCallback::ExceptionThrown Method"
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
  - "ICorProfilerCallback.ExceptionThrown"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ExceptionThrown"
helpviewer_keywords: 
  - "ExceptionThrown method [.NET Framework profiling]"
  - "ICorProfilerCallback::ExceptionThrown method [.NET Framework profiling]"
ms.assetid: f1a23f3b-ac21-4905-8abf-8ea59f15af53
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback::ExceptionThrown Method
Notifies the profiler that an exception has been thrown.  
  
> [!NOTE]
>  This function is called only if the exception reaches managed code.  
  
## Syntax  
  
```  
HRESULT ExceptionThrown(  
    [in] ObjectID thrownObjectId);  
```  
  
#### Parameters  
 `thrownObjectId`  
 [in] The ID of the object that caused the exception to be thrown.  
  
## Remarks  
 The profiler should not block in its implementation of this method because the stack may not be in a state that allows garbage collection, and therefore preemptive garbage collection cannot be enabled. If the profiler blocks here and garbage collection is attempted, the runtime will block until this callback returns.  
  
 The profiler's implementation of this method should not call into managed code or in any way cause a managed-memory allocation.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
