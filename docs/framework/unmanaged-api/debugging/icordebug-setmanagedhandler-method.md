---
title: "ICorDebug::SetManagedHandler Method"
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
  - "ICorDebug.SetManagedHandler"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebug::SetManagedHandler"
helpviewer_keywords: 
  - "ICorDebug::SetManagedHandler method [.NET Framework debugging]"
  - "SetManagedHandler method [.NET Framework debugging]"
ms.assetid: d079131b-685b-4869-95be-826b88d28bd2
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebug::SetManagedHandler Method
Specifies the event handler object for managed events.  
  
## Syntax  
  
```  
HRESULT SetManagedHandler (  
    [in] ICorDebugManagedCallback     *pCallback  
);  
```  
  
#### Parameters  
 `pCallback`  
 [in] A pointer to an [ICorDebugManagedCallback](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-interface.md) object, which is the event handler object.  
  
## Remarks  
 `SetManagedHandler` must be called at creation time.  
  
 If the `ICorDebugManagedCallback` implementation does not contain sufficient interfaces to handle debugging events for the application that is being debugged, `SetManagedHandler` returns an HRESULT of E_NOINTERFACE.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICorDebug Interface](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md)
