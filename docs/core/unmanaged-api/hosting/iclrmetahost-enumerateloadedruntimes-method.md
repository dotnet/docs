---
description: "Learn more about: ICLRMetaHost::EnumerateLoadedRuntimes Method"
title: "ICLRMetaHost::EnumerateLoadedRuntimes Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRMetaHost.EnumerateLoadedRuntimes"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRMetaHost::EnumerateLoadedRuntimes"
helpviewer_keywords: 
  - "EnumerateLoadedRuntimes method [.NET Framework hosting]"
  - "ICLRMetaHost::EnumerateLoadedRuntimes method [.NET Framework hosting]"
ms.assetid: 22fc0a3f-dce4-4766-9a3c-9fab15f4b4ca
topic_type: 
  - "apiref"
---
# ICLRMetaHost::EnumerateLoadedRuntimes Method

Returns an enumeration that includes a valid [ICLRRuntimeInfo](iclrruntimeinfo-interface.md) interface pointer for each version of the common language runtime (CLR) that is loaded in a given process. This method supersedes the [GetVersionFromProcess](getversionfromprocess-function.md) function.  
  
## Syntax  
  
```cpp  
HRESULT EnumerateLoadedRuntimes (  
    [in] HANDLE hndProcess,  
    [out, retval] IEnumUnknown **ppEnumerator  
);  
```  
  
## Parameters  

 `hndProcess`  
 [in] The handle of the process to inspect for loaded runtimes.  
  
 `ppEnumerator`  
 [out] An <xref:Microsoft.VisualStudio.OLE.Interop.IEnumUnknown> enumeration of [ICLRRuntimeInfo](iclrruntimeinfo-interface.md) interfaces corresponding to each CLR that is loaded by the process.  
  
## Return Value  

 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully.|  
|E_POINTER|`ppEnumerator` is null.|  
  
## Remarks  

 This method is lists all loaded runtimes, even if they were loaded with deprecated functions such as [CorBindToRuntime](corbindtoruntime-function.md).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICLRMetaHost Interface](iclrmetahost-interface.md)
- [Hosting](index.md)
