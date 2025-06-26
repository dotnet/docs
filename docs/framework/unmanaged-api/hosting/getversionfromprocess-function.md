---
description: "Learn more about: GetVersionFromProcess Function"
title: "GetVersionFromProcess Function"
ms.date: "03/30/2017"
api_name: 
  - "GetVersionFromProcess"
api_location: 
  - "mscoree.dll"
  - "mscoreei.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "GetVersionFromProcess"
helpviewer_keywords: 
  - "GetVersionFromProcess function [.NET Framework hosting]"
ms.assetid: a9f7f824-64a1-408d-8607-91c7f19d21fe
topic_type: 
  - "apiref"
---
# GetVersionFromProcess Function

Gets the version number of the common language runtime (CLR) that is associated with the specified process handle.  
  
 This function has been deprecated in the .NET Framework 4.  
  
## Syntax  
  
```cpp  
HRESULT GetVersionFromProcess (  
    [in]  HANDLE  hProcess,
    [out] LPWSTR  pVersion,
    [in]  DWORD   cchBuffer,
    [out] DWORD  *dwLength  
);  
```  
  
## Parameters  

 `hProcess`  
 [in] A handle to a process.  
  
 `pVersion`  
 [out] A buffer that contains the version number string upon successful completion of the method.  
  
 `cchBuffer`  
 [in] The length of the version buffer.  
  
 `pdwLength`  
 [out] A pointer to the length of the version number string.  
  
## Return Value  

 This method returns standard Component Object Model (COM) error codes, as defined in WinError.h, in addition to the following values.  
  
|Return code|Description|  
|-----------------|-----------------|  
|S_OK|The method completed successfully.|  
|E_INVALIDARG|`pVersion` is null and `cchBuffer` is not null, or vice versa.<br /><br /> -or-<br /><br /> `hProcess` is not a valid handle to a process.<br /><br /> -or-<br /><br /> The CLR is not loaded.|  
|ERROR_INSUFFICIENT_BUFFER|`cchBuffer` is null or less than the length of the version string.|  
|E_NOTIMPL|This method is not available on the Microsoft Windows 95, Microsoft Windows 98, or Microsoft Windows Millennium Edition operating system.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [GetRequestedRuntimeInfo Function](getrequestedruntimeinfo-function.md)
- [GetRequestedRuntimeVersion Function](getrequestedruntimeversion-function.md)
- [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md)
