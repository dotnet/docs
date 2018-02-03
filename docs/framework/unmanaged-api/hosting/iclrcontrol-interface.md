---
title: "ICLRControl Interface"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
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
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRControl Interface
Provides methods that allow a host to get references to, and configure aspects of, the common language runtime (CLR).  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetCLRManager Method](../../../../docs/framework/unmanaged-api/hosting/iclrcontrol-getclrmanager-method.md)|Gets an interface pointer to an instance of any of the manager types the host can use to configure the CLR.|  
|[SetAppDomainManagerType Method](../../../../docs/framework/unmanaged-api/hosting/iclrcontrol-setappdomainmanagertype-method.md)|Sets a type derived from <xref:System.AppDomainManager> as the type for application domain managers.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRAssemblyIdentityManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrassemblyidentitymanager-interface.md)  
 [ICLRDebugManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrdebugmanager-interface.md)  
 [ICLRGCManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrgcmanager-interface.md)  
 [ICLRHostBindingPolicyManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrhostbindingpolicymanager-interface.md)  
 [ICLRHostProtectionManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrhostprotectionmanager-interface.md)  
 [ICLROnEventManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclroneventmanager-interface.md)  
 [ICLRPolicyManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrpolicymanager-interface.md)  
 [IHostControl Interface](../../../../docs/framework/unmanaged-api/hosting/ihostcontrol-interface.md)  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)
