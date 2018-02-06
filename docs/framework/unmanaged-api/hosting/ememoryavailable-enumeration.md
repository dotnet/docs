---
title: "EMemoryAvailable Enumeration"
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
  - "EMemoryAvailable"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "EMemoryAvailable"
helpviewer_keywords: 
  - "EMemoryAvailable enumeration [.NET Framework hosting]"
ms.assetid: 38e72a06-dbed-473b-a59b-7e0b3ea4f2af
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# EMemoryAvailable Enumeration
Contains values that indicate the amount of free physical memory on the computer. These values logically map to the events for high and low memory returned from the `CreateMemoryResourceNotification` function in the Win32 API.  
  
## Syntax  
  
```  
typedef enum {  
    eMemoryAvailableLow     = 1,  
    eMemoryAvailableNeutral = 2,  
    eMemoryAvailableHigh    = 3   
} EMemoryAvailable;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`eMemoryAvailableHigh`|Plenty of physical memory is available.|  
|`eMemoryAvailableLow`|Very little physical memory is available.|  
|`eMemoryAvailableNeutral`|The available physical memory is neutral.|  
  
## Remarks  
 This value is passed by the host to the common language runtime (CLR) by using a call to the [ICLRMemoryNotificationCallback::OnMemoryNotification](../../../../docs/framework/unmanaged-api/hosting/iclrmemorynotificationcallback-onmemorynotification-method.md) method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Hosting Enumerations](../../../../docs/framework/unmanaged-api/hosting/hosting-enumerations.md)
