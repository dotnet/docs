---
title: "GetRequestedRuntimeVersionForCLSID Function"
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
  - "GetRequestedRuntimeVersionForCLSID"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "GetRequestedRuntimeVersionForCLSID"
helpviewer_keywords: 
  - "GetRequestedRuntimeVersionForCLSID function [.NET Framework hosting]"
ms.assetid: 5bb12f9a-0612-434b-b4ed-2db636a20bec
topic_type: 
  - "apiref"
caps.latest.revision: 17
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# GetRequestedRuntimeVersionForCLSID Function
Gets the appropriate common language runtime (CLR) version information for the class with the specified `CLSID`.  
  
 This function has been deprecated in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)].  
  
## Syntax  
  
```  
HRESULT GetRequestedRuntimeVersionForCLSID (  
    [in]  REFCLSID   rclsid,   
    [out]  LPWSTR     pVersion,   
    [in]  DWORD      cchBuffer,   
    [out] DWORD*     dwLength,   
    [in]  CLSID_RESOLUTION_FLAGS dwResolutionFlags  
);  
```  
  
#### Parameters  
 `rclsid`  
 [in]  The `CLSID` of the component.  
  
 `pVersion`  
 [out]  A buffer that contains the version number string upon successful completion.  
  
 `cchBuffer`  
 [in]  The size, in wide characters, of the `pVersion` buffer.  
  
 `dwLength`  
 [out] The length, in bytes, of the returned buffer.  
  
 `dwResolutionFlags`  
 [in]  One of the CLSID_RESOLUTION_FLAGS values. The following values are supported:  
  
-   CLSID_RESOLUTION_DEFAULT: (0x0) Specifies that default interop behavior should be used.  
  
-   CLSID_RESOLUTION_REGISTERED: (0x1) Specifies that the registry should be searched and shim policy should be applied.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The function returned successfully.|  
|E_INVALIDARG|One of the parameters has an invalid type or format.|  
|ERROR_INSUFFICIENT_BUFFER|The `pVersion` buffer is not large enough to hold the entire version string.|  
|REGDB_E_CLASSNOTREG|There is no class registered with the specified `CLSID`.|  
|E_POINTER|`dwLength` is null, or `cchBuffer` is large enough to hold the version string, but `pVersion` is null.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v11plus](../../../../includes/net-current-v11plus-md.md)]  
  
## See Also  
 [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)
