---
title: "ICLRRuntimeInfo::GetDefaultStartupFlags Method"
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
  - "ICLRRuntimeInfo.GetDefaultStartupFlags"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRRuntimeInfo::GetDefaultStartupFlags"
helpviewer_keywords: 
  - "ICLRRuntimeInfo::GetDefaultStartupFlags method [.NET Framework hosting]"
  - "GetDefaultStartupFlags method [.NET Framework hosting]"
ms.assetid: 35c2173e-3b0b-4b2a-950d-e0a01c6df052
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRRuntimeInfo::GetDefaultStartupFlags Method
Gets the startup flags and host configuration file that will be used to start the runtime.  
  
## Syntax  
  
```  
HRESULT GetDefaultStartupFlags(  
     [out]  DWORD *pdwStartupFlags,  
     [out, size_is(*pcchHostConfigFile)] LPWSTR pwzHostConfigFile,  
     [in, out]  DWORD *pcchHostConfigFile);  
```  
  
#### Parameters  
 `pdwStartupFlags`  
 [out] A pointer to the host startup flags that are currently set.  
  
 `pwzHostConfigFile`  
 [out] A pointer to the directory path of the current host configuration file.  
  
 `pcchHostConfigFile`  
 [in, out] On input, the size of `pwzHostConfigFile`, to avoid buffer overruns. If `pwzHostConfigFile` is null, the method returns the required size of `pwzHostConfigFile` for pre-allocation.  
  
## Return Value  
 This method returns the following specific HRESULT as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully.|  
  
## Remarks  
 This method returns the default flag values (`STARTUP_CONCURRENT_GC` and `NULL`), or the values provided by a previous call to the [ICLRRuntimeInfo::SetDefaultStartupFlags method](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-setdefaultstartupflags-method.md), or the values set by any of the `CorBind*` methods if they are bound to this runtime.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICLRRuntimeInfo Interface](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-interface.md)  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)  
 [Hosting](../../../../docs/framework/unmanaged-api/hosting/index.md)
