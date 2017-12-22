---
title: "ICorProfilerInfo::GetClassFromToken Method"
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
caps.latest.revision: 15
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo::GetClassFromToken Method
Gets the ID of the class, given the metadata token. This method is obsolete in the .NET Framework version 2.0. Use [ICorProfilerInfo2::GetClassFromTokenAndTypeArgs](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-getclassfromtokenandtypeargs-method.md) instead.  
  
## Syntax  
  
```  
HRESULT GetClassFromToken(  
    [in]  ModuleID  moduleId,  
    [in]  mdTypeDef typeDef,  
    [out] ClassID   *pClassId);  
```  
  
#### Parameters  
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
  
## See Also  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)
