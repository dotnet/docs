---
description: "Learn more about: ICorProfilerInfo2::GetArrayObjectInfo Method"
title: "ICorProfilerInfo2::GetArrayObjectInfo Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo2.GetArrayObjectInfo"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo2::GetArrayObjectInfo"
helpviewer_keywords: 
  - "ICorProfilerInfo2::GetArrayObjectInfo method [.NET Framework profiling]"
  - "GetArrayObjectInfo method [.NET Framework profiling]"
ms.assetid: bda75017-739f-4ce5-9000-f3b526e8473c
topic_type: 
  - "apiref"
---
# ICorProfilerInfo2::GetArrayObjectInfo Method

Gets detailed information about an array object.  
  
## Syntax  
  
```cpp  
HRESULT GetArrayObjectInfo(  
    [in] ObjectID objectId,  
    [in] ULONG32 cDimensions,  
    [out, size_is(cDimensions), length_is(cDimensions)] ULONG32 pDimensionSizes[],  
    [out, size_is(cDimensions), length_is(cDimensions)] int pDimensionLowerBounds[],  
    [out] BYTE **ppData);  
```  
  
## Parameters  

 `objectId`  
 [in] The ID of a valid array object.  
  
 `cDimensions`  
 [in] The rank (number of dimensions) of the array.  
  
 `pDimensionSizes`  
 [out] An array that contains integers, each representing the size of a dimension of the array.  
  
 `pDimensionLowerBounds`  
 [out] An array that contains integers, each representing the lower bound of a dimension of the array.  
  
 `ppData`  
 [out] A pointer to the address of the raw buffer for the array, which is laid out according to the C++ convention.  
  
## Remarks  

 The `pDimensionSizes` and `pDimensionLowerBounds` are parallel arrays, so the elements located at the same index in each array are characteristics of the same entity.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
- [ICorProfilerInfo2 Interface](icorprofilerinfo2-interface.md)
