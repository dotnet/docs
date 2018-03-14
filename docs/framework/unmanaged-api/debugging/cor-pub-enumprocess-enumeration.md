---
title: "COR_PUB_ENUMPROCESS Enumeration"
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
  - "COR_PUB_ENUMPROCESS"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_PUB_ENUMPROCESS"
helpviewer_keywords: 
  - "COR_PUB_ENUMPROCESS enumeration [.NET Framework debugging]"
ms.assetid: 5d3ada6e-feea-47da-a7ed-b664107c137f
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# COR_PUB_ENUMPROCESS Enumeration
Identifies the type of process to be enumerated.  
  
## Syntax  
  
```  
typedef enum {  
    COR_PUB_MANAGEDONLY    = 0x00000001  
} COR_PUB_ENUMPROCESS;  
```  
  
## Members  
  
|Member name|Description|  
|-----------------|-----------------|  
|`COR_PUB_MANAGEDONLY`|A managed process.|  
  
## Remarks  
 The current version of the unmanaged debugging API enumerates only managed processes.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorPub.idl, CorPub.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Debugging Enumerations](../../../../docs/framework/unmanaged-api/debugging/debugging-enumerations.md)
