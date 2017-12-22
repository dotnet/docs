---
title: "ICorProfilerInfo::GetObjectSize Method"
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
  - "ICorProfilerInfo.GetObjectSize"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::GetObjectSize"
helpviewer_keywords: 
  - "GetObjectSize method [.NET Framework profiling]"
  - "ICorProfilerInfo::GetObjectSize method [.NET Framework profiling]"
ms.assetid: 9f02e763-73f7-42cb-a41c-f78499d9482c
topic_type: 
  - "apiref"
caps.latest.revision: 16
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo::GetObjectSize Method
Gets the size of a specified object.  
  
## Syntax  
  
```  
HRESULT GetObjectSize(  
    [in]  ObjectID objectId,  
    [out] ULONG  *pcSize);  
```  
  
#### Parameters  
 `objectId`  
 [in] The ID of the object.  
  
 `pcSize`  
 [out] A pointer to the object's size, in bytes.  
  
## Remarks  
  
> [!IMPORTANT]
>  This method is obsolete. It returns COR_E_OVERFLOW for objects greater than 4GB on 64-bit platforms. Use the  [ICorProfilerInfo4::GetObjectSize2](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo4-getobjectsize2-method.md) method instead.  
  
 Different objects of the same types often have the same size. However, some types, such as arrays or strings, may have a different size for each object.  
  
 The size returned by the `GetObjectSize` method does not include any alignment padding that may appear after the object is on the garbage collection heap. If you use the `GetObjectSize` method to advance from object to object on the garbage collection heap, add alignment padding manually, as necessary.  
  
-   On 32-bit Windows, COR_PRF_GC_GEN_0, COR_PRF_GC_GEN_1, and COR_PRF_GC_GEN_2 use 4-byte alignment, and COR_PRF_GC_LARGE_OBJECT_HEAP uses 8-byte alignment.  
  
-   On 64-bit Windows, the alignment is always 8 bytes.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)
