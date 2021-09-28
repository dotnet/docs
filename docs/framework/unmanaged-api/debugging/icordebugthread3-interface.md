---
description: "Learn more about: ICorDebugThread3 Interface"
title: "ICorDebugThread3 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugThread3"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread3"
helpviewer_keywords: 
  - "ICorDebugThread3 interface [.NET Framework debugging]"
ms.assetid: eb2860ef-06cb-4968-a6c3-6d048ecda2a4
topic_type: 
  - "apiref"
---
# ICorDebugThread3 Interface

Provides the entry point to the [ICorDebugStackWalk](icordebugstackwalk-interface.md) and corresponding interfaces.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[CreateStackWalk Method](icordebugthread3-createstackwalk-method.md)|Creates an [ICorDebugStackWalk](icordebugstackwalk-interface.md) object for the thread whose stack you want to unwind.|  
|[GetActiveInternalFrames Method](icordebugthread3-getactiveinternalframes-method.md)|Returns an array of internal frames ([ICorDebugInternalFrame2](icordebuginternalframe2-interface.md) objects) on the stack.|  
  
## Remarks  

 `ICorDebugThread3` is a logical extension to the ICorDebugThread interface.  
  
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
