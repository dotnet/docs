---
title: "ICorProfilerCallback::ExceptionCLRCatcherFound Method"
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
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback::ExceptionCLRCatcherFound Method
Called when a `catch` block for an exception is found inside the common language runtime (CLR) itself. This method is obsolete in the .NET Framework version 2.0.  
  
## Syntax  
  
```  
HRESULT ExceptionCLRCatcherFound();  
```  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Version:** 1.0  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)  
 [ExceptionCLRCatcherExecute Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-exceptionclrcatcherexecute-method.md)
