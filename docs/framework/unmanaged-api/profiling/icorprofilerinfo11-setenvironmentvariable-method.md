---
description: "Learn more about: ICorProfilerInfo11::SetEnvironmentVariable Method"
title: "ICorProfilerInfo11::SetEnvironmentVariable Method"
ms.date: "03/19/2021"
api_name: 
  - "ICorProfilerInfo11.SetEnvironmentVariable"
api_location: 
  - "coreclr.dll"
  - "corprof.idl"
api_type: 
  - "COM"
---
# ICorProfilerInfo11::SetEnvironmentVariable Method

Sets an environment variable in the process. On non-Windows platforms the runtime keeps an internal cache of environment variables to ensure thread safety. This means that if the profiler calls `setenv` the new environment variable will not be picked up by managed code running in the process.
  
## Syntax  
  
```cpp  
    HRESULT SetEnvironmentVariable(
                [in, string] const WCHAR *szName,
                [in, string] const WCHAR *szValue);
```  
  
## Parameters

`szName`
[in] A pointer to a null terminated wide character string containing the name of the environment variable to set.

`szValue`
[in] A pointer to a null terminated wide character string containing the value of the environment variable to set.

## Requirements  

**Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).  
**Header:** CorProf.idl, CorProf.h  
**.NET Versions:** [!INCLUDE[net_core](../../../../includes/net-core-31-md.md)]  
  
## See also

- [Profiling Interfaces](profiling-interfaces.md)
- [ICorProfilerInfo11 Interface](icorprofilerinfo11-interface.md)
