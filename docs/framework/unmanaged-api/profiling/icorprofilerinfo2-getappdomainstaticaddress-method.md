---
title: "ICorProfilerInfo2::GetAppDomainStaticAddress Method"
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
  - "ICorProfilerInfo2.GetAppDomainStaticAddress"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo2::GetAppDomainStaticAddress"
helpviewer_keywords: 
  - "ICorProfilerInfo2::GetAppDomainStaticAddress method [.NET Framework profiling]"
  - "GetAppDomainStaticAddress method [.NET Framework profiling]"
ms.assetid: 2a9e0ea7-a9e2-4817-b1c4-fcf15b215ea9
topic_type: 
  - "apiref"
caps.latest.revision: 22
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo2::GetAppDomainStaticAddress Method
Gets the address of the specified application domain-static field that is in the scope of the specified application domain.  
  
## Syntax  
  
```  
RESULT GetAppDomainStaticAddress(  
    [in] ClassID classId,  
    [in] mdFieldDef fieldToken,  
    [in] AppDomainID appDomainId,  
    [out] void **ppAddress);  
```  
  
#### Parameters  
 `classId`  
 [in] The class ID of the class that contains the requested application domain-static field.  
  
 `fieldToken`  
 [in] The metadata token for the requested application domain-static field.  
  
 `appDomainId`  
 [in] The ID of the application domain that is the scope for the requested static field.  
  
 `ppAddress`  
 [out] A pointer to the address of the static field that is within the specified application domain.  
  
## Remarks  
 The `GetAppDomainStaticAddress` method may return one of the following:  
  
-   A CORPROF_E_DATAINCOMPLETE HRESULT if the given static field has not been assigned an address in the specified context.  
  
-   The addresses of objects that may be in the garbage collection heap. These addresses may become invalid after garbage collection, so after garbage collection, profilers should not assume that they are valid.  
  
 Before a class’s class constructor is completed, `GetAppDomainStaticAddress` will return CORPROF_E_DATAINCOMPLETE for all its static fields, although some of the static fields may already be initialized and rooting garbage collection objects.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)  
 [ICorProfilerInfo2 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-interface.md)
