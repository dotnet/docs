---
title: "IHostAssemblyManager Interface"
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
  - "IHostAssemblyManager"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostAssemblyManager"
helpviewer_keywords: 
  - "IHostAssemblyManager interface [.NET Framework hosting]"
ms.assetid: dfec05bb-3cd7-4bd5-b396-a4f097c3a636
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostAssemblyManager Interface
Provides methods that allow a host to specify sets of assemblies that should be loaded by the common language runtime (CLR) or by the host.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetAssemblyStore Method](../../../../docs/framework/unmanaged-api/hosting/ihostassemblymanager-getassemblystore-method.md)|Gets an interface pointer to an [IHostAssemblyStore](../../../../docs/framework/unmanaged-api/hosting/ihostassemblystore-interface.md) that represents the list of assemblies loaded by the host.|  
|[GetNonHostStoreAssemblies Method](../../../../docs/framework/unmanaged-api/hosting/ihostassemblymanager-getnonhoststoreassemblies-method.md)|Gets an interface pointer to an [ICLRAssemblyReferenceList](../../../../docs/framework/unmanaged-api/hosting/iclrassemblyreferencelist-interface.md) that represents the list of assemblies that the host expects the CLR to load.|  
  
## Remarks  
 The host is not required to implement `IHostAssemblyManager` or `IHostAssemblyStore`. If the host does implement `IHostAssemblyManager`, it must also implement `IHostAssemblyStore`.  
  
 The runtime queries for an `IHostAssemblyManager` by calling [IHostControl::GetHostManager](../../../../docs/framework/unmanaged-api/hosting/ihostcontrol-gethostmanager-method.md) upon initialization with an `IID` of IID_IHostAssemblyManager.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRAssemblyReferenceList Interface](../../../../docs/framework/unmanaged-api/hosting/iclrassemblyreferencelist-interface.md)  
 [IHostAssemblyStore Interface](../../../../docs/framework/unmanaged-api/hosting/ihostassemblystore-interface.md)  
 [IHostControl Interface](../../../../docs/framework/unmanaged-api/hosting/ihostcontrol-interface.md)  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)
