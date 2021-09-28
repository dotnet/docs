---
description: "Learn more about: ICorDebugModule::IsDynamic Method"
title: "ICorDebugModule::IsDynamic Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugModule.IsDynamic"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugModule::IsDynamic"
helpviewer_keywords: 
  - "IsDynamic method [.NET Framework debugging]"
  - "ICorDebugModule::IsDynamic method [.NET Framework debugging]"
ms.assetid: 5eefe716-5025-4a4c-970c-c823cdc7bb87
topic_type: 
  - "apiref"
---
# ICorDebugModule::IsDynamic Method

Gets a value that indicates whether this module is dynamic.  
  
## Syntax  
  
```cpp  
HRESULT IsDynamic(  
    [out] BOOL *pDynamic  
);  
```  
  
## Parameters  

 `pDynamic`  
 [out] `true` if this module is dynamic; otherwise, `false`.  
  
## Remarks  

 A dynamic module can add new classes and delete existing classes even after the module has been loaded. The [ICorDebugManagedCallback::LoadClass](icordebugmanagedcallback-loadclass-method.md) and [ICorDebugManagedCallback::UnloadClass](icordebugmanagedcallback-unloadclass-method.md) callbacks inform the debugger when a class has been added or deleted.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
