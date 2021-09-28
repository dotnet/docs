---
description: "Learn more about: ICorDebugILFrame3 Interface"
title: "ICorDebugILFrame3 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugILFrame3"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
ms.assetid: 15212cb5-93d4-4025-bec9-d4b9919eb1fe
topic_type: 
  - "apiref"
---
# ICorDebugILFrame3 Interface

Provides a method that encapsulates the return value of a function. `ICorDebugILFrame3` is a logical extension of the ICorDebugILFrame and ICorDebugILFrame2 interfaces.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetReturnValueForILOffset Method](icordebugilframe3-getreturnvalueforiloffset-method.md)|Gets an ICorDebugValue object that encapsulates the return value of a function.|  
  
## Remarks  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v451plus](../../../../includes/net-current-v451plus-md.md)]  
  
## See also

- [ICorDebugCode3 Interface](icordebugcode3-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
