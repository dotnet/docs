---
title: "ICorDebugRegisterSet2::GetRegisters Method"
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
  - "ICorDebugRegisterSet2.GetRegisters"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugRegisterSet2::GetRegisters"
helpviewer_keywords: 
  - "GetRegisters method, ICorDebugRegisterSet2 interface [.NET Framework debugging]"
  - "ICorDebugRegisterSet2::GetRegisters method [.NET Framework debugging]"
ms.assetid: dbc498a8-ba3f-42f2-bdd9-b623c77a1019
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugRegisterSet2::GetRegisters Method
Gets the value of each register (for the platform on which code is currently executing) that is specified by the given bit mask.  
  
## Syntax  
  
```  
HRESULT GetRegisters (  
    [in] ULONG32 maskCount,  
    [in, size_is(maskCount)] BYTE mask[],  
    [in] ULONG32 regCount,  
    [out, size_is(regCount)] CORDB_REGISTER regBuffer[]  
);  
```  
  
#### Parameters  
 `maskCount`  
 [in] The size, in bytes, of the `mask` array.  
  
 `mask`  
 [in] An array of bytes, each bit of which corresponds to a register. If the bit is 1, the corresponding register's value will be retrieved.  
  
 `regCount`  
 [in] The number of register values to be retrieved.  
  
 `regBuffer`  
 [out] An array of `CORDB_REGISTER` objects, each of which receives the value of a register.  
  
## Remarks  
 The `GetRegisters` method returns an array of values from the registers that are specified by the mask. The array does not contain values of registers whose mask bit is not set. Thus, the size of the `regBuffer` array must be equal to the number of 1's in the mask. If the value of `regCount` is too small for the number of registers indicated by the mask, the values of the higher numbered registers will be truncated from the set. If `regCount` is too large, the unused `regBuffer` elements will be unmodified.  
  
 If an unavailable register is indicated by the mask, an indeterminate value will be returned for that register.  
  
 The `ICorDebugRegisterSet2::GetRegisters` method is necessary for platforms which have more than 64 registers. For example, IA64 has 128 general purpose registers and 128 floating-point registers, so you need more than 64-bits in the bit mask.  
  
 If you do not have more than 64 registers, as is the case on platforms such as x86, the `GetRegisters` method actually just translates the bytes in the `mask` byte array into a `ULONG64` and then calls the [ICorDebugRegisterSet::GetRegisters](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset-getregisters-method.md) method, which takes the `ULONG64` mask.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorDebugRegisterSet2 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset2-interface.md)  
 [ICorDebugRegisterSet Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset-interface.md)
