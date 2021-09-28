---
description: "Learn more about: ICorDebugValueBreakpoint Interface"
title: "ICorDebugValueBreakpoint Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugValueBreakpoint"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugValueBreakpoint"
helpviewer_keywords: 
  - "ICorDebugValueBreakpoint interface [.NET Framework debugging]"
ms.assetid: c02338fe-da6c-467f-9567-70ebb387e901
topic_type: 
  - "apiref"
---
# ICorDebugValueBreakpoint Interface

Extends the ICorDebugBreakpoint interface to provide access to specific values.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetValue Method](icordebugvaluebreakpoint-getvalue-method.md)|Gets an interface pointer to an ICorDebugValue object that represents the value of the object upon which the breakpoint is set.|  
  
## Remarks  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
