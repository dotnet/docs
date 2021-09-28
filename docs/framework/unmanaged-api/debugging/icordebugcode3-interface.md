---
description: "Learn more about: ICorDebugCode3 Interface"
title: "ICorDebugCode3 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugCode3"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugCode3"
helpviewer_keywords: 
  - "ICorDebugCode3 interface [.NET Framework debugging]"
ms.assetid: 70f07c9e-0614-4bee-ac34-09fe6c51c5a9
topic_type: 
  - "apiref"
---
# ICorDebugCode3 Interface

Provides a method that extends "ICorDebugCode" and "ICorDebugCode2" to provide information about a managed return value.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetReturnValueLiveOffset Method](icordebugcode3-getreturnvalueliveoffset-method.md)|For a specified IL offset, gets the native offsets where a breakpoint should be placed so that the debugger can obtain the return value from a function.|  
  
## Remarks  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v451plus](../../../../includes/net-current-v451plus-md.md)]  
  
## See also

- [ICorDebugILFrame3 Interface](icordebugilframe3-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
