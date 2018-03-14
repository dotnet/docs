---
title: "ICorProfilerInfo2::GetFunctionInfo2 Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ICorProfilerInfo2.GetFunctionInfo2"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo2::GetFunctionInfo2"
helpviewer_keywords: 
  - "GetFunctionInfo2 method [.NET Framework profiling]"
  - "ICorProfilerInfo2::GetFunctionInfo2 method [.NET Framework profiling]"
ms.assetid: 0aa60f24-8bbd-4c83-83c5-86ad191b1d82
topic_type: 
  - "apiref"
caps.latest.revision: 18
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo2::GetFunctionInfo2 Method
Gets the parent class, the metadata token, and the `ClassID` of each type argument, if present, of a function.  
  
## Syntax  
  
```  
HRESULT GetFunctionInfo2(  
    [in]  FunctionID funcId,  
    [in]  COR_PRF_FRAME_INFO frameInfo,  
    [out] ClassID *pClassId,  
    [out] ModuleID *pModuleId,  
    [out] mdToken *pToken,  
    [in]  ULONG32 cTypeArgs,  
    [out] ULONG32 *pcTypeArgs,  
    [out] ClassID typeArgs[]);  
```  
  
#### Parameters  
 `funcId`  
 [in] The ID of the function for which to get the parent class and other information.  
  
 `frameInfo`  
 [in] A `COR_PRF_FRAME_INFO` value that points to information about a stack frame.  
  
 `pClassId`  
 [out] A pointer to the parent class of the function.  
  
 `pModuleId`  
 [out] A pointer to the module in which the function's parent class is defined.  
  
 `pToken`  
 [out] A pointer to the metadata token for the function.  
  
 `cTypeArgs`  
 [in] The size of the `typeArgs` array.  
  
 `pcTypeArgs`  
 [out] A pointer to the total number of `ClassID` values.  
  
 `typeArgs`  
 [out] An array of `ClassID` values, each of which is the ID of a type argument of the function. When the method returns, `typeArgs` will contain some or all of the `ClassID` values.  
  
## Remarks  
 The profiler code can call [ICorProfilerInfo::GetModuleMetaData](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-getmodulemetadata-method.md) to obtain a [metadata](../../../../docs/framework/unmanaged-api/metadata/index.md) interface for a given module. The metadata token that is returned to the location referenced by `pToken` can then be used to access the metadata for the function.  
  
 The class ID and type arguments that are returned through the `pClassId` and `typeArgs` parameters depend on the value that is passed in the `frameInfo` parameter, as shown in the following table.  
  
|Value of the `frameInfo` parameter|Result|  
|----------------------------------------|------------|  
|A `COR_PRF_FRAME_INFO` value that was obtained from a `FunctionEnter2` callback|The `ClassID`, returned in the location referenced by `pClassId`, and all type arguments, returned in the `typeArgs` array, will be exact.|  
|A `COR_PRF_FRAME_INFO` that was obtained from a source other than a `FunctionEnter2` callback|The exact `ClassID` and type arguments cannot be determined. That is, the `ClassID` might be null and some type arguments might come back as <xref:System.Object>.|  
|Zero|The exact `ClassID` and type arguments cannot be determined. That is, the `ClassID` might be null and some type arguments might come back as <xref:System.Object>.|  
  
 After `GetFunctionInfo2` returns, you must verify that the `typeArgs` buffer was large enough to contain all the `ClassID` values. To do this, compare the value that `pcTypeArgs` points to with the value of the `cTypeArgs` parameter. If `pcTypeArgs` points to a value that is larger than `cTypeArgs` divided by the size of a `ClassID` value, allocate a larger `pcTypeArgs` buffer, update `cTypeArgs` with the new, larger size, and call `GetFunctionInfo2` again.  
  
 Alternatively, you can first call `GetFunctionInfo2` with a zero-length `pcTypeArgs` buffer to obtain the correct buffer size. You can then set the buffer size to the value returned in `pcTypeArgs` divided by the size of a `ClassID` value, and call `GetFunctionInfo2` again.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)  
 [ICorProfilerInfo2 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-interface.md)  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)  
 [Profiling](../../../../docs/framework/unmanaged-api/profiling/index.md)
