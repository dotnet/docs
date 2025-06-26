---
description: "Learn more about: ICLRRuntimeInfo::GetRuntimeDirectory Method"
title: "ICLRRuntimeInfo::GetRuntimeDirectory Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRRuntimeInfo.GetRuntimeDirectory"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRRuntimeInfo::GetRuntimeDirectory"
helpviewer_keywords: 
  - "GetRuntimeDirectory method [.NET Framework hosting]"
  - "ICLRRuntimeInfo::GetRuntimeDirectory method [.NET Framework hosting]"
ms.assetid: 4401546e-4d48-453f-a1fb-b2ebda54df5c
topic_type: 
  - "apiref"
---
# ICLRRuntimeInfo::GetRuntimeDirectory Method

Gets the installation directory of the common language runtime (CLR) associated with this interface.  
  
 This method supersedes the [GetCORSystemDirectory](getcorsystemdirectory-function.md) function provided in the .NET Framework versions 2.0, 3.0, and 3.5.  
  
## Syntax  
  
```cpp  
HRESULT GetRuntimeDirectory(  
[out, size_is(*pcchBuffer)] LPWSTR pwzBuffer,  
[in, out]  DWORD *pcchBuffer);  
```  
  
## Parameters  

 `pwzBuffer`  
 [out] Returns the CLR installation directory. The installation path is fully qualified; for example, "c:\windows\microsoft.net\framework\v1.0.3705\\".  
  
 `pchBuffer`  
 [in, out] Specifies the size of `pwzBuffer` to avoid buffer overruns. If `pwzBuffer` is null, `pchBuffer` returns the required size of `pwzBuffer`.  
  
## Return Value  

 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully.|  
|E_POINTER|`pwzBuffer` or `pchBuffer` is null.|  
  
## Remarks  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICLRRuntimeInfo Interface](iclrruntimeinfo-interface.md)
- [Hosting](index.md)
