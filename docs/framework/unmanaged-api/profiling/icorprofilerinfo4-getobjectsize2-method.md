---
title: "ICorProfilerInfo4::GetObjectSize2 Method"
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
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo4::GetObjectSize2 Method
Returns the size of a specified object. Replaces the [ICorProfilerInfo::GetObjectSize](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-getobjectsize-method.md) method by reporting sizes of objects that are larger than what can be expressed in a `ULONG`.  
  
## Syntax  
  
```  
HRESULT GetObjectSize2(  
    [in]  ObjectID objectId,  
    [out] SIZE_T *pcSize);  
```  
  
#### Parameters  
 `objectId`  
 [in] The ID of the object.  
  
 `pcSize`  
 [out] A pointer to the object's size, in bytes.  
  
## Remarks  
 Different objects of the same types often have the same size. However, some types, such as arrays or strings, may have a different size for each object.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo4 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo4-interface.md)
