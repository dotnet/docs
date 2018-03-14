---
title: "ICorProfilerCallback::ExceptionCLRCatcherExecute Method"
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
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback::ExceptionCLRCatcherExecute Method
Called when a `catch` block for an exception is executed inside the common language runtime (CLR) itself. This method is obsolete in the .NET Framework version 2.0.  
  
## Syntax  
  
```  
HRESULT ExceptionCLRCatcherExecute();  
```  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** 1.1, 1.0  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)  
 [ExceptionCLRCatcherFound Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-exceptionclrcatcherfound-method.md)
