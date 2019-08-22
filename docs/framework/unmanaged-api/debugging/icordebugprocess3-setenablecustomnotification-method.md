---
title: "ICorDebugProcess3::SetEnableCustomNotification Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugProcess3.SetEnableCustomNotification Method"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess3::SetEnableCustomNotification"
helpviewer_keywords: 
  - "ICorDebugProcess3::SetEnableCustomNotification method [.NET Framework debugging]"
  - "SetEnableCustomNotification method [.NET Framework debugging]"
ms.assetid: afd88ee9-2589-4461-a75a-9b6fe55a2525
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugProcess3::SetEnableCustomNotification Method
Enables and disables custom debugger notifications of the specified type.  
  
## Syntax  
  
```cpp  
HRESULT SetEnableCustomNotification(ICorDebugClass * pClass,  
                                    BOOL fEnable);  
```  
  
## Parameters  
 `pClass`  
 [in] The type that specifies custom debugger notifications.  
  
 `fEnable`  
 [in] `true` to enable custom debugger notifications; `false` to disable notifications. The default value is `false`.  
  
## Remarks  
 When `fEnable` is set to `true`, calls to the <xref:System.Diagnostics.Debugger.NotifyOfCrossThreadDependency%2A?displayProperty=nameWithType> method trigger an [ICorDebugManagedCallback3::CustomNotification](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback3-customnotification-method.md) callback. Notifications are disabled by default; therefore, the debugger must specify any notification types it knows about and wants to handle. Because the [ICorDebugClass](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md) class is scoped by application domain, the debugger must call `SetEnableCustomNotification` for every application domain in the process if it wants to receive the notification across the entire process.  
  
 Starting with the .NET Framework 4, the only supported notification is a cross-thread dependency notification.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICorDebugProcess3 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess3-interface.md)
- [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
- [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
