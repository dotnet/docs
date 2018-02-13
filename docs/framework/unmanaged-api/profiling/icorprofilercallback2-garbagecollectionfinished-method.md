---
title: "ICorProfilerCallback2::GarbageCollectionFinished Method"
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
  - "ICorProfilerCallback2.GarbageCollectionFinished"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback2::GarbageCollectionFinished"
helpviewer_keywords: 
  - "ICorProfilerCallback2::GarbageCollectionFinished method [.NET Framework profiling]"
  - "GarbageCollectionFinished method [.NET Framework profiling]"
ms.assetid: 1a5758ea-2354-43c0-92a3-32c9909d64e1
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback2::GarbageCollectionFinished Method
Notifies the profiler that garbage collection has completed and all garbage collection callbacks have been issued for it.  
  
## Syntax  
  
```  
HRESULT GarbageCollectionFinished();  
```  
  
## Remarks  
 It is safe for the profiler to inspect objects in their final locations when the `GarbageCollectionFinished` method is called.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)  
 [ICorProfilerCallback2 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-interface.md)
