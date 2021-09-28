---
description: "Learn more about: ICorProfilerCallback::ClassUnloadFinished Method"
title: "ICorProfilerCallback::ClassUnloadFinished Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ClassUnloadFinished"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ClassUnloadFinished"
helpviewer_keywords: 
  - "ICorProfilerCallback::ClassUnloadFinished method [.NET Framework profiling]"
  - "ClassUnloadFinished method [.NET Framework profiling]"
ms.assetid: 55674b68-678a-4747-ae06-4e91519c7305
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::ClassUnloadFinished Method

Notifies the profiler that a class has finished unloading.  
  
## Syntax  
  
```cpp  
HRESULT ClassUnloadFinished(  
    [in] ClassID classId,  
    [in] HRESULT hrStatus);  
```  
  
## Parameters

`classId`
[in] Identifies the class that was unloaded.

`hrStatus`
[in] An HRESULT that indicates whether the class was unloaded successfully.
  
## Remarks  

 Some parts of unloading the class might continue after the `ClassUnloadFinished` callback. A failure HRESULT in `hrStatus` indicates a failure. However, a success HRESULT in `hrStatus` indicates only that the first part of unloading the class has succeeded.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [ClassUnloadStarted Method](icorprofilercallback-classunloadstarted-method.md)
