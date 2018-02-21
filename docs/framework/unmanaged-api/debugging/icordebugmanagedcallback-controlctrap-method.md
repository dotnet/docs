---
title: "ICorDebugManagedCallback::ControlCTrap Method"
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
  - "ICorDebugManagedCallback.ControlCTrap"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback::ControlCTrap"
helpviewer_keywords: 
  - "ICorDebugManagedCallback::ControlCTrap method [.NET Framework debugging]"
  - "ControlCTrap method [.NET Framework debugging]"
ms.assetid: 0500854e-2121-43d9-a028-64312da35258
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugManagedCallback::ControlCTrap Method
Notifies the debugger that a CTRL+C is trapped in the process that is being debugged.  
  
## Syntax  
  
```  
HRESULT ControlCTrap (  
    [in] ICorDebugProcess *pProcess  
);  
```  
  
#### Parameters  
 `pProcess`  
 [in] A pointer to an ICorDebugProcess object that represents the process in which the CTRL+C is trapped.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The debugger will handle the CTRL+C trap.|  
|S_FALSE|The debugger will not handle the CTRL+C trap.|  
  
## Remarks  
 All application domains within the process are stopped for this callback.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICorDebugManagedCallback Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-interface.md)
