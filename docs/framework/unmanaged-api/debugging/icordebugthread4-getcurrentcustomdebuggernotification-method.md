---
title: "ICorDebugThread4::GetCurrentCustomDebuggerNotification Method"
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
  - "ICorDebugThread4.GetCurrentCustomDebuggerNotification Method"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread4::GetCurrentCustomDebuggerNotification"
helpviewer_keywords: 
  - "GetCurrentCustomDebuggerNotification method [.NET Framework debugging]"
  - "ICorDebugThread4::GetCurrentCustomDebuggerNotification method [.NET Framework debugging]"
ms.assetid: 57e0f2d2-5f0e-4e2d-99ec-3f26632eb693
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugThread4::GetCurrentCustomDebuggerNotification Method
Gets the current [ICorDebugManagedCallback3::CustomNotification](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback3-customnotification-method.md) object on the current thread.  
  
## Syntax  
  
```  
HRESULT GetCurrentCustomDebuggerNotification(  
    [out] ICorDebugValue **ppNotificationObject  
    );  
```  
  
#### Parameters  
 `ppNOtificationObject`  
 [out] A pointer to the current `ICorDebugManagedCallback3::CustomNotification` object on the current thread.  
  
## Remarks  
 The value of `ppNotificationObject` is null if the method is not called from within a `ICorDebugManagedCallback3::CustomNotification` callback, or if no current notification object exists.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICorDebugThread4 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugthread4-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
