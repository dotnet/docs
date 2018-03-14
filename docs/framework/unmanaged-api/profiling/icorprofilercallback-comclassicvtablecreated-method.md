---
title: "ICorProfilerCallback::COMClassicVTableCreated Method"
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
  - "ICorProfilerCallback.COMClassicVTableCreated"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::COMClassicVTableCreated"
helpviewer_keywords: 
  - "COMClassicVTableCreated method [.NET Framework profiling]"
  - "ICorProfilerCallback::COMClassicVTableCreated method [.NET Framework profiling]"
ms.assetid: 6e1834ab-c359-498a-b10b-984ae23cdda4
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback::COMClassicVTableCreated Method
Notifies the profiler that a COM interop vtable for the specified IID and class has been created.  
  
## Syntax  
  
```  
HRESULT COMClassicVTableCreated(  
    [in] ClassID wrappedClassId,  
    [in] REFGUID implementedIID,  
    [in] void    *pVTable,  
    [in] ULONG   cSlots);  
```  
  
#### Parameters  
 `wrappedClasId`  
 [in] The ID of the class for which the vtable has been created.  
  
 `implementedIID`  
 [in] The ID of the interface implemented by the class. This value may be NULL if the interface is internal only.  
  
 `pVTable`  
 [in] A pointer to the start of the vtable.  
  
 `cSlots`  
 [in] The number of slots that are in the vtable.  
  
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
 [COMClassicVTableDestroyed Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-comclassicvtabledestroyed-method.md)
