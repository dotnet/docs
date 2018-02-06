---
title: "LoadStringRC Function"
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
  - "LoadStringRC"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "LoadStringRC"
helpviewer_keywords: 
  - "LoadStringRC function [.NET Framework hosting]"
ms.assetid: 752e49b4-987c-4c28-a118-1a0c1ed510c5
topic_type: 
  - "apiref"
caps.latest.revision: 16
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# LoadStringRC Function
Translates an HRESULT value into an error message by using the default culture of the current thread.  
  
 This function has been deprecated in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)].  
  
## Syntax  
  
```  
HRESULT LoadStringRC (  
    [in]  UINT    iResourceID,   
    [out] LPWSTR  szBuffer,   
    [in]  int     iMax,   
    [in]  int     bQuiet  
);  
```  
  
#### Parameters  
 `iResourceID`  
 [in] An HRESULT.  
  
 `szBuffer`  
 [out] A buffer that contains the error message upon successful completion.  
  
 `iMax`  
 [in] The size of the error message buffer.  
  
 `bQuiet`  
 [in] Ignored.  
  
## Return Value  
 This method returns standard Component Object Model (COM) error codes, as defined in WinError.h, in addition to the following values.  
  
|Return code|Description|  
|-----------------|-----------------|  
|S_OK|The method completed successfully.|  
|E_INVALIDARG|`szBuffer` is null or `iMax` is zero (0).|  
  
## Remarks  
 If the method does not complete successfully, `szBuffer` contains an empty string.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll and Mscorwks.dll. Use MSCorEE.dll instead of Mscorwks.dll to ensure that you target the correct version of the .NET Framework.  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [LoadStringRCEx Function](../../../../docs/framework/unmanaged-api/hosting/loadstringrcex-function.md)  
 [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)
