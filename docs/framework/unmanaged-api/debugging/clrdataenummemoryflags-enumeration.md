---
title: "CLRDataEnumMemoryFlags Enumeration"
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
  - "CLRDataEnumMemoryFlags"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CLRDataEnumMemoryFlags"
helpviewer_keywords: 
  - "CLRDataEnumMemoryFlags enumeration [.NET Framework debugging]"
ms.assetid: e249f9fc-e24a-4506-903c-92781f6eab7c
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CLRDataEnumMemoryFlags Enumeration
Indicates which memory regions a call to the [ICLRDataEnumMemoryRegions::EnumMemoryRegions](../../../../docs/framework/unmanaged-api/debugging/iclrdataenummemoryregions-enummemoryregions-method.md) method should include.  
  
## Syntax  
  
```  
typedef enum CLRDataEnumMemoryFlags {  
    CLRDATA_ENUM_MEM_DEFAULT  = 0x0,  
    CLRDATA_ENUM_MEM_MINI     = CLRDATA_ENUM_MEM_DEFAULT,  
    CLRDATA_ENUM_MEM_HEAP     = 0x1  
} CLRDataEnumMemoryFlags;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`CLRDATA_ENUM_MEM_DEFAULT`|A minidump, that is, a sparse memory dump.|  
|`CLRDATA_ENUM_MEM_HEAP`|A full heap dump.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Debugging Enumerations](../../../../docs/framework/unmanaged-api/debugging/debugging-enumerations.md)
