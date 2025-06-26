---
description: "Learn more about: GetCORRequiredVersion Function"
title: "GetCORRequiredVersion Function"
ms.date: "03/30/2017"
api_name: 
  - "GetCORRequiredVersion"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "GetCORRequiredVersion"
helpviewer_keywords: 
  - "GetCORRequiredVersion function [.NET Framework hosting]"
ms.assetid: 1588fe7b-c378-4f4b-9c4b-48647f1119cc
topic_type: 
  - "apiref"
---
# GetCORRequiredVersion Function

Gets the required common language runtime (CLR) version number.  
  
 This function has been deprecated in the .NET Framework 4.  
  
## Syntax  
  
```cpp  
HRESULT GetCORRequiredVersion (  
    [out] LPWSTR   pbuffer,  
    [in]  DWORD    cchBuffer,  
    [out] DWORD   *dwLength  
);  
```  
  
## Parameters  

 `pbuffer`  
 [out] A buffer containing a string that specifies the version number.  
  
 `cchBuffer`  
 [in] The size, in bytes, of the buffer.  
  
 `dwLength`  
 [out] The number of bytes returned in the buffer.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md)
