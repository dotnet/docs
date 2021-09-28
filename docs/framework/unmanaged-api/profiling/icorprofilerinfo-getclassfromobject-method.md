---
description: "Learn more about: ICorProfilerInfo::GetClassFromObject Method"
title: "ICorProfilerInfo::GetClassFromObject Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo.GetClassFromObject"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::GetClassFromObject"
helpviewer_keywords: 
  - "GetClassFromObject method [.NET Framework profiling]"
  - "ICorProfilerInfo::GetClassFromObject method [.NET Framework profiling]"
ms.assetid: b97493fb-713e-49d5-a73e-5688b2ad0700
topic_type: 
  - "apiref"
---
# ICorProfilerInfo::GetClassFromObject Method

Gets the `ClassID` of an object, given its `ObjectID`.  
  
## Syntax  
  
```cpp  
HRESULT GetClassFromObject(  
    [in]  ObjectID objectId,  
    [out] ClassID *pClassId);  
```  
  
## Parameters  

 `objectId`  
 [in] The ID of the object for which to get the `ClassID`.  
  
 `pClassId`  
 [out] A pointer to the returned `ClassID`.  
  
## Remarks  

 A null `pClassId` indicates that `objectId` has a type that is unloading.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
