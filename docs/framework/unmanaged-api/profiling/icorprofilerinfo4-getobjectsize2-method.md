---
description: "Learn more about: ICorProfilerInfo4::GetObjectSize2 Method"
title: "ICorProfilerInfo4::GetObjectSize2 Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo4.GetObjectSize2"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo4::GetObjectSize2"
helpviewer_keywords: 
  - "GetObjectSize2 method, ICorProfilerInfo4 interface [.NET Framework profiling]"
  - "ICorProfilerInfo4::GetObjectSize2 method [.NET Framework profiling]"
ms.assetid: 4a3e43ed-3ee3-4395-ab14-f78b903be13e
topic_type: 
  - "apiref"
---
# ICorProfilerInfo4::GetObjectSize2 Method

Returns the size of a specified object. Replaces the [ICorProfilerInfo::GetObjectSize](icorprofilerinfo-getobjectsize-method.md) method by reporting sizes of objects that are larger than what can be expressed in a `ULONG`.  
  
## Syntax  
  
```cpp  
HRESULT GetObjectSize2(  
    [in]  ObjectID objectId,  
    [out] SIZE_T *pcSize);  
```  
  
## Parameters  

 `objectId`  
 [in] The ID of the object.  
  
 `pcSize`  
 [out] A pointer to the object's size, in bytes.  
  
## Remarks  

 Different objects of the same types often have the same size. However, some types, such as arrays or strings, may have a different size for each object.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [ICorProfilerInfo4 Interface](icorprofilerinfo4-interface.md)
