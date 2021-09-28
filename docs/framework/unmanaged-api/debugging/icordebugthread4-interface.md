---
description: "Learn more about: ICorDebugThread4 Interface"
title: "ICorDebugThread4 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugThread4"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread4"
helpviewer_keywords: 
  - "ICorDebugThread4 interface [.NET Framework debugging]"
ms.assetid: a8c7719a-322b-4133-8566-4c27218dc104
topic_type: 
  - "apiref"
---
# ICorDebugThread4 Interface

Provides thread blocking information.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetBlockingObjects Method](icordebugthread4-getblockingobjects-method.md)|Provides an ordered enumeration of [CorDebugBlockingObject](cordebugblockingobject-structure.md) structures that provide thread blocking information.|  
|[HadUnhandledException Method](icordebugthread4-hadunhandledexception-method.md)|Indicates whether the thread has ever had an unhandled exception.|  
|[GetCurrentCustomDebuggerNotification Method](icordebugthread4-getcurrentcustomdebuggernotification-method.md)|Gets the current [ICorDebugManagedCallback3::CustomNotification](icordebugmanagedcallback3-customnotification-method.md) object on the current thread.|  
  
## Remarks  

 This interface is a logical extension of the ICorDebugThread, ICorDebugThread2, and [ICorDebugThread3](icordebugthread3-interface.md) interfaces.  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
