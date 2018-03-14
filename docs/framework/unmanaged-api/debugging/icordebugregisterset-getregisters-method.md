---
title: "ICorDebugRegisterSet::GetRegisters Method"
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
  - "ICorDebugRegisterSet.GetRegisters"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugRegisterSet::GetRegisters"
helpviewer_keywords: 
  - "GetRegisters method, ICorDebugRegisterSet interface [.NET Framework debugging]"
  - "ICorDebugRegisterSet::GetRegisters method [.NET Framework debugging]"
ms.assetid: fdf91864-48ea-4aa6-b70c-361b7a3184c7
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugRegisterSet::GetRegisters Method
Gets the value of each register (on the computer that is currently executing code) that is specified by the bit mask.  
  
## Syntax  
  
```  
HRESULT GetRegisters (  
    [in] ULONG64       mask,   
    [in] ULONG32       regCount,  
    [out, size_is(regCount), length_is(regCount)]  
        CORDB_REGISTER regBuffer[]  
);  
```  
  
#### Parameters  
 `mask`  
 [in] A bit mask that specifies which register values are to be retrieved. Each bit corresponds to a register. If a bit is set to one, the register's value is retrieved; otherwise, the register's value is not retrieved.  
  
 `regCount`  
 [in] The number of register values to be retrieved.  
  
 `regBuffer`  
 [out] An array of `CORDB_REGISTER` objects, each of which receives a value of a register.  
  
## Remarks  
 The size of the array should be equal to the number of bits set to one in the bit mask. The `regCount` parameter specifies the number of elements in the buffer that will receive the register values. If the `regCount` value is too small for the number of registers indicated by the mask, the higher numbered registers will be truncated from the set. If the `regCount` value is too large, the unused `regBuffer` elements will be unmodified.  
  
 If the bit mask specifies a register that is unavailable, `GetRegisters` returns an indeterminate value for that register.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICorDebugRegisterSet Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset-interface.md)  
 [ICorDebugRegisterSet2 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset2-interface.md)
