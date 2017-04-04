---
title: "ICorProfilerCallback::ExceptionOSHandlerLeave Method | Microsoft Docs"
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
  - "ICorProfilerCallback.ExceptionOSHandlerLeave"
apilocation: 
  - "mscorwks.dll"
apitype: "COM"
f1_keywords: 
  - "ICorProfilerCallback::ExceptionOSHandlerLeave"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ExceptionOSHandlerLeave method [.NET Framework profiling]"
  - "ICorProfilerCallback::ExceptionOSHandlerLeave method [.NET Framework profiling]"
ms.assetid: 4d164676-0ee9-4f67-a8ea-cb474db09053
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# ICorProfilerCallback::ExceptionOSHandlerLeave Method
Not implemented. A profiler that needs unmanaged exception information must obtain this information through other means.  
  
## Syntax  
  
```  
HRESULT ExceptionOSHandlerLeave(  
    [in] UINT_PTR __unused);  
```  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)