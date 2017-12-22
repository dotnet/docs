---
title: "COR_PRF_RUNTIME_TYPE Enumeration"
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
  - "COR_PRF_RUNTIME_TYPE Enumeration"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_PRF_RUNTIME_TYPE"
helpviewer_keywords: 
  - "COR_PRF_RUNTIME_TYPE enumeration [.NET Framework profiling]"
ms.assetid: 35449514-333f-4918-9c60-7aa198d655d2
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# COR_PRF_RUNTIME_TYPE Enumeration
Contains values that indicate the version of the common language runtime (CLR): desktop or CoreCLR, which is used in Silverlight.  
  
## Syntax  
  
```  
typedef enum  
{  
    COR_PRF_DESKTOP_CLR = 0x1,  
    COR_PRF_CORE_CLR    = 0x2,  
} COR_PRF_RUNTIME_TYPE;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`COR_PRF_DESKTOP_CLR`|The desktop version of the CLR.|  
|`COR_PRF_CORE_CLR`|The core version of the CLR, used in Silverlight.|  
  
## Remarks  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [Profiling Enumerations](../../../../docs/framework/unmanaged-api/profiling/profiling-enumerations.md)
