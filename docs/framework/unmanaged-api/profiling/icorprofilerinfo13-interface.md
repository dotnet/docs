---
description: "Learn more about: ICorProfilerInfo13 Interface"
title: "ICorProfilerInfo13 Interface"
ms.date: "03/19/2021"
api_name: 
  - "ICorProfilerInfo13"
api_location: 
  - "coreclr.dll"
  - "corprof.idl"
api_type: 
  - "COM"
---
# ICorProfilerInfo13 Interface

 A subclass of [ICorProfilerInfo12](icorprofilerinfo12-interface.md) that provides methods to manage weak, strong, and pinned handles that wrap objects.
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[CreateHandle Method](icorprofilerinfo13-createhandle-method.md)|Creates a weak, strong, or pinned handle wrapping an object.|
|[DestroyHandle Method](icorprofilerinfo13-destroyhandle-method.md)|Destroys a handle.|
|[GetObjectIDFromHandle Method](icorprofilerinfo13-getobjectidfromhandle-method.md)|Gets the object wrapped by a handle.|

## Requirements  

**Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).

**Header:** CorProf.idl, CorProf.h

**.NET Versions:** [!INCLUDE[net_core](../../../../includes/net-core-70-md.md)]

## See also

- [Profiling Interfaces](profiling-interfaces.md)
