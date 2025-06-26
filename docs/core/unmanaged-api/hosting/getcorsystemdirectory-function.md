---
description: "Learn more about: GetCORSystemDirectory Function"
title: "GetCORSystemDirectory Function"
ms.date: "03/30/2017"
api_name: 
  - "GetCORSystemDirectory"
api_location: 
  - "mscoree.dll"
  - "mscoreei.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "GetCORSystemDirectory"
helpviewer_keywords: 
  - "GetCORSystemDirectory function [.NET Framework hosting]"
ms.assetid: 3dcd16a7-dafc-4ca8-b5cd-20ffb37db91d
topic_type: 
  - "apiref"
---
# GetCORSystemDirectory Function

Returns the installation directory of the common language runtime (CLR) that is loaded into the process. The installation directory is fully qualified, for example, "c:\windows\microsoft.net\framework\v1.0.3705".  
  
 This function is deprecated. It is superseded by the [ICLRRuntimeInfo::GetRuntimeDirectory](iclrruntimeinfo-getruntimedirectory-method.md) method provided in the .NET Framework 4.  
  
## Syntax  
  
```cpp  
HRESULT GetCORSystemDirectory (
    [out] LPWSTR  pbuffer,
    [in]  DWORD   cchBuffer,
    [out] DWORD*  dwlength  
);
```  
  
## Parameters  

 `pbuffer`  
 [out] A buffer in which the runtime returns a string that contains the fully qualified name of the installation directory for the runtime that is loaded into the process. If the runtime has not yet been loaded into the process, the function returns the appropriate directory information for the latest version of the runtime installed on the computer.  
  
 `cchBuffer`  
 [in] The size, in bytes, of `pbuffer`.  
  
 `dwLength`  
 [out] The number of characters returned in `pbuffer`.  
  
## Remarks  
  
> [!CAUTION]
> Do not use this function in processes that are running version 4 of the CLR. If an earlier version of the CLR is installed on the computer, this function returns the installation directory for that version.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md)
