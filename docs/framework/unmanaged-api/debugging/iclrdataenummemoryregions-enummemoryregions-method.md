---
description: "Learn more about: ICLRDataEnumMemoryRegions::EnumMemoryRegions Method"
title: "ICLRDataEnumMemoryRegions::EnumMemoryRegions Method"
ms.date: "03/30/2017"
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
---
# ICLRDataEnumMemoryRegions::EnumMemoryRegions Method

Enumerates specified areas of memory.  
  
## Syntax  
  
```cpp  
HRESULT EnumMemoryRegions (  
    [in] ICLRDataEnumMemoryRegionsCallback  *callback,  
    [in] ULONG32                            miniDumpFlags,  
    [in] CLRDataEnumMemoryFlags             clrFlags  
);  
```  
  
## Parameters  

 `callback`  
 [in] A pointer to an [ICLRDataEnumMemoryRegionsCallback](iclrdataenummemoryregionscallback-interface.md) instance that is called by this method for each memory region being enumerated to notify the debugger of the result.  
  
 The enumeration of memory regions continues even if the callback indicates a failure.  
  
 `miniDumpFlags`  
 [in] Not used.  
  
 `clrFlags`  
 [in] A value of the [CLRDataEnumMemoryFlags](clrdataenummemoryflags-enumeration.md) enumeration that specifies the regions of memory to be enumerated.  
  
## Remarks  

 This method uses the specified [ICLRDataEnumMemoryRegionsCallback](iclrdataenummemoryregionscallback-interface.md) instance to notify the caller of results.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRDataEnumMemoryRegions Interface](iclrdataenummemoryregions-interface.md)
