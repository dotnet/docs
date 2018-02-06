---
title: "ICorDebugManagedCallback::CreateProcess Method"
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
  - "ICorDebugManagedCallback.CreateProcess"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback::CreateProcess"
helpviewer_keywords: 
  - "ICorDebugManagedCallback::CreateProcess method [.NET Framework debugging]"
  - "CreateProcess method, ICorDebugManagedCallback interface [.NET Framework debugging]"
ms.assetid: 8e89d5ee-e4e3-4738-8302-0b7d1cf4846e
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugManagedCallback::CreateProcess Method
Notifies the debugger when a process has been attached or started for the first time.  
  
## Syntax  
  
```  
HRESULT CreateProcess (  
    [in] ICorDebugProcess *pProcess  
);  
```  
  
#### Parameters  
 `pProcess`  
 [in] A pointer to an ICorDebugProcess object that represents the process that has been attached or started.  
  
## Remarks  
 This method is not called until the common language runtime is initialized. Most of the [ICorDebug](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md) methods will return CORDBG_E_NOTREADY before the `CreateProcess` callback.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICorDebugManagedCallback Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-interface.md)
