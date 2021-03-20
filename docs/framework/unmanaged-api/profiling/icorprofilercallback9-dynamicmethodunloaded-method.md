---
description: "Learn more about: ICorProfilerCallback9::DynamicMethodUnloaded Method"
title: "ICorProfilerCallback9::DynamicMethodUnloaded Method"
ms.date: "04/10/2018"
api_name: 
  - "ICorProfilerCallback9.DynamicMethodUnloaded"
api_location: 
  - "mscorwks.dll"
  - "corprof.idl"
api_type: 
  - "COM"
---
# ICorProfilerCallback9::DynamicMethodUnloaded Method

[Supported in the .NET Framework 4.7.2 and later versions]  
  
Notifies the profiler whenever a dynamic method is garbage collected and subsequently unloaded.  
  
## Syntax  
  
```cpp  
HRESULT DynamicMethodUnloaded(  
     [in]  FunctionID  functionId
);  
```  
  
## Parameters  

`functionId`
[in] The identifier of the in-memory function that has been garbage collected and unloaded.

## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also

- [ICorProfilerCallback8.DynamicMethodJITCompilationStarted Method](icorprofilercallback8-dynamicmethodjitcompilationstarted-method.md)
- [ICorProfilerCallback8.DynamicMethodJITCompilationFinished Method](icorprofilercallback8-dynamicmethodjitcompilationfinished-method.md)
- [ICorProfilerCallback9 Interface](icorprofilercallback9-interface.md)
- [COR_PRF_HIGH_MONITOR_DYNAMIC_FUNCTION_UNLOADS](cor-prf-high-monitor-enumeration.md)
