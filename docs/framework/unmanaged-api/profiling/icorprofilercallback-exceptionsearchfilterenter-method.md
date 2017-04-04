---
title: "ICorProfilerCallback::ExceptionSearchFilterEnter Method | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
apiname: 
  - "ICorProfilerCallback.ExceptionSearchFilterEnter"
apilocation: 
  - "mscorwks.dll"
apitype: "COM"
f1_keywords: 
  - "ICorProfilerCallback::ExceptionSearchFilterEnter"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ExceptionSearchFilterEnter method [.NET Framework profiling]"
  - "ICorProfilerCallback::ExceptionSearchFilterEnter method [.NET Framework profiling]"
ms.assetid: acc239ce-3eef-418c-b1df-c5a6dd8e8a4c
caps.latest.revision: 13
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# ICorProfilerCallback::ExceptionSearchFilterEnter Method
Notifies the profiler that the search phase of exception handling has begun executing a user-defined exception filter.  
  
## Syntax  
  
```  
HRESULT ExceptionSearchFilterEnter(  
    [in] FunctionID functionId);  
```  
  
#### Parameters  
 `functionId`  
 [in] The ID of the function that contains the filter.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)   
 [ExceptionSearchFilterLeave Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-exceptionsearchfilterleave-method.md)