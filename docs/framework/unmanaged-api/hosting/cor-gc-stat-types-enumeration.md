---
title: "COR_GC_STAT_TYPES Enumeration"
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
  - "COR_GC_STAT_TYPES"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_GC_STAT_TYPES"
helpviewer_keywords: 
  - "COR_GC_STAT_TYPES enumeration [.NET Framework hosting]"
ms.assetid: fc51d6db-f7f8-408b-b93d-c166fc712c99
topic_type: 
  - "apiref"
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# COR_GC_STAT_TYPES Enumeration
Specifies the statistics to be recorded for a garbage collection.  
  
## Syntax  
  
```  
typedef enum {  
    COR_GC_COUNTS                 = 0x00000001  
    COR_GC_MEMORYUSAGE            = 0x00000002  
} COR_GC_STAT_TYPES;  
```  
  
## Remarks  
 This enumeration specifies which statistics in the [COR_GC_STATS](../../../../docs/framework/unmanaged-api/hosting/cor-gc-stats-structure.md) structure are to be set by [ICLRGCManager::GetStats](../../../../docs/framework/unmanaged-api/hosting/iclrgcmanager-getstats-method.md) method.  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`COR_GC_COUNTS`|Records the number of garbage collections performed for each generation.|  
|`COR_GC_MEMORYUSAGE`|Records memory usage and garbage collection size statistics.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** GCHost.idl, GCHost.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [COR_GC_STATS Structure](../../../../docs/framework/unmanaged-api/hosting/cor-gc-stats-structure.md)  
 [Hosting Enumerations](../../../../docs/framework/unmanaged-api/hosting/hosting-enumerations.md)
