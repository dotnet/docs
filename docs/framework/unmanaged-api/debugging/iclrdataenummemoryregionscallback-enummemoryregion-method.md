---
title: "ICLRDataEnumMemoryRegionsCallback::EnumMemoryRegion Method"
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
  - "ICLRDataEnumMemoryRegionsCallback.EnumMemoryRegion"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDataEnumMemoryRegionsCallback::EnumMemoryRegion"
helpviewer_keywords: 
  - "EnumMemoryRegion method [.NET Framework debugging]"
  - "ICLRDataEnumMemoryRegionsCallback::EnumMemoryRegion method [.NET Framework debugging]"
ms.assetid: 9bb93fab-57e8-4f9a-9ef3-1794504fa896
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRDataEnumMemoryRegionsCallback::EnumMemoryRegion Method
Called by [ICLRDataEnumMemoryRegions::EnumMemoryRegions](../../../../docs/framework/unmanaged-api/debugging/iclrdataenummemoryregions-enummemoryregions-method.md) to report to the debugger the result of an attempt to enumerate a specified region of memory.  
  
## Syntax  
  
```  
HRESULT EnumMemoryRegion (  
    [in] CLRDATA_ADDRESS  address,  
    [in] ULONG32          size  
);  
```  
  
#### Parameters  
 `address`  
 [in] The starting address of the memory region that was to be enumerated.  
  
 `size`  
 [in] The size, in bytes, of the memory region.  
  
## Remarks  
 The `ICLRDataEnumMemoryRegions::EnumMemoryRegions` method will call this callback method after each attempt to enumerate a memory region. The enumeration will continue even if this method returns an HRESULT indicating failure.  
  
 Regions reported by this callback may be duplicates or overlapping regions.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRDataEnumMemoryRegionsCallback Interface](../../../../docs/framework/unmanaged-api/debugging/iclrdataenummemoryregionscallback-interface.md)
