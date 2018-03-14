---
title: "IHostControl Interface"
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
  - "IHostControl"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostControl"
helpviewer_keywords: 
  - "IHostControl interface [.NET Framework hosting]"
ms.assetid: a4ae0d1f-ade9-4b0a-a122-93ed11a5e6b3
topic_type: 
  - "apiref"
caps.latest.revision: 16
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostControl Interface
Provides methods for configuring the loading of assemblies, and for determining which hosting interfaces the host supports.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetHostManager Method](../../../../docs/framework/unmanaged-api/hosting/ihostcontrol-gethostmanager-method.md)|Gets an interface pointer to the host's implementation of the interface with the specified `IID`.|  
|[SetAppDomainManager Method](../../../../docs/framework/unmanaged-api/hosting/ihostcontrol-setappdomainmanager-method.md)|Notifies the host that an application domain has been created.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 <xref:System.AppDomainManager>  
 [ICLRRuntimeHost Interface](../../../../docs/framework/unmanaged-api/hosting/iclrruntimehost-interface.md)  
 [ICLRControl Interface](../../../../docs/framework/unmanaged-api/hosting/iclrcontrol-interface.md)  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)
