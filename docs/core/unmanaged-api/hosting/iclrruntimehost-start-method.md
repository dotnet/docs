---
description: "Learn more about: ICLRRuntimeHost::Start Method"
title: "ICLRRuntimeHost::Start Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRRuntimeHost.Start"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRRuntimeHost::Start"
helpviewer_keywords: 
  - "ICLRRuntimeHost::Start method [.NET Framework hosting]"
  - "Start method, ICLRRuntimeHost interface [.NET Framework hosting]"
ms.assetid: c0a6dce5-0a8d-42e8-808b-6ca14df9d289
topic_type: 
  - "apiref"
---
# ICLRRuntimeHost::Start Method

Initializes the common language runtime (CLR) into a process.  
  
## Syntax  
  
```cpp  
HRESULT Start();  
```  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`Start` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 In many scenarios it is not necessary to call `Start`, because the runtime will initialize itself automatically upon the first request to run managed code. You can, however, use `Start` to specify exactly when the runtime should be initialized.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- <xref:System.AppDomain>
- [ICLRRuntimeHost Interface](iclrruntimehost-interface.md)
