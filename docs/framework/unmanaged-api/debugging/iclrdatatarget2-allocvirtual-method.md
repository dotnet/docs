---
description: "Learn more about: ICLRDataTarget2::AllocVirtual Method"
title: "ICLRDataTarget2::AllocVirtual Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRDataTarget2.AllocVirtual"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDataTarget2::AllocVirtual"
helpviewer_keywords: 
  - "ICLRDataTarget2::AllocVirtual method [.NET Framework debugging]"
  - "AllocVirtual method [.NET Framework debugging]"
ms.assetid: e3226230-964b-47fb-9f53-d6fdbeda1e9e
topic_type: 
  - "apiref"
---
# ICLRDataTarget2::AllocVirtual Method

Called by the common language runtime (CLR) data access services to allocate memory in the address space of this target process.  
  
## Syntax  
  
```cpp  
HRESULT AllocVirtual(  
    [in] CLRDATA_ADDRESS addr,  
    [in] ULONG32 size,  
    [in] ULONG32 typeFlags,  
    [in] ULONG32 protectFlags,  
    [out] CLRDATA_ADDRESS* virt  
);  
```  
  
## Parameters  

 `addr`  
 [in] A `CLRDATA_ADDRESS` value that specifies the requested starting address of the memory to be allocated.  
  
 `size`  
 [in] The size, in bytes, of the memory to be allocated.  
  
 `typeFlags`  
 [in] Flags that control the allocation of memory. See the Win32 `VirtualAlloc` function.  
  
 `protectFlags`  
 [in] The protection attributes for the allocated memory. See the Win32 `VirtualAlloc` function.  
  
 `virt`  
 [out] A pointer to a `CLRDATA_ADDRESS` value that specifies the actual starting address of the allocated memory.  
  
## Remarks  

 The `AllocVirtual` method serves as a logical wrapper for the Win32 `VirtualAlloc` function.  
  
 This method is implemented by the writer of the debugging application.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRDataTarget2 Interface](iclrdatatarget2-interface.md)
- [FreeVirtual Method](iclrdatatarget2-freevirtual-method.md)
