---
title: "ICorProfilerInfo::ForceGC Method"
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
  - "ICorProfilerInfo.ForceGC"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::ForceGC"
helpviewer_keywords: 
  - "ICorProfilerInfo::ForceGC method [.NET Framework profiling]"
  - "ForceGC method [.NET Framework profiling]"
ms.assetid: 0da1ef80-d242-4636-87d0-43e0470b342a
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo::ForceGC Method
Forces garbage collection to occur within the common language runtime (CLR).  
  
## Syntax  
  
```  
HRESULT ForceGC();  
```  
  
## Remarks  
 The `ForceGC` method must be called only from a thread that has never run managed code and does not have any profiler callbacks on its stack. The most convenient implementation is to create a separate thread within the profiler that calls `ForceGC` when signaled.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)
