---
title: "ICorProfilerCallback::RemotingServerInvocationStarted Method"
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
  - "ICorProfilerCallback.RemotingServerInvocationStarted"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::RemotingServerInvocationStarted"
helpviewer_keywords: 
  - "RemotingServerInvocationStarted method [.NET Framework profiling]"
  - "ICorProfilerCallback::RemotingServerInvocationStarted method [.NET Framework profiling]"
ms.assetid: 86051a11-ad8e-4ace-9a11-ff0f982a5e11
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback::RemotingServerInvocationStarted Method
Notifies the profiler that the process is invoking a method in response to a remote method invocation request.  
  
## Syntax  
  
```  
HRESULT RemotingServerInvocationStarted();  
```  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
