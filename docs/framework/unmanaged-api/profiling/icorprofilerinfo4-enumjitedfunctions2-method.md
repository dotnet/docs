---
description: "Learn more about: ICorProfilerInfo4::EnumJITedFunctions2 Method"
title: "ICorProfilerInfo4::EnumJITedFunctions2 Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo4.EnumJITedFunctions2"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo4::EnumJITedFunctions2"
helpviewer_keywords: 
  - "EnumJITedFunctions2 method, ICorProfilerInfo4 interface [.NET Framework profiling]"
  - "ICorProfilerInfo4::EnumJITedFunctions2 method [.NET Framework profiling]"
ms.assetid: 40e9a1be-9bd2-4fad-9921-34a84b61c1e3
topic_type: 
  - "apiref"
---
# ICorProfilerInfo4::EnumJITedFunctions2 Method

Returns an enumerator for all functions that were previously JIT-compiled and JIT-recompiled. This method replaces the [ICorProfilerInfo3::EnumJITedFunctions](icorprofilerinfo3-enumjitedfunctions-method.md) method, which does not enumerate JIT-recompiled IDs.  
  
## Syntax  
  
```cpp  
HRESULT EnumJITedFunctions([out] ICorProfilerFunctionEnum** ppEnum);  
```  
  
## Parameters  

 `ppEnum`  
 [out] A pointer to the [ICorProfilerFunctionEnum](icorprofilerfunctionenum-interface.md) enumerator.  
  
## Remarks  

 This method may overlap with `JITCompilation` callbacks such as the [ICorProfilerCallback::JITCompilationStarted](icorprofilercallback-jitcompilationstarted-method.md) method. The returned enumeration includes values for the `COR_PRF_FUNCTION::reJitId` field. The [ICorProfilerInfo3::EnumJITedFunctions](icorprofilerinfo3-enumjitedfunctions-method.md) method, which this method replaces, does not enumerate JIT-recompiled IDs, because the `COR_PRF_FUNCTION::reJitId` field is always set to 0. The `ICorProfilerInfo4::EnumJITedFunctions` method does enumerate JIT-recompiled IDs, because the `COR_PRF_FUNCTION::reJitId` field is set properly. Note that the [ICorProfilerInfo4::EnumJITedFunctions2](icorprofilerinfo4-enumjitedfunctions2-method.md) method can trigger a garbage collection, whereas [ICorProfilerInfo3::EnumJITedFunctions method](icorprofilerinfo3-enumjitedfunctions-method.md) will not.  For more information, see [CORPROF_E_UNSUPPORTED_CALL_SEQUENCE HRESULT](corprof-e-unsupported-call-sequence-hresult.md).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [EnumJITedFunctions Method](icorprofilerinfo3-enumjitedfunctions-method.md)
- [ICorProfilerInfo4 Interface](icorprofilerinfo4-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)
- [Profiling](index.md)
