---
title: "ICorProfilerInfo3::GetAppDomainsContainingModule Method"
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
  - "ICorProfilerInfo3.GetAppDomainsContainingModule Method"
api_location: 
  - "Mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo3::GetAppDomainsContainingModule"
helpviewer_keywords: 
  - "GetAppDomainsContainingModule method [.NET Framework profiling]"
  - "ICorProfilerInfo3::GetAppDomainsContainingModule method [.NET Framework profiling]"
ms.assetid: 603b3881-ea94-4dca-95cd-91eebac873a0
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo3::GetAppDomainsContainingModule Method
Gets the identifiers of the application domains in which the given module has been loaded.  
  
## Syntax  
  
```  
HRESULT GetAppDomainsContainingModule(  
            [in] ModuleID moduleId,  
            [in] ULONG32 cAppDomainIds,  
            [out] ULONG32 *pcAppDomainIds,  
            [out, size_is(cAppDomainIds), length_is(*pcAppDomainIds)]  
                    AppDomainID appDomainIds[]);  
```  
  
#### Parameters  
 `moduleId`  
 [in] The ID of the loaded module.  
  
 `cAppDomainIds`  
 [in] The size of the `appDomainIds` array.  
  
 `pcAppDomainIds`  
 [out] A pointer to the total number of returned elements.  
  
 `appDomainIds`  
 [out] An array of application domain ID values.  
  
## Remarks  
 The method uses caller allocated buffers.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICorProfilerFunctionEnum Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerfunctionenum-interface.md)  
 [ICorProfilerInfo3 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-interface.md)  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)  
 [Profiling](../../../../docs/framework/unmanaged-api/profiling/index.md)
