---
description: "Learn more about: ICLRErrorReportingManager::EndCustomDump Method"
title: "ICLRErrorReportingManager::EndCustomDump Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRErrorReportingManager.EndCustomDump"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRErrorReportingManager::EndCustomDump"
helpviewer_keywords: 
  - "ICLRErrorReportingManager::EndCustomDump method [.NET Framework hosting]"
  - "EndCustomDump method [.NET Framework hosting]"
ms.assetid: 88a5da04-8729-4108-82c4-af206a7d483e
topic_type: 
  - "apiref"
---
# ICLRErrorReportingManager::EndCustomDump Method

Removes the custom stack dump configuration that was specified in an earlier call to the [ICLRErrorReportingManager::BeginCustomDump](iclrerrorreportingmanager-begincustomdump-method.md) method.  
  
## Syntax  
  
```cpp  
HRESULT EndCustomDump ();  
```  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`EndCustomDump` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 The `EndCustomDump` method clears the custom stack dump configuration set by an earlier call to the `BeginCustomDump` method and frees any associated state. It should be called after the custom stack dump is complete.  
  
> [!IMPORTANT]
> Failure to call `EndCustomDump` causes memory to leak.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [CustomDumpItem Structure](customdumpitem-structure.md)
- [ECustomDumpFlavor Enumeration](ecustomdumpflavor-enumeration.md)
- [ICLRErrorReportingManager Interface](iclrerrorreportingmanager-interface.md)
