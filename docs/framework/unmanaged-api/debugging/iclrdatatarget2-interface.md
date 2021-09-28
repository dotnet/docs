---
description: "Learn more about: ICLRDataTarget2 Interface"
title: "ICLRDataTarget2 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICLRDataTarget2"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDataTarget2"
helpviewer_keywords: 
  - "ICLRDataTarget2 interface [.NET Framework debugging]"
ms.assetid: 94249397-861b-4294-a538-cf01466a66d3
topic_type: 
  - "apiref"
---
# ICLRDataTarget2 Interface

A subclass of [ICLRDataTarget](iclrdatatarget-interface.md) that is used by the data access services layer to manipulate virtual memory regions in the target process.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[AllocVirtual Method](iclrdatatarget2-allocvirtual-method.md)|Allocates memory in the address space of the target process.|  
|[FreeVirtual Method](iclrdatatarget2-freevirtual-method.md)|Frees memory that was previously allocated in the address space of the target process.|  
  
## Remarks  

 The API client (that is, the debugger) must implement this interface as appropriate for the particular target process. For example, a live process would have an implementation different from that of a memory dump. The target may not support modification of its memory regions.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRDataTarget Interface](iclrdatatarget-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
