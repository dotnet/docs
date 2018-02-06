---
title: "IHostSecurityContext Interface"
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
  - "IHostSecurityContext"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostSecurityContext"
helpviewer_keywords: 
  - "IHostSecurityContext interface [.NET Framework hosting]"
ms.assetid: 88e2eac0-8ccb-404f-abbc-287d55159842
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostSecurityContext Interface
Allows the common language runtime (CLR) to maintain security context information implemented by the host.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Capture Method](../../../../docs/framework/unmanaged-api/hosting/ihostsecuritycontext-capture-method.md)|Gets a clone of the `IHostSecurityContext` instance returned from a call to [IHostSecurityManager::GetSecurityContext](../../../../docs/framework/unmanaged-api/hosting/ihostsecuritymanager-getsecuritycontext-method.md).|  
  
## Remarks  
 A host can control all code access to thread tokens by both the CLR and user code. It can also ensure that complete security context information is passed across asynchronous operations or code points with restricted code access. `IHostSecurityContext` encapsulates this security context information, which is opaque to the runtime. The runtime captures this information using `Capture`, and moves it across thread pool worker item dispatch, finalizer execution, and module and class constructors.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRHostProtectionManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrhostprotectionmanager-interface.md)  
 [IHostSecurityManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostsecuritymanager-interface.md)  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)
