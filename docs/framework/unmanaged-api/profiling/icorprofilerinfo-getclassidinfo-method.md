---
description: "Learn more about: ICorProfilerInfo::GetClassIDInfo Method"
title: "ICorProfilerInfo::GetClassIDInfo Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo.GetClassIDInfo"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::GetClassIDInfo"
helpviewer_keywords: 
  - "GetClassIDInfo method [.NET Framework profiling]"
  - "ICorProfilerInfo::GetClassIDInfo method [.NET Framework profiling]"
ms.assetid: 9e93b99e-5aca-415c-8e37-7f33753b612d
topic_type: 
  - "apiref"
---
# ICorProfilerInfo::GetClassIDInfo Method

Gets the parent module and the metadata token for the specified class.  
  
## Syntax  
  
```cpp  
HRESULT GetClassIDInfo(  
    [in]  ClassID   classId,  
    [out] ModuleID  *pModuleId,  
    [out] mdTypeDef *pTypeDefToken);  
```  
  
## Parameters  

 `classId`  
 [in] The ID of the class for which to get the information.  
  
 `pModuleId`  
 [out] A pointer to the ID of the parent module of the class.  
  
 `pTypeDefToken`  
 [out] A pointer to the metadata token for the class.  
  
## Remarks  

 The profiler code can call [ICorProfilerInfo::GetModuleMetaData](icorprofilerinfo-getmodulemetadata-method.md) to obtain a metadata interface for a given module. The metadata token that is returned to the location referenced by `pTypeDefToken` can then be used to access the metadata for the class.  
  
 To get more information for generic types, use [ICorProfilerInfo2::GetClassIDInfo2](icorprofilerinfo2-getclassidinfo2-method.md).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
