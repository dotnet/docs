---
title: "ICorDebugRegisterSet::GetRegistersAvailable Method"
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
  - "ICorDebugRegisterSet.GetRegistersAvailable"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugRegisterSet::GetRegistersAvailable"
helpviewer_keywords: 
  - "ICorDebugRegisterSet::GetRegistersAvailable method [.NET Framework debugging]"
  - "GetRegistersAvailable method, ICorDebugRegisterSet interface [.NET Framework debugging]"
ms.assetid: 4ba08ffa-55a2-4662-9d6d-4738f1db60c9
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugRegisterSet::GetRegistersAvailable Method
Gets a bit mask indicating which registers in this [ICorDebugRegisterSet](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset-interface.md) are currently available.  
  
## Syntax  
  
```  
HRESULT GetRegistersAvailable (  
    [out] ULONG64   *pAvailable  
);  
```  
  
#### Parameters  
 `pAvailable`  
 [out] A bit mask that indicates which registers are currently available.  
  
## Remarks  
 A register may be unavailable if its value cannot be determined for the given situation.  
  
 The returned mask contains a bit for each register (1 << the register index). The bit value is 1 if the register is available, or 0 if it is not available.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICorDebugRegisterSet Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset-interface.md)  
 [ICorDebugRegisterSet2 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset2-interface.md)
