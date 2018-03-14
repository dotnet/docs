---
title: "StackOverflowType Enumeration"
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
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# StackOverflowType Enumeration
Contains values that indicate the underlying cause of a stack overflow event.  
  
## Syntax  
  
```  
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
  
## See Also  
 [Hosting Enumerations](../../../../docs/framework/unmanaged-api/hosting/hosting-enumerations.md)
