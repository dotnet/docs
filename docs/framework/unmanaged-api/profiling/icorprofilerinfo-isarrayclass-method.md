---
description: "Learn more about: ICorProfilerInfo::IsArrayClass Method"
title: "ICorProfilerInfo::IsArrayClass Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo.IsArrayClass"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::IsArrayClass"
helpviewer_keywords: 
  - "IsArrayClass method [.NET Framework profiling]"
  - "ICorProfilerInfo::IsArrayClass method [.NET Framework profiling]"
ms.assetid: 7f230961-23a6-4d56-ad2d-7a876d65705f
topic_type: 
  - "apiref"
---
# ICorProfilerInfo::IsArrayClass Method

Determines whether the specified class is an array class.  
  
## Syntax  
  
```cpp  
HRESULT IsArrayClass(  
    [in]  ClassID        classId,  
    [out] CorElementType *pBaseElemType,  
    [out] ClassID        *pBaseClassId,  
    [out] ULONG          *pcRank);  
```  
  
## Parameters  

 `classId`  
 [in] The ID of the class to be examined.  
  
 `pBaseElemType`  
 [out] A pointer to a value of the CorElementType enumeration that indicates the type of the array elements.  
  
 `pBaseClassId`  
 [out] A pointer to the class ID of the array elements, when available.  
  
 `pcRank`  
 [out] A pointer to an integer that indicates the rank (that is, number of dimensions) of the array.  
  
## Remarks  

 If the specified class is an array class, the `IsArrayClass` method returns an S_OK HRESULT and values for any non-null output parameters. Otherwise, it returns S_FALSE.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
