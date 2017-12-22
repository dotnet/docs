---
title: "ICorProfilerCallback4::ReJITError Method"
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
  - "ICorProfilerCallback4.ReJITError"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback4::ReJITError"
helpviewer_keywords: 
  - "ReJITError method, ICorProfilerCallback4 interface [.NET Framework profiling]"
  - "ICorProfilerCallback4::ReJITError method [.NET Framework profiling]"
ms.assetid: d7888aa9-dfaa-420f-9f99-e06ab35ca482
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback4::ReJITError Method
Notifies the profiler that the just-in-time (JIT) compiler encountered an error in the recompilation process.  
  
## Syntax  
  
```  
HRESULT ReJITError(  
    [in] ModuleID    moduleId,  
    [in] mdMethodDef methodId,  
    [in] FunctionID  functionId,  
    [in] HRESULT     hrStatus);  
```  
  
#### Parameters  
 `moduleID`  
 [in] The `ModuleID` in which the failed recompilation attempt was made.  
  
 `methodId`  
 [in] The `MethodDef` of the method on which the failed recompilation attempt was made.  
  
 `functionId`  
 [in] The function instance that is being recompiled or marked for recompilation. This value may be `NULL` if the failure occurred on a per-method basis instead of a per-instantiation basis (for example, if the profiler specified an invalid metadata token for the method to be recompiled).  
  
 `hrStatus`  
 [in] An HRESULT that indicates the nature of the failure. See the Status HRESULTS section for a list of values.  
  
## Return Value  
 Return values from this callback are ignored.  
  
## Status HRESULTS  
  
|Status array HRESULT|Description|  
|--------------------------|-----------------|  
|E_INVALIDARG|The `moduleID` or `methodDef` token is `NULL`.|  
|CORPROF_E_DATAINCOMPLETE|The module is not fully loaded yet, or it is in the process of being unloaded.|  
|CORPROF_E_MODULE_IS_DYNAMIC|The specified module was dynamically generated (for example, by `Reflection.Emit`), and is thus not supported by this method.|  
|CORPROF_E_FUNCTION_IS_COLLECTIBLE|The method is instantiated into a collectible assembly, and is therefore not able to be recompiled. Note that types and functions defined in a non-reflection context (for example, `List<MyCollectibleStruct>`) can be instantiated into a collectible assembly.|  
|E_OUTOFMEMORY|The CLR ran out of memory while trying to mark the specified method for JIT recompilation.|  
|Other|The operating system returned a failure outside the control of the CLR. For example, if a system call to change the access protection of a page of memory fails, the operating system error is displayed.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)  
 [ICorProfilerCallback4 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback4-interface.md)
