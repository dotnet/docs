---
description: "Learn more about: ICorProfilerCallback::ModuleAttachedToAssembly Method"
title: "ICorProfilerCallback::ModuleAttachedToAssembly Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ModuleAttachedToAssembly"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ModuleAttachedToAssembly"
helpviewer_keywords: 
  - "ICorProfilerCallback::ModuleAttachedToAssembly method [.NET Framework profiling]"
  - "ModuleAttachedToAssembly method [.NET Framework profiling]"
ms.assetid: b595798a-5d40-4cac-ab4f-911c61d2c5d2
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::ModuleAttachedToAssembly Method

Notifies the profiler that a module is being attached to its parent assembly.  
  
## Syntax  
  
```cpp  
HRESULT ModuleAttachedToAssembly(  
    [in] ModuleID   moduleId,  
    [in] AssemblyID AssemblyId);  
```  
  
## Parameters  

 `moduleId`  
 [in] The ID of the module that is being attached.  
  
 `AssemblyId`  
 [in] The ID of the parent assembly to which the module is attached.  
  
## Remarks  

 A module can be loaded through an import address table (IAT), through a call to `LoadLibrary`, or through a metadata reference. As a result, the common language runtime (CLR) loader has multiple code paths for determining the assembly in which a module lives. Therefore, it is possible that after [ICorProfilerCallback::ModuleLoadFinished](icorprofilercallback-moduleloadfinished-method.md) is called, the module does not know what assembly it is in and getting the parent assembly ID is not possible. The `ModuleAttachedToAssembly` method is called when the module is attached to its parent assembly and its parent assembly ID can be obtained.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
