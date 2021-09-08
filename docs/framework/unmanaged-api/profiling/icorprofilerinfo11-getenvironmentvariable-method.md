---
description: "Learn more about: ICorProfilerInfo11::GetEnvironmentVariable Method"
title: "ICorProfilerInfo11::GetEnvironmentVariable Method"
ms.date: "03/19/2021"
api_name: 
  - "ICorProfilerInfo11.GetEnvironmentVariable"
api_location: 
  - "coreclr.dll"
  - "corprof.idl"
api_type: 
  - "COM"
---
# ICorProfilerInfo11::GetEnvironmentVariable Method

Gets an environment variable from the process. On non-Windows platforms the runtime keeps an internal cache of environment variables to ensure thread safety. This means that calling `getenv` will not read any new or updated environment variables set by managed code running in the process after startup.
  
## Syntax  
  
```cpp  
    HRESULT GetEnvironmentVariable(
                [in, string] const WCHAR *szName,
                [in]         ULONG cchValue,
                [out]        ULONG *pcchValue,
                [out, annotation("_Out_writes_to_(cchValue, *pcchValue)")]
                             WCHAR szValue[]);
```  
  
## Parameters

`szName`
[in] A pointer to a null terminated wide character string containing the name of the environment variable to get.

`cchValue`
[in] The length, in characters, of `szValue`.

`pcchValue`
[out] A pointer to the total character length of `szValue`.

`szValue`
[out] A caller provided wide character buffer. When the function returns the buffer will contain the value of the environment variable.

## Requirements  

**Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).  
**Header:** CorProf.idl, CorProf.h  
**.NET Versions:** [!INCLUDE[net_core](../../../../includes/net-core-31-md.md)]  
  
## See also

- [Profiling Interfaces](profiling-interfaces.md)
- [ICorProfilerInfo11 Interface](icorprofilerinfo11-interface.md)
