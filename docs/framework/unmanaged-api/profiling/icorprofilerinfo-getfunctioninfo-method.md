---
description: "Learn more about: ICorProfilerInfo::GetFunctionInfo Method"
title: "ICorProfilerInfo::GetFunctionInfo Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo.GetFunctionInfo"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::GetFunctionInfo"
helpviewer_keywords: 
  - "ICorProfilerInfo::GetFunctionInfo method [.NET Framework profiling]"
  - "GetFunctionInfo method [.NET Framework profiling]"
ms.assetid: c42b5891-019d-46b3-b551-4606295b75b8
topic_type: 
  - "apiref"
---
# ICorProfilerInfo::GetFunctionInfo Method

Gets the parent class and metadata token for the specified function.  
  
## Syntax  
  
```cpp  
HRESULT GetFunctionInfo(  
    [in]  FunctionID functionId,  
    [out] ClassID    *pClassId,  
    [out] ModuleID   *pModuleId,  
    [out] mdToken    *pToken);  
```  
  
## Parameters  

 `functionId`  
 [in] The ID of the function for which to get the parent class and metadata token.  
  
 `pClassId`  
 [out] A pointer to the parent class of the function.  
  
 `pModuleId`  
 [out] A pointer to the module in which the function's parent class is defined.  
  
 `pToken`  
 [out] A pointer to the metadata token for the function.  
  
## Remarks  

 The profiler code can call [ICorProfilerInfo::GetModuleMetaData](icorprofilerinfo-getmodulemetadata-method.md) to obtain a metadata interface for a given module. The metadata token that is returned to the location referenced by `pToken` can then be used to access the metadata for the function.  
  
 The `ClassID` of a function on a generic class might not be obtainable without more contextual information about the use of the function. In this case, `pClassId` will be 0. Profiler code should use [ICorProfilerInfo2::GetFunctionInfo2](icorprofilerinfo2-getfunctioninfo2-method.md) with a COR_PRF_FRAME_INFO value to provide more context.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
