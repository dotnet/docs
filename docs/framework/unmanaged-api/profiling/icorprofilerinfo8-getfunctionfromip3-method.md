---
title: "ICorProfilerInfo8::GetFunctionFromIP3"
ms.date: "08/06/2019"
dev_langs: 
  - "cpp"
api_name: 
  - "ICorProfilerInfo8.GetFunctionFromIP3"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
author: "davmason"
ms.author: "davmason"
---
# ICorProfilerInfo8::GetFunctionFromIP3 Method
  
  Maps a managed code instruction pointer to a FunctionID. This method works for both dynamic and non-dynamic methods.    
  
## Syntax  
  
```cpp
HRESULT GetFunctionFromIP3([in] LPCBYTE ip,
                           [out] FunctionID *functionId,
                           [out] ReJITID * pReJitId);
```  
  
#### Parameters  
 `ip`  
 [in] The instruction pointer in managed code.  

 `pFunctionId`  
 [out] The function ID.  
  
 `pReJitId`  
 [out] The identity of the JIT-recompiled version of the function.  
  
## Remarks  
 This method works for both dynamic and non-dynamic methods. It is a superset of [GetFunctionFromIP2](icorprofilerinfo4-getfunctionfromip2-method.md), which only works for functions with metadata.
  

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)  
  
## See also
- [ICorProfilerInfo8 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo8-interface.md)

