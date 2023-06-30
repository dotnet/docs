---
description: "Learn more about: ICorProfilerCallback::ExceptionCLRCatcherFound Method"
title: "ICorProfilerCallback::ExceptionCLRCatcherFound Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ExceptionCLRCatcherFound"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ExceptionCLRCatcherFound"
helpviewer_keywords: 
  - "ICorProfilerCallback::ExceptionCLRCatcherFound method [.NET Framework profiling]"
  - "ExceptionCLRCatcherFound method [.NET Framework profiling]"
ms.assetid: 73fe8b4b-8f9a-4ba5-a10c-b26521396a66
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::ExceptionCLRCatcherFound Method

Called when a `catch` block for an exception is found inside the common language runtime (CLR) itself. This method is obsolete in .NET Framework version 2.0.  
  
## Syntax  
  
```cpp  
HRESULT ExceptionCLRCatcherFound();  
```  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Version:** 1.0  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [ExceptionCLRCatcherExecute Method](icorprofilercallback-exceptionclrcatcherexecute-method.md)
