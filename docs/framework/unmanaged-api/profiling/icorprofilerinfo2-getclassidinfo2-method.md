---
title: "ICorProfilerInfo2::GetClassIDInfo2 Method"
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
  - "ICorProfilerInfo2.GetClassIDInfo2"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo2::GetClassIDInfo2"
helpviewer_keywords: 
  - "GetClassIDInfo2 method [.NET Framework profiling]"
  - "ICorProfilerInfo2::GetClassIDInfo2 method [.NET Framework profiling]"
ms.assetid: 0141d582-d066-4d49-8d1f-ae82129a1960
topic_type: 
  - "apiref"
caps.latest.revision: 17
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo2::GetClassIDInfo2 Method
Gets the parent module and metadata token for the open generic definition of the specified class, the `ClassID` of its parent class, and the `ClassID` for each type argument, if present, of the class.  
  
## Syntax  
  
```  
HRESULT GetClassIDInfo2(  
    [in]  ClassID classId,  
    [out] ModuleID *pModuleId,  
    [out] mdTypeDef *pTypeDefToken,  
    [out] ClassID *pParentClassId,  
    [in]  ULONG32 cNumTypeArgs,  
    [out] ULONG32 *pcNumTypeArgs,  
    [out] ClassID typeArgs[]);  
```  
  
#### Parameters  
 `classId`  
 [in] The ID of the class for which information will be retrieved.  
  
 `pModuleId`  
 [out] Pointer to the ID of the parent module for the open generic definition of the specified class.  
  
 `pTypeDefToken`  
 [out] Pointer to the metadata token for the open generic definition of the specified class.  
  
 `pParentClassId`  
 [out] Pointer to the ID of the parent class.  
  
 `cNumTypeArgs`  
 [in] The size of the `typeArgs` array.  
  
 `pcNumTypeArgs`  
 [out] Pointer to the total number of available elements.  
  
 `typeArgs`  
 [out] An array of `ClassID` values, each of which represents the ID of a type argument of the class. When the method returns, `typeArgs` will contain some or all the available `ClassID` values.  
  
## Remarks  
 The `GetClassIDInfo2` method is similar to the [ICorProfilerInfo::GetClassIDInfo](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-getclassidinfo-method.md) method, but `GetClassIDInfo2` obtains additional information about a generic type.  
  
 The profiler code can call [ICorProfilerInfo::GetModuleMetaData](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-getmodulemetadata-method.md) to obtain a [metadata](../../../../docs/framework/unmanaged-api/metadata/index.md) interface for a given module. The metadata token that is returned to the location referenced by `pTypeDefToken` can then be used to access the metadata for the class.  
  
 After `GetClassIDInfo2` returns, you must verify that the `typeArgs` buffer was large enough to contain all the `ClassID` values. To do this, compare the value that `pcNumTypeArgs` points to with the value of the `cNumTypeArgs` parameter. If `pcNumTypeArgs` points to a value that is larger than `cNumTypeArgs`, allocate a larger `typeArgs` buffer, update `cNumTypeArgs` with the new, larger size, and call `GetClassIDInfo2` again.  
  
 Alternatively, you can first call `GetClassIDInfo2` with a zero-length `typeArgs` buffer to obtain the correct buffer size. You can then set the `typeArgs` buffer size to the value returned in `pcNumTypeArgs` and call `GetClassIDInfo2` again.  
  
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
