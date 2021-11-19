---
description: "Learn more about: ICorProfilerCallback::AssemblyUnloadStarted Method"
title: "ICorProfilerCallback::AssemblyUnloadStarted Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.AssemblyUnloadStarted"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::AssemblyUnloadStarted"
helpviewer_keywords: 
  - "ICorProfilerCallback::AssemblyUnloadStarted method [.NET Framework profiling]"
  - "AssemblyUnloadStarted method [.NET Framework profiling]"
ms.assetid: 6e47b7e5-0335-4dd3-8c42-d3c07d62b102
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::AssemblyUnloadStarted Method

Notifies the profiler that an assembly is being unloaded.  
  
## Syntax  
  
```cpp  
HRESULT AssemblyUnloadStarted(  
    [in] AssemblyID assemblyId);  
```  
  
## Parameters

`assemblyId`
[in] Identifies the assembly that is being unloaded.

## Remarks  

 The value of `assemblyId` is not valid for an information request after the `AssemblyUnloadStarted` method returns — this is the profiler's last chance to get information about this assembly.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [AssemblyUnloadFinished Method](icorprofilercallback-assemblyunloadfinished-method.md)
