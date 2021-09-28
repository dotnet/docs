---
description: "Learn more about: ICorProfilerInfo::GetFunctionFromToken Method"
title: "ICorProfilerInfo::GetFunctionFromToken Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo.GetFunctionFromToken"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::GetFunctionFromToken"
helpviewer_keywords: 
  - "ICorProfilerInfo::GetFunctionFromToken method [.NET Framework profiling]"
  - "GetFunctionFromToken method, ICorProfilerInfo interface [.NET Framework profiling]"
ms.assetid: 0eed759f-cce8-405d-88dc-9ee293a38928
topic_type: 
  - "apiref"
---
# ICorProfilerInfo::GetFunctionFromToken Method

Gets the ID of a function. This method is obsolete in the .NET Framework version 2.0. Use the [ICorProfilerInfo2::GetFunctionFromTokenAndTypeArgs](icorprofilerinfo2-getfunctionfromtokenandtypeargs-method.md) method instead.  
  
## Syntax  
  
```cpp  
HRESULT GetFunctionFromToken(  
    [in]  ModuleID   moduleId,  
    [in]  mdToken    token,  
    [out] FunctionID *pFunctionId);  
```  
  
## Remarks  

 The `GetFunctionFromToken` method will not work for generic functions or functions in generic types; it is now obsolete. Use `ICorProfilerInfo2::GetFunctionFromTokenAndTypeArgs` for all functions.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** 1.1, 1.0  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
