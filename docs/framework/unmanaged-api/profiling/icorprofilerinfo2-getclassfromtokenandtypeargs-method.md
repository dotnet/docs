---
title: "ICorProfilerInfo2::GetClassFromTokenAndTypeArgs Method"
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
  - "ICorProfilerInfo2.GetClassFromTokenAndTypeArgs"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo2::GetClassFromTokenAndTypeArgs"
helpviewer_keywords: 
  - "GetClassFromTokenAndTypeArgs method [.NET Framework profiling]"
  - "ICorProfilerInfo2::GetClassFromTokenAndTypeArgs method [.NET Framework profiling]"
ms.assetid: b25c88f0-71b9-443b-8eea-1c94db0a44b9
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo2::GetClassFromTokenAndTypeArgs Method
Gets the `ClassID` of a type by using the specified metadata token and the `ClassID` values of any type arguments.  
  
## Syntax  
  
```  
HRESULT GetClassFromTokenAndTypeArgs(  
    [in] ModuleID moduleID,  
    [in] mdTypeDef typeDef,  
    [in] ULONG32 cTypeArgs,  
    [in, size_is(cTypeArgs)] ClassID typeArgs[],  
    [out] ClassID* pClassID);  
```  
  
#### Parameters  
 `moduleID`  
 [in] The ID of the module in which the type resides.  
  
 `typeDef`  
 [in] An `mdTypeDef` metadata token that references the type.  
  
 `cTypeArgs`  
 [in] The number of type parameters for the given type. This value must be zero for non-generic types.  
  
 `typeArgs`  
 [in] An array of `ClassID` values, each of which is an argument of the type. The value of `typeArgs` can be NULL if `cTypeArgs` is set to zero.  
  
 `pClassID`  
 [out] A pointer to the `ClassID` of the specified type.  
  
## Remarks  
 Calling the `GetClassFromTokenAndTypeArgs` method with an `mdTypeRef` instead of an `mdTypeDef` metadata token can have unpredictable results; callers should resolve the `mdTypeRef` to an `mdTypeDef` when passing it.  
  
 If the type is not already loaded, calling `GetClassFromTokenAndTypeArgs` will trigger loading, which is a dangerous operation in many contexts. For example, calling this method during loading of modules or other types could lead to an infinite loop as the runtime attempts to circularly load things.  
  
 In general, use of `GetClassFromTokenAndTypeArgs` is discouraged. If profilers are interested in events for a particular type, they should store the `ModuleID` and `mdTypeDef` of that type, and use [ICorProfilerInfo2::GetClassIDInfo2](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-getclassidinfo2-method.md) to check whether a given `ClassID` is that of the desired type.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)  
 [ICorProfilerInfo2 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-interface.md)
