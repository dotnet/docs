---
title: "ICorProfilerInfo10::RequestReJITWithInliners"
ms.date: "08/DD/YYYY"
dev_langs: 
  - "cpp"
api_name: 
  - "ICorProfilerInfo10.RequestReJITWithInliners"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
ms.assetid: 432a0fa4-0e3f-4604-9c1d-bf71f6d5e163
author: "davmason"
ms.author: "davmason"
---
# ICorProfilerInfo10::RequestReJITWithInliners Method
  
  This method will ReJIT the methods requested, as well as any inliners of the methods requested.  RequestReJIT does not do any tracking of inlined methods. The profiler was expected to track inlining and call RequestReJIT for all inliners to make sure every instance of an inlined method was ReJITted. This poses a problem with ReJIT on attach, since the profiler was not present to monitor inlining. This method can be called to guarantee that the full set of inliners will be ReJITted as well.    
  
## Syntax  
  
```cpp
TODO: Method Signature
```  
  
#### Parameters  
 `TODO: param name`  
 TODO: param description  
  
## Remarks  
 TODO: Remarks  

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_core](../../../../includes/net-core.md)  
  
## See also
- [ICorProfilerInfo10 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo10-interface.md)

