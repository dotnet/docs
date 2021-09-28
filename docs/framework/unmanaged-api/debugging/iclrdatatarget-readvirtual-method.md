---
description: "Learn more about: ICLRDataTarget::ReadVirtual Method"
title: "ICLRDataTarget::ReadVirtual Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRDataTarget.ReadVirtual"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDataTarget::ReadVirtual"
helpviewer_keywords: 
  - "ReadVirtual method, ICLRDataTarget interface [.NET Framework debugging]"
  - "ICLRDataTarget::ReadVirtual method [.NET Framework debugging]"
ms.assetid: da3769eb-1828-4aa1-b9ed-db4842136a43
topic_type: 
  - "apiref"
---
# ICLRDataTarget::ReadVirtual Method

Reads data from the specified virtual memory address into the specified buffer.  
  
## Syntax  
  
```cpp  
HRESULT ReadVirtual (  
    [in] CLRDATA_ADDRESS    address,  
    [out, size_is(bytesRequested), length_is(*bytesRead)]
        BYTE                *buffer,  
    [in] ULONG32            bytesRequested,  
    [out] ULONG32           *bytesRead  
);  
```  
  
## Parameters  

 `address`  
 [in] A CLRDATA_ADDRESS that stores the virtual memory address.  
  
 `buffer`  
 [out] A pointer to a buffer that receives the data.  
  
 `bytesRequested`  
 [in] The length of the buffer.  
  
 `bytesRead`  
 [out] A pointer to the number of bytes returned.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRDataTarget Interface](iclrdatatarget-interface.md)
