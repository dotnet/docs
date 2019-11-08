---
title: "ICorDebugChain::GetRegisterSet Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugChain.GetRegisterSet"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugChain::GetRegisterSet"
helpviewer_keywords: 
  - "ICorDebugChain::GetRegisterSet method [.NET Framework debugging]"
  - "GetRegisterSet method, ICorDebugChain interface [.NET Framework debugging]"
ms.assetid: bc4288b6-3331-4ae3-990d-e1d6e62ecb67
topic_type: 
  - "apiref"
---
# ICorDebugChain::GetRegisterSet Method
Gets the register set for the active part of this chain.  
  
## Syntax  
  
```cpp  
HRESULT GetRegisterSet (  
    [out] ICorDebugRegisterSet **ppRegisters  
);  
```  
  
## Parameters  
 `ppRegisters`  
 [out] A pointer to the address of an [ICorDebugRegisterSet](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset-interface.md) object that represents the register set for the active part of this chain.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
