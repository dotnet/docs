---
title: "CLRDataEnumMemoryFlags Enumeration"
ms.date: "03/30/2017"
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
---
# CLRDataEnumMemoryFlags Enumeration
Indicates which memory regions a call to the [ICLRDataEnumMemoryRegions::EnumMemoryRegions](iclrdataenummemoryregions-enummemoryregions-method.md) method should include.  
  
## Syntax  
  
```cpp  
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
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Debugging Enumerations](debugging-enumerations.md)
