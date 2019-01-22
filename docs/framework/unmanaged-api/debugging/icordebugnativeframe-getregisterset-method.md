---
title: "ICorDebugNativeFrame::GetRegisterSet Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugNativeFrame.GetRegisterSet"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugNativeFrame::GetRegisterSet"
helpviewer_keywords: 
  - "ICorDebugNativeFrame::GetRegisterSet method [.NET Framework debugging]"
  - "GetRegisterSet method, ICorDebugNativeFrame interface [.NET Framework debugging]"
ms.assetid: 6f309b5f-5556-4f1e-b1dd-4fe97fc81d01
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugNativeFrame::GetRegisterSet Method
Gets the register set for this stack frame.  
  
## Syntax  
  
```  
HRESULT GetRegisterSet (  
    [out] ICorDebugRegisterSet **ppRegisters  
);  
```  
  
#### Parameters  
 `ppRegisters`  
 [out] A pointer to the address of an [ICorDebugRegisterSet](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset-interface.md) object that represents the register set for this stack frame.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
 
