---
title: "ICLRDataTarget::WriteVirtual Method"
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
  - "ICLRDataTarget.WriteVirtual"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDataTarget::WriteVirtual"
helpviewer_keywords: 
  - "ICLRDataTarget::WriteVirtual method [.NET Framework debugging]"
  - "WriteVirtual method [.NET Framework debugging]"
ms.assetid: d627e8b7-a605-40ac-b9bb-da9a3f1b66d9
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRDataTarget::WriteVirtual Method
Writes data from the specified buffer to the specified virtual memory address.  
  
## Syntax  
  
```  
HRESULT WriteVirtual (  
    [in] CLRDATA_ADDRESS    address,  
    [in, size_is(bytesRequested)]   
        BYTE                *buffer,  
    [in] ULONG32            bytesRequested,  
    [out] ULONG32           *bytesWritten  
);  
```  
  
#### Parameters  
 `address`  
 [in] A CLRDATA_ADDRESS that stores the virtual memory address.  
  
 `buffer`  
 [in] A pointer to a buffer that stores the data to be written.  
  
 `bytesRequested`  
 [in] The number of bytes to be written.  
  
 `bytesWritten`  
 [out] A pointer to the actual number of bytes that were written.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRDataTarget Interface](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget-interface.md)
