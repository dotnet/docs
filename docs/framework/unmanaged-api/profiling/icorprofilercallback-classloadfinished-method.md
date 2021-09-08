---
description: "Learn more about: ICorProfilerCallback::ClassLoadFinished Method"
title: "ICorProfilerCallback::ClassLoadFinished Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ClassLoadFinished"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ClassLoadFinished"
helpviewer_keywords: 
  - "ClassLoadFinished method [.NET Framework profiling]"
  - "ICorProfilerCallback::ClassLoadFinished method [.NET Framework profiling]"
ms.assetid: 3dd80fbe-d62d-4d4d-acf8-5b7d0efe607e
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::ClassLoadFinished Method

Notifies the profiler that a class has finished loading.  
  
## Syntax  
  
```cpp  
HRESULT ClassLoadFinished(  
    [in] ClassID classId,  
    [in] HRESULT hrStatus);  
```  
  
## Parameters

`classId`
[in] Identifies the class that was loaded.

`hrStatus`
[in] An HRESULT that indicates whether the class loaded successfully.

## Remarks  

 The value of `classId` is not valid for an information request until the `ClassLoadFinished` method is called.  
  
 Some parts of loading the class might continue after the `ClassLoadFinished` callback. A failure HRESULT in `hrStatus` indicates a failure. However, a success HRESULT in `hrStatus` indicates only that the first part of loading the class has succeeded.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [ClassLoadStarted Method](icorprofilercallback-classloadstarted-method.md)
