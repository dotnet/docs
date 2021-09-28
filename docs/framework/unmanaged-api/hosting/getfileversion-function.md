---
description: "Learn more about: GetFileVersion Function"
title: "GetFileVersion Function"
ms.date: "03/30/2017"
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
---
# GetFileVersion Function

Gets the common language runtime (CLR) version information of the specified file, using the specified buffer.  
  
 This function has been deprecated in the .NET Framework 4.  
  
## Syntax  
  
```cpp  
HRESULT GetFileVersion (  
    [in]  LPCWSTR      szFilename,
    [in, out] LPWSTR   szBuffer,
    [in]  DWORD        cchBuffer,
    [out] DWORD        *dwLength  
);  
```  
  
## Parameters  

 `szFilename`  
 [in] The path of the file to be examined.  
  
 `szBuffer`  
 [in, out] The buffer allocated for the version information that is returned.  
  
 `cchBuffer`  
 [in] The size, in wide characters, of `szBuffer`.  
  
 `dwLength`  
 [out] The size, in bytes, of the returned `szBuffer`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v11plus](../../../../includes/net-current-v11plus-md.md)]  
  
## See also

- [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md)
