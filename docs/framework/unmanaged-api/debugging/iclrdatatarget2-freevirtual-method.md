---
description: "Learn more about: ICLRDataTarget2::FreeVirtual Method"
title: "ICLRDataTarget2::FreeVirtual Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRDataTarget2.FreeVirtual"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDataTarget2::FreeVirtual"
helpviewer_keywords: 
  - "ICLRDataTarget::FreeVirtual method [.NET Framework debugging]"
  - "FreeVirtual method [.NET Framework debugging]"
ms.assetid: 26fb69f8-1467-4711-bd24-cb117c63938f
topic_type: 
  - "apiref"
---
# ICLRDataTarget2::FreeVirtual Method

Called by the common language runtime (CLR) data access services to free memory that was previously allocated in the address space of the target process.  
  
## Syntax  
  
```cpp  
HRESULT FreeVirtual(  
    [in] CLRDATA_ADDRESS addr,  
    [in] ULONG32 size,  
    [in] ULONG32 typeFlags  
);  
```  
  
## Parameters  

 `addr`  
 [in] A `CLRDATA_ADDRESS` value that specifies the starting address of the memory to be freed.  
  
 `size`  
 [in] The size, in bytes, of the memory to be freed.  
  
 `typeFlags`  
 [in] Flags that control the freeing of memory. See the Win32 `VirtualFree` function.  
  
## Remarks  

 The `FreeVirtual` method serves as a logical wrapper for the Win32 `VirtualFree` function.  
  
 This method is implemented by the writer of the debugging application.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRDataTarget2 Interface](iclrdatatarget2-interface.md)
- [AllocVirtual Method](iclrdatatarget2-allocvirtual-method.md)
