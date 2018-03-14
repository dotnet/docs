---
title: "GetRequestedRuntimeVersion Function"
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
  - "GetRequestedRuntimeVersion"
api_location: 
  - "mscoree.dll"
  - "mscoreei.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "GetRequestedRuntimeVersion"
helpviewer_keywords: 
  - "GetRequestedRuntimeVersion function [.NET Framework hosting]"
ms.assetid: 82f596a4-483d-4509-b0c5-a84c53c3da1b
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# GetRequestedRuntimeVersion Function
Gets the version number of the common language runtime (CLR) requested by the specified application. If that version is not installed, gets the most recent version that is installed before the requested version.  
  
 This function has been deprecated in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)].  
  
## Syntax  
  
```  
HRESULT GetRequestedRuntimeVersion (  
    [in]  LPWSTR  pExe,   
    [out] LPWSTR  pVersion,   
    [in]  DWORD   cchBuffer,   
    [out] DWORD  *pdwLength  
);  
```  
  
#### Parameters  
 `pExe`  
 [in] The name of the application.  
  
 `pVersion`  
 [out] A buffer that contains the version number string upon successful completion.  
  
 `cchBuffer`  
 [in] The length of the version buffer.  
  
 `pdwLength`  
 [out] A pointer to the length of the version number string.  
  
## Return Value  
 This method returns standard Component Object Model (COM) error codes, as defined in WinError.h, in addition to the following values.  
  
|Return code|Description|  
|-----------------|-----------------|  
|S_OK|The method completed successfully.|  
|ERROR_INSUFFICIENT_BUFFER|The version buffer is not large enough to store the version string.|  
|E_POINTER|`pdwLength` is null.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v11plus](../../../../includes/net-current-v11plus-md.md)]  
  
## See Also  
 [GetRequestedRuntimeInfo Function](../../../../docs/framework/unmanaged-api/hosting/getrequestedruntimeinfo-function.md)  
 [GetVersionFromProcess Function](../../../../docs/framework/unmanaged-api/hosting/getversionfromprocess-function.md)  
 [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)
