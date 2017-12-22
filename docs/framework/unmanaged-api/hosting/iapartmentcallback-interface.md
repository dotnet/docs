---
title: "IApartmentCallback Interface"
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
  - "IApartmentCallback"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IApartmentCallback"
helpviewer_keywords: 
  - "IApartmentCallback interface [.NET Framework hosting]"
ms.assetid: 57c33c58-bf0b-4533-b569-e6a682d02cba
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IApartmentCallback Interface
Provides methods for making callbacks within an apartment. An *apartment* is a logical container within a process for objects that share the same thread access requirements.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[DoCallback Method](../../../../docs/framework/unmanaged-api/hosting/iapartmentcallback-docallback-method.md)|Executes the specified function within an apartment.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)
