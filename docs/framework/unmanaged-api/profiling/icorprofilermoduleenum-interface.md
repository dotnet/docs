---
title: "ICorProfilerModuleEnum Interface"
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
  - "ICorProfilerModuleEnum"
api_location: 
  - "mscorwks.cll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerModuleEnum"
helpviewer_keywords: 
  - "ICorProfilerModuleEnum interface [.NET Framework profiling]"
ms.assetid: 24d0fcfa-1601-4fba-868f-da8c97303467
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerModuleEnum Interface
Provides methods to sequentially iterate through a collection of modules loaded by the application or the profiler.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Clone Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilermoduleenum-clone-method.md)|Gets an interface pointer to a copy of this `ICorProfilerModuleEnum` interface.|  
|[GetCount Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilermoduleenum-getcount-method.md)|Gets the number of managed modules that were loaded into the application.|  
|[Next Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilermoduleenum-next-method.md)|Gets the specified number of contiguous modules from a sequential collection of objects, starting at the enumerator's current position in the sequence.|  
|[Reset Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilermoduleenum-reset-method.md)|Moves the enumerator's cursor to the starting position of the sequence.|  
|[Skip Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilermoduleenum-skip-method.md)|Advances the position of the enumerator's cursor so that the specified number of elements are skipped.|  
  
## Remarks  
 The `ICorProfilerModuleEnum` interface is an enumerator. It allows the receiver of an array to pull elements from the sender at a rate that is appropriate for the receiver. In other words, the receiver is able to explicitly control the flow of array elements, thereby avoiding the problems associated with passing large arrays as method parameters.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)  
 [EnumModules Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-enummodules-method.md)
