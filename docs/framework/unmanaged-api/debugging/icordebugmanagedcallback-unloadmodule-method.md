---
title: "ICorDebugManagedCallback::UnloadModule Method | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
apiname: 
  - "ICorDebugManagedCallback.UnloadModule"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICorDebugManagedCallback::UnloadModule"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ICorDebugManagedCallback::UnloadModule method [.NET Framework debugging]"
  - "UnloadModule method [.NET Framework debugging]"
ms.assetid: b12bfcd9-1e29-48bf-9a3d-44bfae5df5e8
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorDebugManagedCallback::UnloadModule Method
Notifies the debugger that a common language runtime module (DLL) has been unloaded.  
  
## Syntax  
  
```  
HRESULT UnloadModule (  
    [in] ICorDebugAppDomain  *pAppDomain,  
    [in] ICorDebugModule     *pModule  
);  
```  
  
#### Parameters  
 `pAppDomain`  
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain that contained the module.  
  
 `pModule`  
 [in] A pointer to an ICorDebugModule object that represents the module.  
  
## Remarks  
 The module should not be used after this call.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [LoadModule Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-loadmodule-method.md)   
 [ICorDebugManagedCallback Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-interface.md)