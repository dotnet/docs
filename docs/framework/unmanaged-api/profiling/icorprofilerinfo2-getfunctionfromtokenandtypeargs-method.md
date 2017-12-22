---
title: "ICorProfilerInfo2::GetFunctionFromTokenAndTypeArgs Method"
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
  - "ICorProfilerInfo2.GetFunctionFromTokenAndTypeArgs"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo2::GetFunctionFromTokenAndTypeArgs"
helpviewer_keywords: 
  - "ICorProfilerInfo2::GetFunctionFromTokenAndTypeArgs method [.NET Framework profiling]"
  - "GetFunctionFromTokenAndTypeArgs method [.NET Framework profiling]"
ms.assetid: ce8f6aa6-4ebf-4a86-b429-4bbc8af41a8f
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo2::GetFunctionFromTokenAndTypeArgs Method
Gets the `FunctionID` of a function by using the specified metadata token, containing class, and `ClassID` values of any type arguments.  
  
## Syntax  
  
```  
HRESULT GetFunctionFromTokenAndTypeArgs(  
    [in] ModuleID moduleID,  
    [in] mdMethodDef funcDef,  
    [in] ClassID classId,  
    [in] ULONG32 cTypeArgs,  
    [in, size_is(cTypeArgs)] ClassID typeArgs[],  
    [out] FunctionID* pFunctionID);  
```  
  
#### Parameters  
 `moduleID`  
 [in] The ID of the module in which the function resides.  
  
 `funcDef`  
 [in] An `mdMethodDef` metadata token that references the function.  
  
 `classId`  
 [in] The ID of the function's containing class.  
  
 `cTypeArgs`  
 [in] The number of type parameters for the given function. This value must be zero for non-generic functions.  
  
 `typeArgs`  
 [in] An array of `ClassID` values, each of which is an argument of the function. The value of `typeArgs` can be NULL if `cTypeArgs` is set to zero.  
  
 `pFunctionID`  
 [out] A pointer to the `FunctionID` of the specified function.  
  
## Remarks  
 Calling the `GetFunctionFromTokenAndTypeArgs` method with an `mdMethodRef` metadata instead of an `mdMethodDef` metadata token can have unpredictable results. Callers should resolve the `mdMethodRef` to an `mdMethodDef` when passing it.  
  
 If the function is not already loaded, calling `GetFunctionFromTokenAndTypeArgs` will cause loading to occur, which is a dangerous operation in many contexts. For example, calling this method during loading of modules or types could lead to an infinite loop as the runtime attempts to circularly load things.  
  
 In general, use of `GetFunctionFromTokenAndTypeArgs` is discouraged. If profilers are interested in events for a particular function, they should store the `ModuleID` and `mdMethodDef` of that function, and use [ICorProfilerInfo2::GetFunctionInfo2](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-getfunctioninfo2-method.md) to check whether a given `FunctionID` is that of the desired function.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)  
 [ICorProfilerInfo2 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-interface.md)
