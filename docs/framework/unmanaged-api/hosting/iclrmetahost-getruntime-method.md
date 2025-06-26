---
description: "Learn more about: ICLRMetaHost::GetRuntime Method"
title: "ICLRMetaHost::GetRuntime Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRMetaHost.GetRuntime"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRMetaHost::GetRuntime"
helpviewer_keywords: 
  - "GetRuntime method [.NET Framework hosting]"
  - "ICLRMetaHost::GetRuntime method [.NET Framework hosting]"
ms.assetid: a10749f1-ab91-47cf-982f-d8ccd2e81bd2
topic_type: 
  - "apiref"
---
# ICLRMetaHost::GetRuntime Method

Gets the [ICLRRuntimeInfo](iclrruntimeinfo-interface.md) interface that corresponds to a particular version of the common language runtime (CLR). This method supersedes the [CorBindToRuntimeEx](corbindtoruntimeex-function.md) function used with the [STARTUP_LOADER_SAFEMODE](startup-flags-enumeration.md) flag.  
  
## Syntax  
  
```cpp  
HRESULT GetRuntime (  
    [in] LPCWSTR pwzVersion,  
    [in] REFIID riid,  
    [out,iid_is(riid), retval] LPVOID *ppRuntime  
);  
```  
  
## Parameters  

 `pwzVersion`  
 [in] The .NET Framework compilation version stored in the metadata, in the format "v*A*.*B*[.*X*]". *A*, *B*, and *X* are decimal numbers that correspond to the major version, the minor version, and the build number.  
  
> [!NOTE]
> This parameter must match the directory name for the .NET Framework version, as it appears under C:\Windows\Microsoft.NET\Framework or C:\Windows\Microsoft.NET\Framework64.  
  
 Example values are "v1.0.3705", "v1.1.4322", "v2.0.50727", and "v4.0.*X*", where *X* depends on the build number installed. The "v" prefix is required.  
  
 `riid`  
 [in] The identifier for the desired interface. Currently, the only valid value for this parameter is IID_ICLRRuntimeInfo.  
  
 `ppRuntime`  
 [out] A pointer to the [ICLRRuntimeInfo](iclrruntimeinfo-interface.md) interface that corresponds to the requested runtime.  
  
## Return Value  

 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully.|  
|E_POINTER|`pwzVersion` or `ppRuntime` is null.|  
  
## Remarks  

 This method interacts consistently with legacy interfaces such as the [ICorRuntimeHost](icorruntimehost-interface.md) interface and legacy functions such as the deprecated `CorBindTo*` functions (see [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md) in the .NET Framework 2.0 hosting API). That is, runtimes that are loaded with the legacy API are visible to the new API, and runtimes that are loaded with the new API are visible to the legacy API.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICLRMetaHost Interface](iclrmetahost-interface.md)
- [Deprecated CLR Hosting Interfaces and Coclasses](deprecated-clr-hosting-interfaces-and-coclasses.md)
- [CLR Hosting Interfaces](clr-hosting-interfaces.md)
- [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md)
- [Hosting](index.md)
