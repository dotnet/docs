---
title: "ICorProfilerInfo::GetClassFromToken Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo.GetClassFromToken"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::GetClassFromToken"
helpviewer_keywords: 
  - "ICorProfilerInfo::GetClassFromToken method [.NET Framework profiling]"
  - "GetClassFromToken method, ICorProfilerInfo interface [.NET Framework profiling]"
ms.assetid: 0afc1197-2a5b-424f-8b82-9cb59a7e00db
topic_type: 
  - "apiref"
---
# ICorProfilerInfo::GetClassFromToken Method
Gets the ID of the class, given the metadata token. This method is obsolete in the .NET Framework version 2.0. Use [ICorProfilerInfo2::GetClassFromTokenAndTypeArgs](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-getclassfromtokenandtypeargs-method.md) instead.  
  
## Syntax  
  
```cpp  
HRESULT GetClassFromToken(  
    [in]  ModuleID  moduleId,  
    [in]  mdTypeDef typeDef,  
    [out] ClassID   *pClassId);  
```  
  
## Parameters  
 `moduleID`  
 [in] The ID of the module that contains the class.  
  
 `typeDef`  
 [in] An `mdTypeDef` metadata token that references the class.  
  
 `cTypeArgs`  
 [out] A pointer to the class ID.  
  
## Remarks  
 This method is obsolete; instead, use `ICorProfilerInfo2::GetClassFromTokenAndTypeArgs` for all types.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** 1.0, 1.1  
  
## See also

- [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)
