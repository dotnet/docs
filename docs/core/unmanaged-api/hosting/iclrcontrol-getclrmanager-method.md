---
description: "Learn more about: ICLRControl::GetCLRManager Method"
title: "ICLRControl::GetCLRManager Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRControl.GetCLRManager"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRControl::GetCLRManager"
helpviewer_keywords: 
  - "GetCLRManager method [.NET Framework hosting]"
  - "ICLRControl::GetCLRManager method [.NET Framework hosting]"
ms.assetid: 8a11bfa4-cbb0-4082-82b5-f9fba66c93f5
topic_type: 
  - "apiref"
---
# ICLRControl::GetCLRManager Method

Gets an interface pointer to an instance of any of the manager types the host can use to configure the common language runtime (CLR).  
  
## Syntax  
  
```cpp  
HRESULT GetCLRManager (  
    [in]  REFIID  riid,  
    [out] void  **ppObject  
);  
```  
  
## Parameters  

 `riid`  
 [in] The `IID` of the manager type to return. The following `IID` values are supported.  
  
- IID_ICLRDebugManager: Specifies that `ppObject` will be of type [ICLRDebugManager](iclrdebugmanager-interface.md).  
  
- IID_ICLRErrorReportingManager: Specifies that `ppObject` will be of type [ICLRErrorReportingManager](iclrerrorreportingmanager-interface.md).  
  
- IID_ICLRGCManager: Specifies that `ppObject` will be of type [ICLRGCManager](iclrgcmanager-interface.md).  
  
- IID_ICLRHostProtectionManager: Specifies that `ppObject` will be of type [ICLRHostProtectionManager](iclrhostprotectionmanager-interface.md).  
  
- IID_ICLROnEventManager: Specifies that `ppObject` will be of type [ICLROnEventManager](iclroneventmanager-interface.md).  
  
- IID_ICLRPolicyManager: Specifies that `ppObject` will be of type [ICLRPolicyManager](iclrpolicymanager-interface.md).  
  
- IID_ICLRTaskManager: Specifies that `ppObject` will be of type [ICLRTaskManager](iclrtaskmanager-interface.md).  
  
 `ppObject`  
 [out] An interface pointer to the requested manager, or null, if an invalid manager type was requested.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_NOINTERFACE|The interface type is not supported.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRControl Interface](iclrcontrol-interface.md)
- [IHostControl Interface](ihostcontrol-interface.md)
