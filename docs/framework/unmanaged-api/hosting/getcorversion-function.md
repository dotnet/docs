---
description: "Learn more about: GetCORVersion Function"
title: "GetCORVersion Function"
ms.date: "03/30/2017"
api_name: 
  - "GetCORVersion"
api_location: 
  - "mscoree.dll"
  - "mscoreei.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "GetCORVersion"
helpviewer_keywords: 
  - "GetCORVersion function [.NET Framework hosting]"
ms.assetid: 2f09cd37-bf3a-4cc5-87b0-adc42a7eed31
topic_type: 
  - "apiref"
---
# GetCORVersion Function

Returns the version number of the common language runtime (CLR) that is running in the current process.  
  
 This function has been deprecated in the .NET Framework 4.  
  
## Syntax  
  
```cpp  
HRESULT GetCORVersion (  
    [in] LPWSTR  pbuffer,  
    [in]  DWORD   cchBuffer,
    [out] DWORD*  dwlength  
);
```  
  
## Parameters  

 `pbuffer`  
 A pointer to a buffer in which the CLR returns a string specifying the version of the runtime that is currently loaded into the process. The returned string takes the same form as strings passed to [CorBindToRuntimeEx](corbindtoruntimeex-function.md), for example, "v1.0.1216". If the runtime has not yet been loaded into the process, the function returns the appropriate directory information for the latest version of the runtime installed on the computer.  
  
 `cchBuffer`  
 The number of characters (`WCHAR`s) that can be held in `pbuffer`.  
  
 `dwLength`  
 A pointer to the number of characters actually returned in `pbuffer`. If `pbuffer` is a null pointer, the runtime returns E_POINTER. If the number of characters is greater then the length of `pbuffer` , the runtime returns ERROR_INSUFFICIENT_BUFFER.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md)
