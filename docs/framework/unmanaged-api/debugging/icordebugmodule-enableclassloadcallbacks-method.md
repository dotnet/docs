---
description: "Learn more about: ICorDebugModule::EnableClassLoadCallbacks Method"
title: "ICorDebugModule::EnableClassLoadCallbacks Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugModule.EnableClassLoadCallbacks"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugModule::EnableClassLoadCallbacks"
helpviewer_keywords: 
  - "ICorDebugModule::EnableClassLoadCallbacks method [.NET Framework debugging]"
  - "EnableClassLoadCallbacks method [.NET Framework debugging]"
ms.assetid: 78dad5e4-8e2e-400f-bec3-92ff0205cd82
topic_type: 
  - "apiref"
---
# ICorDebugModule::EnableClassLoadCallbacks Method

Controls whether the [ICorDebugManagedCallback::LoadClass](icordebugmanagedcallback-loadclass-method.md) and [ICorDebugManagedCallback::UnloadClass](icordebugmanagedcallback-unloadclass-method.md) callbacks are called for this module.  
  
## Syntax  
  
```cpp  
HRESULT EnableClassLoadCallbacks(  
    [in] BOOL bClassLoadCallbacks  
);  
```  
  
## Parameters  

 `bClassLoadCallbacks`  
 [in] Set this value to `true` to enable the common language runtime (CLR) to call the `ICorDebugManagedCallback::LoadClass` and `ICorDebugManagedCallback::UnloadClass` methods when their associated events occur.  
  
 The default value is `false` for non-dynamic modules. The value is always `true` for dynamic modules and cannot be changed.  
  
## Remarks  

 The `ICorDebugManagedCallback::LoadClass` and `ICorDebugManagedCallback::UnloadClass` callbacks are always enabled for dynamic modules and cannot be disabled.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
