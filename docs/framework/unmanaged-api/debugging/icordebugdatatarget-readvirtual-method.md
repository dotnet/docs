---
title: "ICorDebugDataTarget::ReadVirtual Method"
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
  - "ICorDebugDataTarget.ReadVirtual Method"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugDataTarget::ReadVirtual"
helpviewer_keywords: 
  - "ICorDebugDataTarget::ReadVirtual method [.NET Framework debugging]"
  - "ReadVirtual method, ICorDebugDataTarget interface [.NET Framework debugging]"
ms.assetid: 55e57640-b3d2-413d-b4f4-fbc27fb8e37c
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugDataTarget::ReadVirtual Method
Gets a block of contiguous memory starting at the specified address, and returns it in the supplied buffer.  
  
## Syntax  
  
```  
HRESULT ReadVirtual(  
    [in] CORDB_ADDRESS   address,  
    [out, size_is(bytesRequested), length_is(*pBytesRead)]  
          BYTE *     pBuffer,  
    [in]  ULONG32    bytesRequested,  
    [out] ULONG32 *  pBytesRead);  
```  
  
#### Parameters  
 `address`  
 [in] The start address of requested memory.  
  
 `pbuffer`  
 [out] The buffer where the memory will be stored.  
  
 `bytesRequested`  
 [in] The number of bytes to get from the target address.  
  
 `pBytesRead`  
 [out] The number of bytes actually read from the target address. This can be fewer than `bytesRequested`.  
  
## Remarks  
 If the first byte (at the specified start address) can be read, the call should return success (to support efficient reading of data structures with self-describing length, like null-terminated strings).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICorDebugDataTarget Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugdatatarget-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
