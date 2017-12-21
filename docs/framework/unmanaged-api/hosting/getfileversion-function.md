---
title: "GetFileVersion Function"
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
  - "GetFileVersion"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "GetFileVersion"
helpviewer_keywords: 
  - "GetFileVersion function [.NET Framework hosting]"
ms.assetid: b3222c85-da88-4485-97d7-3a6ee3e8d358
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# GetFileVersion Function
Gets the common language runtime (CLR) version information of the specified file, using the specified buffer.  
  
 This function has been deprecated in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)].  
  
## Syntax  
  
```  
HRESULT GetFileVersion (  
    [in]  LPCWSTR      szFilename,   
    [in, out] LPWSTR   szBuffer,   
    [in]  DWORD        cchBuffer,   
    [out] DWORD        *dwLength  
);  
```  
  
#### Parameters  
 `szFilename`  
 [in] The path of the file to be examined.  
  
 `szBuffer`  
 [in, out] The buffer allocated for the version information that is returned.  
  
 `cchBuffer`  
 [in] The size, in wide characters, of `szBuffer`.  
  
 `dwLength`  
 [out] The size, in bytes, of the returned `szBuffer`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v11plus](../../../../includes/net-current-v11plus-md.md)]  
  
## See Also  
 [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)
