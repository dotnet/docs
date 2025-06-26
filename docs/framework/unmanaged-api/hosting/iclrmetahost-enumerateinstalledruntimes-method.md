---
description: "Learn more about: ICLRMetaHost::EnumerateInstalledRuntimes Method"
title: "ICLRMetaHost::EnumerateInstalledRuntimes Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRMetaHost.EnumerateInstalledRuntimes"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRMetaHost::EnumerateInstalledRuntimes"
helpviewer_keywords: 
  - "ICLRMetaHost::EnumerateInstalledRuntimes method [.NET Framework hosting]"
  - "EnumerateInstalledRuntimes method [.NET Framework hosting]"
ms.assetid: 9e359384-0d3d-451c-807e-5d7fcebf2be7
topic_type: 
  - "apiref"
---
# ICLRMetaHost::EnumerateInstalledRuntimes Method

Returns an enumeration that contains a valid [ICLRRuntimeInfo](iclrruntimeinfo-interface.md) interface for each version of the common language runtime (CLR) that is installed on a computer.  
  
## Syntax  
  
```cpp  
HRESULT EnumerateInstalledRuntimes (  
    [out, retval] IEnumUnknown **ppEnumerator);  
```  
  
## Parameters  

 `ppEnumerator`  
 [out] An enumeration of [ICLRRuntimeInfo](iclrruntimeinfo-interface.md) interfaces corresponding to each version of the CLR that is installed on the computer.  
  
## Return Value  

 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully.|  
|E_POINTER|`ppEnumerator` is null.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICLRMetaHost Interface](iclrmetahost-interface.md)
- [Hosting](index.md)
