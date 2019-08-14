---
title: "ICorProfilerInfo10::RequestReJITWithInliners"
ms.date: "08/06/2019"
dev_langs: 
  - "cpp"
api_name: 
  - "ICorProfilerInfo10.RequestReJITWithInliners"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
author: "davmason"
ms.author: "davmason"
---
# ICorProfilerInfo10::RequestReJITWithInliners Method
  
ReJITs the methods requested, as well as any inliners of the methods requested.   
  
## Syntax  
  
```cpp
HRESULT RequestReJITWithInliners( [in]                       DWORD       dwRejitFlags,
                                  [in]                       ULONG       cFunctions,
                                  [in, size_is(cFunctions)]  ModuleID    moduleIds[],
                                  [in, size_is(cFunctions)]  mdMethodDef methodIds[]);
```  
  
#### Parameters  
 
 `dwRejitFlags` \
 [in] A bitmask of [COR_PRF_REJIT_FLAGS](../../../../docs/framework/unmanaged-api/profiling/cor-prf-rejit-flags-enumeration.md).
 
 `cFunctions`  
 [in] The number of functions to recompile.  
  
 `moduleIds`  
 [in] Specifies the `moduleId` portion of the (`module`, `methodDef`) pairs that identify the functions to be recompiled.  
  
 `methodIds`  
 [in] Specifies the `methodId` portion of the (`module`, `methodDef`) pairs that identify the functions to be recompiled.  

## Remarks  
  [RequestReJIT](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo4-requestrejit-method.md) does not do any tracking of inlined methods. The profiler was expected to either block inlining or track inlining and call `RequestReJIT` for all inliners to make sure every instance of an inlined method was ReJITted. This poses a problem with ReJIT on attach, since the profiler is not present to monitor inlining. This method can be called to guarantee that the full set of inliners will be ReJITted as well.  

## Requirements  
 **Platforms:** See [.NET Core supported operating systems](../../../core/windows-prerequisites.md#net-core-supported-operating-systems).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Versions:** [!INCLUDE[net_core_22](../../../../includes/net-core-30-md.md)]
  
## See also
- [ICorProfilerInfo10 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo10-interface.md)

