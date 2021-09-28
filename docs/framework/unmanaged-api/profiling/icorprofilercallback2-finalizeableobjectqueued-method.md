---
description: "Learn more about: ICorProfilerCallback2::FinalizeableObjectQueued Method"
title: "ICorProfilerCallback2::FinalizeableObjectQueued Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback2.FinalizeableObjectQueued"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback2::FinalizeableObjectQueued"
helpviewer_keywords: 
  - "FinalizeableObjectQueued method [.NET Framework profiling]"
  - "ICorProfilerCallback2::FinalizeableObjectQueued method [.NET Framework profiling]"
ms.assetid: 92d76893-683c-475d-9996-5bff03cdb10f
topic_type: 
  - "apiref"
---
# ICorProfilerCallback2::FinalizeableObjectQueued Method

Notifies the code profiler that an object with a finalizer has been queued to the finalizer thread for execution of its `Finalize` method.  
  
## Syntax  
  
```cpp  
HRESULT FinalizeableObjectQueued(  
    [in] DWORD finalizerFlags,  
    [in] ObjectID objectID);  
```  
  
## Parameters  

 `finalizerFlags`  
 [in] A value of the [COR_PRF_FINALIZER_FLAGS](cor-prf-finalizer-flags-enumeration.md) enumeration that describes aspects of the finalizer.  
  
 `objectID`  
 [in] The ID of the object that has been queued.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [ICorProfilerCallback2 Interface](icorprofilercallback2-interface.md)
