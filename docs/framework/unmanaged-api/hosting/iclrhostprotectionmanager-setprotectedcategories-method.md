---
description: "Learn more about: ICLRHostProtectionManager::SetProtectedCategories Method"
title: "ICLRHostProtectionManager::SetProtectedCategories Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRHostProtectionManager.SetProtectedCategories"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRHostProtectionManager::SetProtectedCategories"
helpviewer_keywords: 
  - "SetProtectedCategories method [.NET Framework hosting]"
  - "ICLRHostProtectionManager::SetProtectedCategories method [.NET Framework hosting]"
ms.assetid: fa21dc7b-5da7-440b-b59e-9180e5181f9d
topic_type: 
  - "apiref"
---
# ICLRHostProtectionManager::SetProtectedCategories Method

Specifies which categories of managed types and members should be blocked from running in partially trusted code.  
  
## Syntax  
  
```cpp  
HRESULT SetProtectedCategories (  
    [in] EApiCategories  categories  
);  
```  
  
## Parameters  

 `categories`  
 [in] A combination of [EApiCategories](eapicategories-enumeration.md) values, indicating which categories of managed types and members should be blocked from running in partially trusted code.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`SetProtectedCategories` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 Each `EApiCategories` value refers to a list of managed types and members. The `EApiCategories` enumeration and the `SetProtectedCategories` method are directly related to the managed <xref:System.Security.Permissions.HostProtectionAttribute> class, which is used to mark managed types and members that expose capabilities corresponding to the categories described by `EApiCategories`. For more information, see <xref:System.Security.Permissions.HostProtectionAttribute> and the <xref:System.Security.Permissions.HostProtectionResource> enumeration, which directly corresponds to `EApiCategories`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- <xref:System.Security.Permissions.HostProtectionAttribute>
- <xref:System.Security.Permissions.HostProtectionResource>
- [EApiCategories Enumeration](eapicategories-enumeration.md)
- [ICLRControl Interface](iclrcontrol-interface.md)
- [ICLRHostProtectionManager Interface](iclrhostprotectionmanager-interface.md)
