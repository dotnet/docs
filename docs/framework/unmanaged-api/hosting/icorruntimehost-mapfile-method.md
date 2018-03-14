---
title: "ICorRuntimeHost::MapFile Method"
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
  - "ICorRuntimeHost.MapFile"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorRuntimeHost::MapFile"
helpviewer_keywords: 
  - "ICorRuntimeHost::MapFile method [.NET Framework hosting]"
  - "MapFile method [.NET Framework hosting]"
ms.assetid: 45ae0502-0a31-4342-b7e3-f36e1cf738f3
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorRuntimeHost::MapFile Method
Maps the specified file into memory. This method is obsolete.  
  
## Syntax  
  
```  
HRESULT MapFile(  
    [in]  HANDLE    hFile,  
    [out] HMODULE*  hMapAddress  
);  
```  
  
#### Parameters  
 `hFile`  
 [in] The handle of the file to be mapped.  
  
 `hMapAddress`  
 [out] The starting memory address at which to begin mapping the file.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Version:** 1.0, 1.1  
  
## See Also  
 [ICorRuntimeHost Interface](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-interface.md)
