---
title: "ICorProfilerCallback::RuntimeResumeStarted Method"
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
  - "ICorProfilerCallback.RuntimeResumeStarted"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::RuntimeResumeStarted"
helpviewer_keywords: 
  - "ICorProfilerCallback::RuntimeResumeStarted method [.NET Framework profiling]"
  - "RuntimeResumeStarted method [.NET Framework profiling]"
ms.assetid: 5854bfb2-c568-4f19-904a-7c9d41e7b995
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback::RuntimeResumeStarted Method
Notifies the profiler that the runtime is resuming all run-time threads.  
  
## Syntax  
  
```  
HRESULT RuntimeResumeStarted();  
```  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)  
 [RuntimeResumeFinished Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-runtimeresumefinished-method.md)
