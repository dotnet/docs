---
title: "StackOverflowType Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "StackOverflowType"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "StackOverflowType"
helpviewer_keywords: 
  - "StackOverflowType enumeration [.NET Framework hosting]"
ms.assetid: dab648ad-972b-479c-b129-b4c1dcbd932e
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# StackOverflowType Enumeration
Contains values that indicate the underlying cause of a stack overflow event.  
  
## Syntax  
  
```cpp  
typedef enum {  
    SO_Managed,  
    SO_ClrEngine,  
    SO_Other  
} StackOverflowType;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`SO_ClrEngine`|The stack overflow was caused by the execution engine.|  
|`SO_Managed`|The stack overflow was caused by managed code.|  
|`SO_Other`|The stack overflow was caused by unmanaged code.|  
  
## Remarks  
 This information is passed to the host through a call to the [IActionOnCLREvent::OnEvent](../../../../docs/framework/unmanaged-api/hosting/iactiononclrevent-onevent-method.md) method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Hosting Enumerations](../../../../docs/framework/unmanaged-api/hosting/hosting-enumerations.md)
