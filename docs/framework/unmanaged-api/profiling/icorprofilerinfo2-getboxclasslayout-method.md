---
title: "ICorProfilerInfo2::GetBoxClassLayout Method"
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
  - "ICorProfilerInfo2.GetBoxClassLayout"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo2::GetBoxClassLayout"
helpviewer_keywords: 
  - "GetBoxClassLayout method [.NET Framework profiling]"
  - "ICorProfilerInfo2::GetBoxClassLayout method [.NET Framework profiling]"
ms.assetid: 624672b5-1189-488a-85d2-3e12b49617c1
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo2::GetBoxClassLayout Method
Gets information about where the specified value type is located when it is boxed.  
  
## Syntax  
  
```  
HRESULT GetBoxClassLayout(  
    [in] ClassID classId,  
    [out] ULONG32 *pBufferOffset);  
```  
  
#### Parameters  
 `classId`  
 [in] The ID of the class that describes the value type that is boxed.  
  
 `pBufferOffset`  
 [out] An integer that is the offset, relative to the boxed object ID pointer, of the value type.  
  
## Remarks  
 The `pBufferOffset` value is the location of the value type within a box. After `pBufferOffset` is applied to a boxed object, the value type's class layout can be used to interpret the object's value.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)  
 [ICorProfilerInfo2 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-interface.md)
