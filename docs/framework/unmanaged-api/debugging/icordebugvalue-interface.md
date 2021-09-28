---
description: "Learn more about: ICorDebugValue Interface"
title: "ICorDebugValue Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugValue"
helpviewer_keywords: 
  - "ICorDebugValue interface [.NET Framework debugging]"
ms.assetid: b2f7007f-c446-4b18-aed1-a25cff8aee31
topic_type: 
  - "apiref"
---
# ICorDebugValue Interface

Represents a value in the process being debugged. The value can be a read or a write value.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[CreateBreakpoint Method](icordebugvalue-createbreakpoint-method.md)|This method is not currently implemented.|  
|[GetAddress Method](icordebugvalue-getaddress-method.md)|Gets the address of this `ICorDebugValue` object, which is in the process of being debugged.|  
|[GetSize Method](icordebugvalue-getsize-method.md)|Gets the size, in bytes, of this `ICorDebugValue` object.|  
|[GetType Method](icordebugvalue-gettype-method.md)|Gets the primitive type of this `ICorDebugValue` object.|  
  
## Remarks  

 In general, ownership of a value object is passed when it is returned. The recipient is responsible for removing a reference from the object when it is finished with the object.  
  
 Depending on where the value was retrieved from, the value may not remain valid after the process is resumed. So, in general, the value shouldn't be held across a call of the [ICorDebugController::Continue](icordebugcontroller-continue-method.md) method.  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICorDebugValue3 Interface](icordebugvalue3-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
