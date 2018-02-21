---
title: "ICorDebugProcess5::EnableNGENPolicy Method"
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
  - "ICorDebugProcess5::EnableNGenPolicy"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess5::EnableNGENPolicy"
helpviewer_keywords: 
  - "ICorDebugProcess5::EnableNGENPolicy method [.NET Framework debugging]"
  - "EnableNGENPolicy method, ICorDebugProcess5 interface [.NET Framework debugging]"
ms.assetid: 3b8e15ca-3c72-4685-a937-da4c739cb9e9
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugProcess5::EnableNGENPolicy Method
Sets a value that determines how an application loads native images while running under a managed debugger.  
  
## Syntax  
  
```  
HRESULT EnableNGENPolicy(  
    [in] CorDebugNGENPolicy ePolicy  
);  
```  
  
#### Parameters  
 `ePolicy`  
 [in] A [CorDebugNGenPolicy](../../../../docs/framework/unmanaged-api/debugging/cordebugngenpolicy-enumeration.md) constant that determines how an application loads native images while running under a managed debugger.  
  
## Remarks  
 If the policy is set successfully, the method returns `S_OK`. If `ePolicy` is outside the range of the enumerated values defined by [CorDebugNGenPolicy](../../../../docs/framework/unmanaged-api/debugging/cordebugngenpolicy-enumeration.md), the method returns `E_INVALIDARG` and the method call has no effect. If the policy of the Native Image Generator (Ngen.exe) cannot be updated, the method returns `E_FAIL`.  
  
 The `ICorDebugProcess5::EnableNGenPolicy` method can be called at any time during the lifetime of the process. The policy is in effect for any modules that are loaded after the policy is set.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [ICorDebugProcess5 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess5-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
