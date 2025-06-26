---
description: "Learn more about: ICLRRuntimeHost::GetCLRControl Method"
title: "ICLRRuntimeHost::GetCLRControl Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRRuntimeHost.GetCLRControl"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRRuntimeHost::GetCLRControl"
helpviewer_keywords: 
  - "ICLRRuntimeHost::GetCLRControl method [.NET Framework hosting]"
  - "GetCLRControl method [.NET Framework hosting]"
ms.assetid: e47e3655-efd5-4572-a1dc-50c69bf2a468
topic_type: 
  - "apiref"
---
# ICLRRuntimeHost::GetCLRControl Method

Gets an interface pointer of type [ICLRControl Interface](iclrcontrol-interface.md) that hosts can use to customize aspects of the common language runtime (CLR).  
  
## Syntax  
  
```cpp  
HRESULT GetCLRControl(  
    [out] ICLRControl** pCLRControl  
);  
```  
  
## Parameters  

 `pCLRControl`  
 [out] An interface pointer of type [ICLRControl Interface](iclrcontrol-interface.md) that enables hosts to configure additional aspects of the CLR.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`GetCLRControl` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|HOST_E_INVALIDOPERATION|The CLR has already started.|  
  
## Remarks  

 `ICLRControl` provides the [GetCLRManager Method](iclrcontrol-getclrmanager-method.md) method, which enables the host to get an interface pointer to one of the manager types.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRControl Interface](iclrcontrol-interface.md)
- [ICLRRuntimeHost Interface](iclrruntimehost-interface.md)
