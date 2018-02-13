---
title: "ICorProfilerInfo::GetAppDomainInfo Method"
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
  - "ICorProfilerInfo.GetAppDomainInfo"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::GetAppDomainInfo"
helpviewer_keywords: 
  - "ICorProfilerInfo::GetAppDomainInfo method [.NET Framework profiling]"
  - "GetAppDomainInfo method [.NET Framework profiling]"
ms.assetid: a6bf5a04-e03e-44f0-917a-96f6a6d3cc96
topic_type: 
  - "apiref"
caps.latest.revision: 23
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo::GetAppDomainInfo Method
Accepts an application domain ID. Returns an application domain name and the ID of the process that contains it.  
  
## Syntax  
  
```  
HRESULT GetAppDomainInfo(  
    [in]  AppDomainID appDomainId,  
    [in]  ULONG       cchName,  
    [out] ULONG       *pcchName,  
    [out, size_is(cchName), length_is(*pcchName)]  
          WCHAR       szName[] ,  
    [out] ProcessID   *pProcessId);  
```  
  
#### Parameters  
 `appDomainId`  
 [in] The ID of the application domain.  
  
 `cchName`  
 [in] The length, in characters, of the `szName` return buffer.  
  
 `pcchName`  
 [out] A pointer to the total character length of the application domain name.  
  
 `szName`  
 [out] A caller-provided wide character buffer. When the method returns, `szName` will contain the full or partial application domain name.  
  
 `pProcessId`  
 [out] A pointer to the ID of the process that contains the application domain.  
  
## Remarks  
 After this method returns, you must verify that the `szName` buffer was large enough to contain the full name of the application domain. To do this, compare the value that `pcchName` points to with the value of the `cchName` parameter. If `pcchName` points to a value that is larger than `cchName`, allocate a larger `szName` buffer, update `cchName` with the new, larger size, and call `GetAppDomainInfo` again.  
  
 Alternatively, you can first call `GetAppDomainInfo` with a zero-length `szName` buffer to obtain the correct buffer size. You can then set the buffer size to the value returned in `pcchName` and call `GetAppDomainInfo` again.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)  
 [Profiling](../../../../docs/framework/unmanaged-api/profiling/index.md)
