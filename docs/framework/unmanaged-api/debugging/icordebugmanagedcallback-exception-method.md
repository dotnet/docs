---
title: "ICorDebugManagedCallback::Exception Method"
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
  - "ICorDebugManagedCallback.Exception"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback::Exception"
helpviewer_keywords: 
  - "Exception method, ICorDebugManagedCallback interface [.NET Framework debugging]"
  - "ICorDebugManagedCallback::Exception method [.NET Framework debugging]"
ms.assetid: ab18a509-dff3-4930-b585-bd15e0414176
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugManagedCallback::Exception Method
Notifies the debugger that an exception has been thrown from managed code.  
  
## Syntax  
  
```  
HRESULT Exception (  
    [in] ICorDebugAppDomain *pAppDomain,  
    [in] ICorDebugThread    *pThread,  
    [in] BOOL                unhandled  
);  
```  
  
#### Parameters  
 `pAppDomain`  
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain in which the exception was thrown.  
  
 `pThread`  
 [in] A pointer to an ICorDebugThread object that represents the thread in which the exception was thrown.  
  
 `unhandled`  
 [in] If this value is `false`, the exception has not yet been processed by the application; otherwise, the exception is unhandled and will terminate the process.  
  
## Remarks  
 The specific exception can be retrieved from the thread object.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICorDebugManagedCallback Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-interface.md)
