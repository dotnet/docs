---
description: "Learn more about: GetRealProcAddress Function"
title: "GetRealProcAddress Function"
ms.date: "03/30/2017"
api_name: 
  - "GetRealProcAddress"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "GetRealProcAddress"
helpviewer_keywords: 
  - "GetRealProcAddress function [.NET Framework hosting]"
ms.assetid: f1f2fab1-400b-488f-95f2-d49c4fca3556
topic_type: 
  - "apiref"
---
# GetRealProcAddress Function

Gets the address of the specified function that is exported from the latest installed version of the common language runtime (CLR).  
  
 This function has been deprecated in the .NET Framework 4.  
  
## Syntax  
  
```cpp  
HRESULT GetRealProcAddress (  
    [in]  LPCSTR  pwszProcName,
    [out] VOID  **ppv  
);  
```  
  
## Parameters  

 `pwszProcName`  
 [in] The name of the function.  
  
 `ppv`  
 [out] The location that receives a pointer to the address of the function.  
  
## Return Value  

 This method returns standard Component Object Model (COM) error codes, as defined in WinError.h, in addition to the following values defined in CorError.h.  
  
|Return code|Description|  
|-----------------|-----------------|  
|S_OK|The method completed successfully.|  
|E_POINTER|`ppv` is not valid.|  
|CLR_E_SHIM_RUNTIMEEXPORT|The function is not exported from the runtime.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md)
