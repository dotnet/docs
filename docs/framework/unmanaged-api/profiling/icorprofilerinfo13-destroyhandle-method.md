---
description: "Learn more about: ICorProfilerInfo13::DestroyHandle Method"
title: "ICorProfilerInfo13::DestroyHandle Method"
ms.date: "03/19/2021"
api_name: 
  - "ICorProfilerInfo13.DestroyHandle"
api_location: 
  - "coreclr.dll"
  - "corprof.idl"
api_type: 
  - "COM"
---
# ICorProfilerInfo13::DestroyHandle Method

Destroy a handle wrapping an object.
  
## Syntax  
  
```cpp  
    HRESULT DestroyHandle([in] ObjectHandleID handle);
```  
  
## Parameters

`handle`
[in] The handle returned by `CreateHandle`.

## Remarks

Once destroyed, a handle cannot be used anymore.

## Requirements  

**Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).
**Header:** CorProf.idl, CorProf.h
**.NET Versions:** [!INCLUDE[net_core](../../../../includes/net-core-70-md.md)]
  
## See also

- [Profiling Interfaces](profiling-interfaces.md)
- [ICorProfilerInfo13 Interface](ICorProfilerInfo13-interface.md)
- [CreateHandle Method](icorprofilerinfo13-createhandle-method.md)
