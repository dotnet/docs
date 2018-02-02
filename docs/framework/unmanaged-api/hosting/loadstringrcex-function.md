---
title: "LoadStringRCEx Function"
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
  - "LoadStringRCEx"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "LoadStringRCEx"
helpviewer_keywords: 
  - "LoadStringRCEx function [.NET Framework hosting]"
ms.assetid: bc789636-ca14-4f07-8f77-9305874d7495
topic_type: 
  - "apiref"
caps.latest.revision: 18
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# LoadStringRCEx Function
Translates an HRESULT value to an appropriate error message for the specified culture.  
  
 This function has been deprecated in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)].  
  
## Syntax  
  
```  
HRESULT LoadStringRCEx (  
    [in]  LCID    lcid,   
    [in]  UINT    iResouceID,   
    [out] LPWSTR  szBuffer,   
    [in]  int     iMax,   
    [in]  int     bQuiet,   
    [out] int    *pcwchUsed  
);  
```  
  
#### Parameters  
 `lcid`  
 [in] A culture identifier. Pass -1 for `lcid` to use the default culture.  
  
 `iResourceID`  
 [in] An HRESULT.  
  
 `szBuffer`  
 [out] A buffer that contains the error message upon successful completion.  
  
 `iMax`  
 [in] The size of the error message buffer.  
  
 `bQuiet`  
 [in] Ignored.  
  
 `pcwchUsed`  
 [out] A pointer to the length of the error message.  
  
## Return Value  
 This method returns standard COM error codes, as defined in WinError.h, in addition to the following values.  
  
|Return code|Description|  
|-----------------|-----------------|  
|S_OK|The method completed successfully.|  
|E_INVALIDARG|`szBuffer` is null, or `iMax` is zero (0).|  
  
## Remarks  
 If the method does not complete successfully, `szBuffer` contains an empty string.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 <xref:System.Globalization.CultureInfo.LCID%2A?displayProperty=nameWithType>  
 [LoadStringRC Function](../../../../docs/framework/unmanaged-api/hosting/loadstringrc-function.md)  
 [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)
