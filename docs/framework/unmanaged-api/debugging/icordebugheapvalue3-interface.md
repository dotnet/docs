---
description: "Learn more about: ICorDebugHeapValue3 Interface"
title: "ICorDebugHeapValue3 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugHeapValue3"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugHeapValue3"
helpviewer_keywords: 
  - "ICorDebugHeapValue3 interface [.NET Framework debugging]"
ms.assetid: 9c421bb0-e647-4b2d-a986-f3d578cc7f20
topic_type: 
  - "apiref"
---
# ICorDebugHeapValue3 Interface

Exposes the monitor lock properties of objects. This interface extends the ICorDebugHeapValue and ICorDebugHeapValue2 interfaces.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetThreadOwningMonitorLock Method](icordebugheapvalue3-getthreadowningmonitorlock-method.md)|Returns the managed thread that owns the monitor lock on this object.|  
|[GetMonitorEventWaitList Method](icordebugheapvalue3-getmonitoreventwaitlist-method.md)|Provides an ordered list of threads that are queued on the event that is associated with a monitor lock.|  
  
## Remarks  
  
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
