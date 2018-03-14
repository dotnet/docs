---
title: "ICorProfilerCallback4::GetReJITParameters Method"
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
  - "ICorProfilerCallback4.GetReJITParameters"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback4::GetReJITParameters"
helpviewer_keywords: 
  - "ICorProfilerCallback4::GetReJITParameters method [.NET Framework profiling]"
  - "GetReJITParameters method, ICorProfilerCallback4 interface [.NET Framework profiling]"
ms.assetid: 0e9bfe07-9f20-498c-b568-9017c8f6056c
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback4::GetReJITParameters Method
Allows the code profiler to set alternate code generation flags for a new recompiled method body.  
  
## Syntax  
  
```  
HRESULT GetReJITParameters(     [in] ModuleID moduleId,     [in] mdMethodDef methodId,     [in] ICorProfilerFunctionControl *pFunctionControl);  
```  
  
#### Parameters  
 `moduleID`  
 [in] The module that contains the method for which the CLR needs JIT recompilation parameters.  
  
 `methodId`  
 [in] The `MethodDef` of the method for which the CLR needs JIT recompilation parameters.  
  
 `pFunctionControl`  
 [in] A pointer to an [ICorProfilerFunctionControl](../../../../docs/framework/unmanaged-api/profiling/icorprofilerfunctioncontrol-interface.md) interface that the profiler can use to provide JIT recompilation information for the method being recompiled.  
  
## Remarks  
 The CLR issues a `GetReJITParameters` callback so that the profiler can specify the parameters for recompiling a given method. The `GetReJITParameters` callback is issued only once per function; the parameters supplied by the profiler apply to all instances of that function.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)  
 [ICorProfilerCallback4 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback4-interface.md)  
 [JITCompilationStarted Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-jitcompilationstarted-method.md)  
 [ReJITCompilationStarted Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback4-rejitcompilationstarted-method.md)
