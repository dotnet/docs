---
title: "CLSID_RESOLUTION_FLAGS Enumeration"
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
  - "CLSID_RESOLUTION_FLAGS"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CLSID_RESOLUTION_FLAGS"
helpviewer_keywords: 
  - "CLSID_RESOLUTION_FLAGS enumeration [.NET Framework hosting]"
ms.assetid: cd8b9879-962a-4811-aa46-2e2b6bae0d84
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CLSID_RESOLUTION_FLAGS Enumeration
Contains values that indicate how the common language runtime (CLR) should resolve a `CLSID`.  
  
## Syntax  
  
```  
typedef enum {  
    CLSID_RESOLUTION_DEFAULT      = 0x0,  
    CLSID_RESOLUTION_REGISTERED   = 0x1  
} CLSID_RESOLUTION_FLAGS;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`CLSID_RESOLUTION_DEFAULT`|Indicates the default behavior.|  
|`CLSID_RESOLUTION_REGISTERED`|Indicates that the runtime searches the registry and applies shim policy.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v11plus](../../../../includes/net-current-v11plus-md.md)]  
  
## See Also  
 [Hosting Enumerations](../../../../docs/framework/unmanaged-api/hosting/hosting-enumerations.md)
