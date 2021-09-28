---
description: "Learn more about: ICorProfilerCallback::COMClassicVTableDestroyed Method"
title: "ICorProfilerCallback::COMClassicVTableDestroyed Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.COMClassicVTableDestroyed"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::COMClassicVTableDestroyed"
helpviewer_keywords: 
  - "ICorProfilerCallback::COMClassicVTableDestroyed method [.NET Framework profiling]"
  - "COMClassicVTableDestroyed method [.NET Framework profiling]"
ms.assetid: 29da20ca-bf39-4356-8099-d9c3ac3423a9
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::COMClassicVTableDestroyed Method

Notifies the profiler that a COM interop vtable is being destroyed.  
  
> [!NOTE]
> This callback is likely never to occur, because the destruction of vtables occurs very close to shutdown.  
  
## Syntax  
  
```cpp  
HRESULT COMClassicVTableDestroyed(  
    [in] ClassID wrappedClassId,  
    [in] REFGUID implementedIID,  
    [in] void    *pVTable);  
```  
  
## Parameters

`wrappedClassId`
[in] The ID of the class for which this vtable was created.

`implementedIID`
[in] The ID of the interface implemented by the class. This value may be NULL if the interface is internal only.

`pVTable`
[in] A pointer to the start of the vtable.

## Remarks  

 The profiler should not block in its implementation of this method because the stack may not be in a state that allows garbage collection, and therefore preemptive garbage collection cannot be enabled. If the profiler blocks here and garbage collection is attempted, the runtime will block until this callback returns.  
  
 The profiler's implementation of this method should not call into managed code or in any way cause a managed-memory allocation.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [COMClassicVTableCreated Method](icorprofilercallback-comclassicvtablecreated-method.md)
