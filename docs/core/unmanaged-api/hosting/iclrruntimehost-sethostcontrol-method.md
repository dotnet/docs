---
description: "Learn more about: ICLRRuntimeHost::SetHostControl Method"
title: "ICLRRuntimeHost::SetHostControl Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRRuntimeHost.SetHostControl"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRRuntimeHost::SetHostControl"
helpviewer_keywords: 
  - "SetHostControl method [.NET Framework hosting]"
  - "ICLRRuntimeHost::SetHostControl method [.NET Framework hosting]"
ms.assetid: 6136be87-e631-4756-81ed-74b66581bad4
topic_type: 
  - "apiref"
---
# ICLRRuntimeHost::SetHostControl Method

Sets the interface pointer that the common language runtime (CLR) can use to get the host's implementation of [IHostControl Interface](ihostcontrol-interface.md).  
  
## Syntax  
  
```cpp  
HRESULT SetHostControl(  
    [in] IHostControl* pHostControl  
);  
```  
  
## Parameters  

 `pHostControl`  
 [in] An interface pointer to the host's implementation of [IHostControl Interface](ihostcontrol-interface.md).  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`SetHostControl` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_CLR_ALREADY_STARTED|The CLR has already been initialized.|  
  
## Remarks  

 You must call `SetHostControl` before the CLR is initialized, that is, before you call [Start Method](iclrruntimehost-start-method.md) or use any of the [Metadata Interfaces](../metadata/metadata-interfaces.md). It is recommended that you call `SetHostControl` immediately after calling [CorBindToCurrentRuntime Function](corbindtocurrentruntime-function.md) or [CorBindToRuntimeEx Function](corbindtoruntimeex-function.md).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRRuntimeHost Interface](iclrruntimehost-interface.md)
- [IHostControl Interface](ihostcontrol-interface.md)
