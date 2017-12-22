---
title: "ICLRMetaHost::GetVersionFromFile Method"
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
  - "ICLRMetaHost.GetVersionFromFile"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRMetaHost::GetVersionFromFile"
helpviewer_keywords: 
  - "ICLRMetaHost::GetVersionFromFile method [.NET Framework hosting]"
  - "GetVersionFromFile method [.NET Framework hosting]"
ms.assetid: 55bb3eb4-f665-42fc-973c-465567570e82
topic_type: 
  - "apiref"
caps.latest.revision: 20
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRMetaHost::GetVersionFromFile Method
Gets an assembly's original .NET Framework compilation version (stored in the metadata), given its file path. This method supersedes the [GetFileVersion](../../../../docs/framework/unmanaged-api/hosting/getfileversion-function.md) function.  
  
## Syntax  
  
```  
HRESULT GetVersionFromFile (  
    [in] LPCWSTR pwzFilePath,  
    [out, size_is(*pcchBuffer)] LPWSTR pwzBuffer,  
    [in, out] DWORD *pcchBuffer);  
);  
```  
  
#### Parameters  
 `pwzFilePath`  
 [in] The complete assembly file path.  
  
 `pwzbuffer`  
 [out] The .NET Framework compilation version stored in the metadata, in the format "v*A*.*B*[.*X*]". *A*, *B*, and *X* are decimal numbers that correspond to the major version, the minor version, and the build number. The length of this string is limited to MAX_PATH.  
  
> [!NOTE]
>  This output matches the directory name for the .NET Framework version, as it appears under C:\Windows\Microsoft.NET\Framework.  
  
 Example values are "v1.0.3705", "v1.1.4322", "v2.0.50727", and "v4.0.*X*", where *X* depends on the build number installed. Note that the "v" prefix is required.  
  
 `pcchBuffer`  
 [in, out] The size of `pwzbuffer` to avoid buffer overruns.  
  
## Return Value  
 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully.|  
|E_POINTER|`pwzbuffer` or `pcchBuffer` is null.|  
|HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER)|The buffer is too small.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICLRMetaHost Interface](../../../../docs/framework/unmanaged-api/hosting/iclrmetahost-interface.md)  
 [Hosting](../../../../docs/framework/unmanaged-api/hosting/index.md)
