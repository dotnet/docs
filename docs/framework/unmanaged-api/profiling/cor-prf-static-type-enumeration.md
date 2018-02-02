---
title: "COR_PRF_STATIC_TYPE Enumeration"
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
  - "COR_PRF_STATIC_TYPE"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_PRF_STATIC_TYPE"
helpviewer_keywords: 
  - "COR_PRF_STATIC_TYPE enumeration [.NET Framework profiling]"
ms.assetid: 441d7809-5b65-41a5-ba64-2910a8008315
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# COR_PRF_STATIC_TYPE Enumeration
Indicates whether a field is static and, if so, the static quality that applies to the field. These values can be combined using the bitwise OR operation to indicate that the field has multiple, different static qualities.  
  
## Syntax  
  
```  
typedef enum {  
    COR_PRF_FIELD_NOT_A_STATIC = 0x0,  
    COR_PRF_FIELD_APP_DOMAIN_STATIC = 0x1,  
    COR_PRF_FIELD_THREAD_STATIC = 0x2,  
    COR_PRF_FIELD_CONTEXT_STATIC = 0x4,  
    COR_PRF_FIELD_RVA_STATIC = 0x8  
} COR_PRF_STATIC_TYPE;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`COR_PRF_FIELD_NOT_A_STATIC`|The field is not static.|  
|`COR_PRF_FIELD_APP_DOMAIN_STATIC`|The field is application domain-static.|  
|`COR_PRF_FIELD_THREAD_STATIC`|The field is thread-static.|  
|`COR_PRF_FIELD_CONTEXT_STATIC`|The field is context-static.|  
|`COR_PRF_FIELD_RVA_STATIC`|The field is relative virtual address (RVA)-static.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Profiling Enumerations](../../../../docs/framework/unmanaged-api/profiling/profiling-enumerations.md)
