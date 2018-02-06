---
title: "ICLRRuntimeInfo::GetVersionString Method"
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
  - "ICLRRuntimeInfo.GetVersionString"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRRuntimeInfo::GetVersionString"
helpviewer_keywords: 
  - "ICLRRuntimeInfo::GetVersionString method [.NET Framework hosting]"
  - "GetVersionString method, ICLRRuntimeInfo interface [.NET Framework hosting]"
ms.assetid: 98b097ef-2276-4dd9-8551-b03c972e8179
topic_type: 
  - "apiref"
caps.latest.revision: 16
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRRuntimeInfo::GetVersionString Method
Gets common language runtime (CLR) version information associated with a given [ICLRRuntimeInfo](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-interface.md) interface.  
  
 This method supersedes the following functions:  
  
-   [GetRequestedRuntimeInfo](../../../../docs/framework/unmanaged-api/hosting/getrequestedruntimeinfo-function.md)  
  
-   [GetRequestedRuntimeVersion](../../../../docs/framework/unmanaged-api/hosting/getrequestedruntimeversion-function.md)  
  
## Syntax  
  
```  
HRESULT GetVersionString(  
    [out, size_is(*pcchBuffer)] LPWSTR pwzBuffer,  
    [in, out]  DWORD *pcchBuffer);  
```  
  
#### Parameters  
 `pwzBuffer`  
 [out] The .NET Framework compilation version in the format "v*A*.*B*[.*X*]". *A*, *B*, and *X* are decimal numbers that correspond to the major version, the minor version, and the build number. *X* is optional. If *X* is not present, there is no trailing period.  
  
> [!NOTE]
>  This parameter must match the directory name for the .NET Framework version, as it appears under C:\Windows\Microsoft.NET\Framework.  
  
 Example values are "v1.0.3705", "v1.1.4322", "v2.0.50727", and "v4.0.*x*", where *x* depends on the build number installed. Note that the "v" prefix is mandatory.  
  
 `pchBuffer`  
 [in, out] Specifies the size of `pwzBuffer` to avoid buffer overruns. If `pwzBuffer` is `null`, `pchBuffer` returns the required size of `pwzBuffer` to allow preallocation.  
  
## Return Value  
 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully.|  
|E_POINTER|`pwzBuffer` or `pchBuffer` is null.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICLRRuntimeInfo Interface](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-interface.md)  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)  
 [CLR Hosting Interfaces Added in the .NET Framework 4 and 4.5](../../../../docs/framework/unmanaged-api/hosting/clr-hosting-interfaces-added-in-the-net-framework-4-and-4-5.md)  
 [Hosting](../../../../docs/framework/unmanaged-api/hosting/index.md)
