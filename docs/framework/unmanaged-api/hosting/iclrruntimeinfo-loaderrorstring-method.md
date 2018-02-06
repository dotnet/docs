---
title: "ICLRRuntimeInfo::LoadErrorString Method"
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
  - "ICLRRuntimeInfo.LoadErrorString"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRRuntimeInfo::LoadErrorString"
helpviewer_keywords: 
  - "ICLRRuntimeInfo::LoadErrorString method [.NET Framework hosting]"
  - "LoadErrorString method [.NET Framework hosting]"
ms.assetid: 52c543ab-9ef5-4ee7-b836-c0ffc35cd45b
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRRuntimeInfo::LoadErrorString Method
Translates an HRESULT value into an appropriate error message for the specified culture.  
  
 This method supersedes the following functions:  
  
-   [LoadStringRC](../../../../docs/framework/unmanaged-api/hosting/loadstringrc-function.md)  
  
-   [LoadStringRCEx](../../../../docs/framework/unmanaged-api/hosting/loadstringrcex-function.md)  
  
## Syntax  
  
```  
HRESULT LoadErrorString(  
     [in] UINT iResourceID,  
     [out, size_is(*pcchBuffer)] LPWSTR pwzBuffer,  
     [in, out]  DWORD *pcchBuffer,  
     [in, lcid] LONG iLocaleID);  
```  
  
#### Parameters  
 `iResourceID`  
 [in] The HRESULT to translate.  
  
 `pwzBuffer`  
 [out] The message string associated with the given HRESULT.  
  
 `pcchBuffer`  
 [in, out] The size of `pwzbuffer` to avoid buffer overruns. If `pwzbuffer` is null, `pcchBuffer` provides the expected size of `pwzbuffer` to allow preallocation.  
  
 `iLocaleID`  
 [in] The culture identifier. To use the default culture, you must specify -1.  
  
## Return Value  
 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully.|  
|E_POINTER|`pcchBuffer` is null.|  
|E_INVALIDARG|`pwzBuffer` is null.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICLRRuntimeInfo Interface](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-interface.md)  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)  
 [Hosting](../../../../docs/framework/unmanaged-api/hosting/index.md)
