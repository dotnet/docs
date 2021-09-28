---
description: "Learn more about: ICorProfilerInfo3::EnumJITedFunctions Method"
title: "ICorProfilerInfo3::EnumJITedFunctions Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo3.EnumJITedFunctions Method"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo3::EnumJITedFunctions"
helpviewer_keywords: 
  - "ICorProfilerInfo3::EnumJITedFunctions method [.NET Framework profiling]"
  - "EnumJITedFunctions method [.NET Framework profiling]"
ms.assetid: e2847a36-f460-45e2-9b6c-b33b008f40d9
topic_type: 
  - "apiref"
---
# ICorProfilerInfo3::EnumJITedFunctions Method

Returns an enumerator for all functions that were previously JIT-compiled.  
  
## Syntax  
  
```cpp  
HRESULT EnumJITedFunctions([out] ICorProfilerFunctionEnum** ppEnum);  
```  
  
## Parameters  

 `ppEnum`  
 [out] A pointer to the [ICorProfilerFunctionEnum](icorprofilerfunctionenum-interface.md) enumerator.  
  
## Remarks  

 This method may overlap with `JITCompilation` callbacks such as the [ICorProfilerCallback::JITCompilationStarted](icorprofilercallback-jitcompilationstarted-method.md) method. The enumerator returned by this method does not include functions that are loaded from native images generated with Ngen.exe.  
  
> [!NOTE]
> The returned enumeration includes only "0" for the value of the `COR_PRF_FUNCTION::reJitId` field.  If you require valid `COR_PRF_FUNCTION::reJitId` values, use the [ICorProfilerInfo4::EnumJITedFunctions2](icorprofilerinfo4-enumjitedfunctions2-method.md) method.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICorProfilerInfo3 Interface](icorprofilerinfo3-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)
- [Profiling](index.md)
