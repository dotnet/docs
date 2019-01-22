---
title: "MALLOC_TYPE Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "MALLOC_TYPE"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "MALLOC_TYPE"
helpviewer_keywords: 
  - "MALLOC_TYPE Enumeration"
ms.assetid: c02476f9-23a2-4af7-9282-aa9c42c7429b
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# MALLOC_TYPE Enumeration
Contains values that specify the characteristics of the memory that is being allocated.  
  
## Syntax  
  
```  
typedef enum {  
    MALLOC_THREADSAFE = 0x1,  
    MALLOC_EXECUTABLE = 0x2,  
} MALLOC_TYPE;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`MALLOC_EXECUTABLE`|The allocated memory can contain an executable file.|  
|`MALLOC_THREADSAFE`|The allocated memory is thread-safe. That is, the memory can be accessed by multiple threads without any synchronization.<br /><br /> If this flag is not set, calls on the object must be serialized.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
 [Hosting Enumerations](../../../../docs/framework/unmanaged-api/hosting/hosting-enumerations.md)
