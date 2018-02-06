---
title: "ICLRMetaHost::EnumerateInstalledRuntimes Method"
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
  - "ICLRMetaHost.EnumerateInstalledRuntimes"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRMetaHost::EnumerateInstalledRuntimes"
helpviewer_keywords: 
  - "ICLRMetaHost::EnumerateInstalledRuntimes method [.NET Framework hosting]"
  - "EnumerateInstalledRuntimes method [.NET Framework hosting]"
ms.assetid: 9e359384-0d3d-451c-807e-5d7fcebf2be7
topic_type: 
  - "apiref"
caps.latest.revision: 18
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRMetaHost::EnumerateInstalledRuntimes Method
Returns an enumeration that contains a valid [ICLRRuntimeInfo](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-interface.md) interface for each version of the common language runtime (CLR) that is installed on a computer.  
  
## Syntax  
  
```  
HRESULT EnumerateInstalledRuntimes (  
    [out, retval] IEnumUnknown **ppEnumerator);  
```  
  
#### Parameters  
 `ppEnumerator`  
 [out] An enumeration of [ICLRRuntimeInfo](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-interface.md) interfaces corresponding to each version of the CLR that is installed on the computer.  
  
## Return Value  
 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully.|  
|E_POINTER|`ppEnumerator` is null.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICLRMetaHost Interface](../../../../docs/framework/unmanaged-api/hosting/iclrmetahost-interface.md)  
 [Hosting](../../../../docs/framework/unmanaged-api/hosting/index.md)
