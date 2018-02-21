---
title: "ICorDebugManagedCallback::CreateAppDomain Method"
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
  - "ICorDebugManagedCallback.CreateAppDomain"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback::CreateAppDomain"
helpviewer_keywords: 
  - "CreateAppDomain method [.NET Framework debugging]"
  - "ICorDebugManagedCallback::CreateAppDomain method [.NET Framework debugging]"
ms.assetid: 48d410d7-6749-4125-a8fd-f9562c7088e9
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugManagedCallback::CreateAppDomain Method
Notifies the debugger that an application domain has been created.  
  
## Syntax  
  
```  
HRESULT CreateAppDomain (  
    [in] ICorDebugProcess   *pProcess,  
    [in] ICorDebugAppDomain *pAppDomain  
);  
```  
  
#### Parameters  
 `pProcess`  
 [in] A pointer to an ICorDebugProcess object that represents the process in which the application domain was created.  
  
 `pAppDomain`  
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain that has been created.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICorDebugManagedCallback Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-interface.md)
