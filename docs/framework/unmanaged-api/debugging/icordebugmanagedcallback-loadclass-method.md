---
title: "ICorDebugManagedCallback::LoadClass Method"
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
  - "ICorDebugManagedCallback.LoadClass"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback::LoadClass"
helpviewer_keywords: 
  - "ICorDebugManagedCallback::LoadClass method [.NET Framework debugging]"
  - "LoadClass method [.NET Framework debugging]"
ms.assetid: e58dac7b-85c3-41ca-b9aa-3a7fc9ae6680
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugManagedCallback::LoadClass Method
Notifies the debugger that a class has been loaded.  
  
## Syntax  
  
```  
HRESULT LoadClass (  
    [in] ICorDebugAppDomain *pAppDomain,  
    [in] ICorDebugClass     *c  
);  
```  
  
#### Parameters  
 `pAppDomain`  
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain into which the class has been loaded.  
  
 `c`  
 [in] A pointer to an ICorDebugClass object that represents the class.  
  
## Remarks  
 This callback occurs only if class loading has been enabled for the module that contains the class. Class loading is always enabled for dynamic modules.  
  
 The `LoadClass` callback provides an appropriate time to bind breakpoints to newly generated classes in dynamic modules.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [UnloadClass Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-unloadclass-method.md)  
 [ICorDebugManagedCallback Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-interface.md)
