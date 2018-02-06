---
title: "ICorProfilerThreadEnum Interface"
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
  - "ICorProfilerThreadEnum"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerThreadEnum"
helpviewer_keywords: 
  - "ICorProfilerThreadEnum interface [.NET Framework profiling]"
ms.assetid: 1e35031b-e095-4c14-9644-8deeb3081e0b
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerThreadEnum Interface
Provides methods to sequentially iterate through a collection of threads in the common language runtime.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Clone Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerthreadenum-clone-method.md)|Gets an interface pointer to a copy of this `ICorProfilerThreadEnum` interface.|  
|[GetCount Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerthreadenum-getcount-method.md)|Gets the number of threads that are used by the application.|  
|[Next Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerthreadenum-next-method.md)|Gets the specified number of contiguous threads from a sequential collection of threads, starting at the enumerator's current position in the sequence.|  
|[Reset Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerthreadenum-reset-method.md)|Moves the enumerator's cursor to the starting position of the sequence.|  
|[Skip Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerthreadenum-skip-method.md)|Advances the enumerator's cursor from its current position to skip the specified number of elements.|  
  
## Remarks  
 The `ICorProfilerThreadEnum` interface is an enumerator. It allows the receiver of an array to pull elements from the sender at a rate that is appropriate for the receiver. In other words, the receiver is able to explicitly control the flow of array elements, thereby avoiding the problems associated with passing large arrays as method parameters.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)
