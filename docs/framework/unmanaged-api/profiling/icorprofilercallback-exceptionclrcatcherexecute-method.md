---
description: "Learn more about: ICorProfilerCallback::ExceptionCLRCatcherExecute Method"
title: "ICorProfilerCallback::ExceptionCLRCatcherExecute Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ExceptionCLRCatcherExecute"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ExceptionCLRCatcherExecute"
helpviewer_keywords: 
  - "ExceptionCLRCatcherExecute method [.NET Framework profiling]"
  - "ICorProfilerCallback::ExceptionCLRCatcherExecute method [.NET Framework profiling]"
ms.assetid: aaac8f98-5cf4-42c7-b04b-556cce367e36
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::ExceptionCLRCatcherExecute Method

Called when a `catch` block for an exception is executed inside the common language runtime (CLR) itself. This method is obsolete in .NET Framework version 2.0.  
  
## Syntax  
  
```cpp  
HRESULT ExceptionCLRCatcherExecute();  
```  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** 1.1, 1.0  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [ExceptionCLRCatcherFound Method](icorprofilercallback-exceptionclrcatcherfound-method.md)
