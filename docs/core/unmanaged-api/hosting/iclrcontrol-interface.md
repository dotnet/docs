---
description: "Learn more about: ICLRControl Interface"
title: "ICLRControl Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICLRControl"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRControl"
helpviewer_keywords: 
  - "ICLRControl interface [.NET Framework hosting]"
ms.assetid: a24fd905-1fa6-45a0-ad65-e9e2ee58861e
topic_type: 
  - "apiref"
---
# ICLRControl Interface

Provides methods that allow a host to get references to, and configure aspects of, the common language runtime (CLR).  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetCLRManager Method](iclrcontrol-getclrmanager-method.md)|Gets an interface pointer to an instance of any of the manager types the host can use to configure the CLR.|  
|[SetAppDomainManagerType Method](iclrcontrol-setappdomainmanagertype-method.md)|Sets a type derived from <xref:System.AppDomainManager> as the type for application domain managers.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRAssemblyIdentityManager Interface](iclrassemblyidentitymanager-interface.md)
- [ICLRDebugManager Interface](iclrdebugmanager-interface.md)
- [ICLRGCManager Interface](iclrgcmanager-interface.md)
- [ICLRHostBindingPolicyManager Interface](iclrhostbindingpolicymanager-interface.md)
- [ICLRHostProtectionManager Interface](iclrhostprotectionmanager-interface.md)
- [ICLROnEventManager Interface](iclroneventmanager-interface.md)
- [ICLRPolicyManager Interface](iclrpolicymanager-interface.md)
- [IHostControl Interface](ihostcontrol-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
