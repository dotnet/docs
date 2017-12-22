---
title: "ICorDebugRegisterSet2::GetRegistersAvailable Method"
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
  - "ICorDebugRegisterSet2.GetRegistersAvailable"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugRegisterSet2::GetRegistersAvailable"
helpviewer_keywords: 
  - "GetRegistersAvailable method, ICorDebugRegisterSet2 interface [.NET Framework debugging]"
  - "ICorDebugRegisterSet2::GetRegistersAvailable method [.NET Framework debugging]"
ms.assetid: f3ed344b-0d3a-44e8-8000-2a97e0805a2c
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugRegisterSet2::GetRegistersAvailable Method
Gets an array of bytes that provides a bitmap of the available registers.  
  
## Syntax  
  
```  
HRESULT GetRegistersAvailable (  
    [in] ULONG32 numChunks,  
    [out, size_is(numChunks)] BYTE availableRegChunks[]  
);  
```  
  
#### Parameters  
 `numChunks`  
 [in] The size of the `availableRegChunks` array.  
  
 `availableRegChunks`  
 [out] An array of bytes, each bit of which corresponds to a register. If a register is available, the register's corresponding bit is set.  
  
## Remarks  
 The values of the CorDebugRegister enumeration specify the registers of different microprocessors. The upper five bits of each value are the index into the `availableRegChunks` array of bytes. The lower three bits of each value identify the bit position within the indexed byte. Given a `CorDebugRegister` value that specifies a particular register, the register's position in the mask is determined as follows:  
  
1.  Extract the index needed to access the correct byte in the `availableRegChunks` array:  
  
     `CorDebugRegister` value >> 3  
  
2.  Extract the bit position within the indexed byte, where bit zero is the least significant bit:  
  
     `CorDebugRegister` value & 7  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorDebugRegisterSet2 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset2-interface.md)  
 [ICorDebugRegisterSet Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset-interface.md)
