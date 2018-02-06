---
title: "ICorDebugManagedCallback::Break Method"
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
  - "ICorDebugManagedCallback.Break"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback::Break"
helpviewer_keywords: 
  - "Break method [.NET Framework debugging]"
  - "ICorDebugManagedCallback::Break method [.NET Framework debugging]"
ms.assetid: 7d78a301-82b3-43b2-9d65-3cda3285ae97
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugManagedCallback::Break Method
Notifies the debugger when a <xref:System.Reflection.Emit.OpCodes.Break> instruction in the code stream is executed.  
  
## Syntax  
  
```  
HRESULT Break (  
    [in] ICorDebugAppDomain *pAppDomain,  
    [in] ICorDebugThread    *thread  
);  
```  
  
#### Parameters  
 `pAppDOmain`  
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain that contains the break instruction.  
  
 `thread`  
 [in] A pointer to an ICorDebugThread object that represents the thread that contains the break instruction.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICorDebugManagedCallback Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-interface.md)
