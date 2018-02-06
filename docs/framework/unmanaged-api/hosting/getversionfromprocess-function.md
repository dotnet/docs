---
title: "GetVersionFromProcess Function"
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
  - "GetVersionFromProcess"
api_location: 
  - "mscoree.dll"
  - "mscoreei.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "GetVersionFromProcess"
helpviewer_keywords: 
  - "GetVersionFromProcess function [.NET Framework hosting]"
ms.assetid: a9f7f824-64a1-408d-8607-91c7f19d21fe
topic_type: 
  - "apiref"
caps.latest.revision: 20
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# GetVersionFromProcess Function
Gets the version number of the common language runtime (CLR) that is associated with the specified process handle.  
  
 This function has been deprecated in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)].  
  
## Syntax  
  
```  
HRESULT GetVersionFromProcess (  
    [in]  HANDLE  hProcess,   
    [out] LPWSTR  pVersion,   
    [in]  DWORD   cchBuffer,   
    [out] DWORD  *dwLength  
);  
```  
  
#### Parameters  
 `hProcess`  
 [in] A handle to a process.  
  
 `pVersion`  
 [out] A buffer that contains the version number string upon successful completion of the method.  
  
 `cchBuffer`  
 [in] The length of the version buffer.  
  
 `pdwLength`  
 [out] A pointer to the length of the version number string.  
  
## Return Value  
 This method returns standard Component Object Model (COM) error codes, as defined in WinError.h, in addition to the following values.  
  
|Return code|Description|  
|-----------------|-----------------|  
|S_OK|The method completed successfully.|  
|E_INVALIDARG|`pVersion` is null and `cchBuffer` is not null, or vice versa.<br /><br /> -or-<br /><br /> `hProcess` is not a valid handle to a process.<br /><br /> -or-<br /><br /> The CLR is not loaded.|  
|ERROR_INSUFFICIENT_BUFFER|`cchBuffer` is null or less than the length of the version string.|  
|E_NOTIMPL|This method is not available on the Microsoft Windows 95, Microsoft Windows 98, or Microsoft Windows Millennium Edition operating system.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [GetRequestedRuntimeInfo Function](../../../../docs/framework/unmanaged-api/hosting/getrequestedruntimeinfo-function.md)  
 [GetRequestedRuntimeVersion Function](../../../../docs/framework/unmanaged-api/hosting/getrequestedruntimeversion-function.md)  
 [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)
