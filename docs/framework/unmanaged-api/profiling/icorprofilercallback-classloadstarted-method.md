---
description: "Learn more about: ICorProfilerCallback::ClassLoadStarted Method"
title: "ICorProfilerCallback::ClassLoadStarted Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ClassLoadStarted"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ClassLoadStarted"
helpviewer_keywords: 
  - "ICorProfilerCallback::ClassLoadStarted method [.NET Framework profiling]"
  - "ClassLoadStarted method [.NET Framework profiling]"
ms.assetid: 9f728de8-45c2-45a5-ac4a-45660bd36ecf
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::ClassLoadStarted Method

Notifies the profiler that a class is being loaded.  
  
## Syntax  
  
```cpp  
HRESULT ClassLoadStarted(  
    [in] ClassID classId);  
```  
  
## Parameters

`classId`
[in] Identifies the class that is being loaded.

## Remarks  

 The value of `classId` is not valid for an information request until the [ICorProfilerCallback::ClassLoadFinished](icorprofilercallback-classloadfinished-method.md) method is called.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
