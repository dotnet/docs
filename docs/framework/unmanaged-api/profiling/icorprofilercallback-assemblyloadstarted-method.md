---
description: "Learn more about: ICorProfilerCallback::AssemblyLoadStarted Method"
title: "ICorProfilerCallback::AssemblyLoadStarted Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.AssemblyLoadStarted"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::AssemblyLoadStarted"
helpviewer_keywords: 
  - "ICorProfilerCallback::AssemblyLoadStarted method [.NET Framework profiling]"
  - "AssemblyLoadStarted method [.NET Framework profiling]"
ms.assetid: 67e8209d-a0ca-4118-a6e6-c1ee0abc2221
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::AssemblyLoadStarted Method

Notifies the profiler that an assembly is being loaded.  
  
## Syntax  
  
```cpp  
HRESULT AssemblyLoadStarted(  
    [in] AssemblyID assemblyId);  
```  
  
## Parameters

`assemblyId`
[in] Identifies the assembly that is being loaded.

## Remarks  

 The value of `assemblyId` is not valid for an information request until the [ICorProfilerCallback::AssemblyLoadFinished](icorprofilercallback-assemblyloadfinished-method.md) method is called.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
