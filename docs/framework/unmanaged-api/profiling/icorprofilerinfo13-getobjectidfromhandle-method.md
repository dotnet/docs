---
description: "Learn more about: ICorProfilerInfo13::GetObjectIDFromHandle Method"
title: "ICorProfilerInfo13::GetObjectIDFromHandle Method"
ms.date: "03/19/2021"
api_name: 
  - "ICorProfilerInfo13.GetObjectIDFromHandle"
api_location: 
  - "coreclr.dll"
  - "corprof.idl"
api_type: 
  - "COM"
---
# ICorProfilerInfo13::GetObjectIDFromHandle Method

Returns the object wrapped by a specified handle.
  
## Syntax  
  
```cpp  
    HRESULT GetObjectIDFromHandle(
                [in] ObjectHandleID handle,
                [out] ObjectID*     pObject);
```  
  
## Parameters

`handle`\
[in] The handle wrapping an object.

`pObject`\
[out] A caller-provided pointer that will point to the object wrapped by the specified `handle`.

## Remarks

If `*pObject` is null, the object wrapped by this handle is no longer alive and has been collected.

## Requirements  

**Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).

**Header:** CorProf.idl, CorProf.h

**.NET Versions:** [!INCLUDE[net_core](../../../../includes/net-core-70-md.md)]
  
## See also

- [Profiling Interfaces](profiling-interfaces.md)
- [ICorProfilerInfo13 Interface](icorprofilerinfo13-interface.md)
