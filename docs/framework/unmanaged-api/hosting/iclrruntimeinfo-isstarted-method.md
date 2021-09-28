---
description: "Learn more about: ICLRRuntimeInfo::IsStarted Method"
title: "ICLRRuntimeInfo::IsStarted Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRRuntimeInfo.IsStarted"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRRuntimeInfo::IsStarted"
helpviewer_keywords: 
  - "IsStarted method [.NET Framework hosting]"
  - "ICLRRuntimeInfo::IsStarted method [.NET Framework hosting]"
ms.assetid: ef6f2662-323b-4534-aa82-6d1afb7b9309
---
# ICLRRuntimeInfo::IsStarted Method

Indicates whether the runtime has been started (that is, whether the [ICLRRuntimeHost::Start method](iclrruntimehost-start-method.md) has been called and has succeeded).  
  
## Syntax  
  
```cpp  
HRESULT IsStarted(  
        [out] BOOL     *pbStarted,  
        [out] DWORD    *pdwStartupFlags);  
```  
  
## Parameters  

 `pbStarted`  
 [out] `true` if this runtime is started; otherwise, `false`.  
  
 `pdwStartupFlags`  
 [out] Returns the flags that were used to start the runtime.  
  
## Return Value  

 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully.|  
|E_NOTIMPL|The common language runtime (CLR) version is earlier than the CLR version in the .NET Framework 4.|  
  
## Remarks  

 This method does not work with CLR versions earlier than the CLR version in the .NET Framework 4.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICLRRuntimeInfo Interface](iclrruntimeinfo-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
- [Hosting](index.md)
