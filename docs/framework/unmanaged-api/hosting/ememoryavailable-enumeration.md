---
description: "Learn more about: EMemoryAvailable Enumeration"
title: "EMemoryAvailable Enumeration"
ms.date: "03/30/2017"
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
---
# EMemoryAvailable Enumeration

Contains values that indicate the amount of free physical memory on the computer. These values logically map to the events for high and low memory returned from the `CreateMemoryResourceNotification` function in the Windows API.  
  
## Syntax  
  
```cpp  
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

 This value is passed by the host to the common language runtime (CLR) by using a call to the [ICLRMemoryNotificationCallback::OnMemoryNotification](iclrmemorynotificationcallback-onmemorynotification-method.md) method.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Hosting Enumerations](hosting-enumerations.md)
