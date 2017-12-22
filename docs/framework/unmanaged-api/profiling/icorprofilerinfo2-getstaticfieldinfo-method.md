---
title: "ICorProfilerInfo2::GetStaticFieldInfo Method"
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
  - "ICorProfilerInfo2.GetStaticFieldInfo"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo2::GetStaticFieldInfo"
helpviewer_keywords: 
  - "ICorProfilerInfo2::GetStaticFieldInfo method [.NET Framework profiling]"
  - "GetStaticFieldInfo method [.NET Framework profiling]"
ms.assetid: fc663e76-e23f-49a8-bdd5-52cdf1a3b2b3
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo2::GetStaticFieldInfo Method
Gets a value that indicates the kind of static that applies to the specified field.  
  
## Syntax  
  
```  
HRESULT GetStaticFieldInfo (  
    [in] ClassID               classId,  
    [in] mdFieldDef            fieldToken,  
    [out] COR_PRF_STATIC_TYPE  *pFieldInfo);  
```  
  
#### Parameters  
 `classId`  
 [in] The ID of the class in which the static field is defined.  
  
 `fieldToken`  
 [in] The metadata token for the static field.  
  
 `pFieldInfo`  
 [out] A pointer to a value of the [COR_PRF_STATIC_TYPE](../../../../docs/framework/unmanaged-api/profiling/cor-prf-static-type-enumeration.md) enumeration that indicates whether the specified field is static, and if so, the kind of static that applies to the field.  
  
## Remarks  
 This information can be used to determine which function to call to get the address of the static field.  
  
 The profiler code should still check the metadata for a static field to ensure that it actually has an address. Static literals (that is, constants) exist only in the metadata and do not have an address.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)  
 [ICorProfilerInfo2 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-interface.md)
