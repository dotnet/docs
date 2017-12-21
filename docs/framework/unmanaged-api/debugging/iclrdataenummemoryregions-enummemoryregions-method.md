---
title: "ICLRDataEnumMemoryRegions::EnumMemoryRegions Method"
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
  - "ICLRDataEnumMemoryRegions.EnumMemoryRegions"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDataEnumMemoryRegions::EnumMemoryRegions"
helpviewer_keywords: 
  - "ICLRDataEnumMemoryRegions::EnumMemoryRegions method [.NET Framework debugging]"
  - "EnumMemoryRegions method [.NET Framework debugging]"
ms.assetid: 22d2e339-f174-40b5-a478-0b744501566f
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRDataEnumMemoryRegions::EnumMemoryRegions Method
Enumerates specified areas of memory.  
  
## Syntax  
  
```  
HRESULT EnumMemoryRegions (  
    [in] ICLRDataEnumMemoryRegionsCallback  *callback,  
    [in] ULONG32                            miniDumpFlags,  
    [in] CLRDataEnumMemoryFlags             clrFlags  
);  
```  
  
#### Parameters  
 `callback`  
 [in] A pointer to an [ICLRDataEnumMemoryRegionsCallback](../../../../docs/framework/unmanaged-api/debugging/iclrdataenummemoryregionscallback-interface.md) instance that is called by this method for each memory region being enumerated to notify the debugger of the result.  
  
 The enumeration of memory regions continues even if the callback indicates a failure.  
  
 `miniDumpFlags`  
 [in] Not used.  
  
 `clrFlags`  
 [in] A value of the [CLRDataEnumMemoryFlags](../../../../docs/framework/unmanaged-api/debugging/clrdataenummemoryflags-enumeration.md) enumeration that specifies the regions of memory to be enumerated.  
  
## Remarks  
 This method uses the specified [ICLRDataEnumMemoryRegionsCallback](../../../../docs/framework/unmanaged-api/debugging/iclrdataenummemoryregionscallback-interface.md) instance to notify the caller of results.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRDataEnumMemoryRegions Interface](../../../../docs/framework/unmanaged-api/debugging/iclrdataenummemoryregions-interface.md)
