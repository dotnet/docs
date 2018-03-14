---
title: "COR_GC_STATS Structure"
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
  - "COR_GC_STATS"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_GC_STATS"
helpviewer_keywords: 
  - "COR_GC_STATS structure [.NET Framework hosting]"
ms.assetid: 8d4ff73e-739b-40f6-9349-359fbc99c2f9
topic_type: 
  - "apiref"
caps.latest.revision: 16
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# COR_GC_STATS Structure
Provides statistics about the garbage collection mechanism of the common language runtime (CLR).  
  
## Syntax  
  
```  
typedef struct _COR_GC_STATS {  
    ULONG   Flags;   
    SIZE_T  ExplicitGCCount;  
    SIZE_T  GenCollectionsTaken[3];  
    SIZE_T  CommittedKBytes;   
    SIZE_T  ReservedKBytes;  
    SIZE_T  Gen0HeapSizeKBytes;  
    SIZE_T  Gen1HeapSizeKBytes;  
    SIZE_T  Gen2HeapSizeKBytes;  
    SIZE_T  LargeObjectHeapSizeKBytes;  
    SIZE_T  KBytesPromotedFromGen0;  
    SIZE_T  KBytesPromotedFromGen1;  
} COR_GC_STATS;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`Flags`|Indicates which field values should be calculated and returned.|  
|`ExplicitGCCount`|Indicates the number of garbage collections that were forced by external request.|  
|`GenCollectionsTaken`|Indicates the number of garbage collections performed for each generation.|  
|`CommittedKBytes`|The total number of kilobytes committed in all heaps.|  
|`ReservedKBytes`|The total number of kilobytes reserved in all heaps.|  
|`Gen0HeapSizeKBytes`|The size, in kilobytes, of the generation-zero heap.|  
|`Gen1HeapSizeKBytes`|The size, in kilobytes, of the generation-one heap.|  
|`Gen2HeapSizeKBytes`|The size, in kilobytes, of the generation-two heap.|  
|`LargeObjectHeapSizeKBytes`|The size, in kilobytes, of the large object heap.|  
|`KBytesPromotedFromGen0`|The size, in kilobytes, of the objects promoted from generation zero to generation one.|  
|`KBytesPromotedFromGen1`|The size, in kilobytes, of the objects promoted from generation one to generation two.|  
  
## Remarks  
 The [ICLRGCManager::GetStats](../../../../docs/framework/unmanaged-api/hosting/iclrgcmanager-getstats-method.md) method requires the `Flags` field of the `COR_GC_STATS` structure to be set to one or more values of the [COR_GC_STAT_TYPES](../../../../docs/framework/unmanaged-api/hosting/cor-gc-stat-types-enumeration.md) enumeration to specify which statistics are to be set.  
  
 The following table maps the statistics provided by this structure to the two [COR_GC_STAT_TYPES](../../../../docs/framework/unmanaged-api/hosting/cor-gc-stat-types-enumeration.md) enumeration values, `COR_GC_COUNTS` and `COR_GC_MEMORYUSAGE`.  
  
|Specified by COR_GC_COUNTS|Specified by COR_GC_MEMORYUSAGE|  
|----------------------------------|---------------------------------------|  
|`ExplicitGCCount`<br /><br /> `GenCollectionsTaken`|`CommittedKBytes`<br /><br /> `ReservedKBytes`<br /><br /> `Gen0HeapSizeKBytes`<br /><br /> `Gen1HeapSizeKBytes`<br /><br /> `Gen2HeapSizeKBytes`<br /><br /> `LargeObjectHeapSizeKBytes`<br /><br /> `KBytesPromotedFromGen0`<br /><br /> `KBytesPromotedFromGen1`|  
  
 An example of the usage is as follows:  
  
```  
COR_GC_STATS GCStats;  
GCStats.Flags = COR_GC_COUNTS | COR_GC_MEMORYUSAGE;  
pCLRGCManager->GetStats(&GCStats);  
```  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** GCHost.idl  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Hosting Structures](../../../../docs/framework/unmanaged-api/hosting/hosting-structures.md)  
 [Automatic Memory Management](../../../../docs/standard/automatic-memory-management.md)  
 [Garbage Collection](../../../../docs/standard/garbage-collection/index.md)
