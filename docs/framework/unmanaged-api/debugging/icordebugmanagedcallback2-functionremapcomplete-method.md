---
title: "ICorDebugManagedCallback2::FunctionRemapComplete Method"
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
  - "ICorDebugManagedCallback2.FunctionRemapComplete"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback2::FunctionRemapComplete"
helpviewer_keywords: 
  - "FunctionRemapComplete method [.NET Framework debugging]"
  - "ICorDebugManagedCallback2::FunctionRemapComplete method [.NET Framework debugging]"
ms.assetid: 5396c4c3-4ec3-4e3a-a38d-d65b21f0a2fc
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugManagedCallback2::FunctionRemapComplete Method
Notifies the debugger that code execution has switched to a new version of an edited function.  
  
## Syntax  
  
```  
HRESULT FunctionRemapComplete (  
    [in] ICorDebugAppDomain   *pAppDomain,  
    [in] ICorDebugThread      *pThread,  
    [in] ICorDebugFunction    *pFunction  
);  
```  
  
#### Parameters  
 `pAppDomain`  
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain containing the edited function.  
  
 `pThread`  
 [in] A pointer to an ICorDebugThread object that represents the thread on which the remap breakpoint was encountered.  
  
 `pFunction`  
 [in] A pointer to an ICorDebugFunction object that represents the version of the function currently running on the thread.  
  
## Remarks  
 This callback gives the debugger an opportunity to recreate any steppers that previously existed.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorDebugManagedCallback2 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback2-interface.md)  
 [ICorDebugManagedCallback Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-interface.md)
