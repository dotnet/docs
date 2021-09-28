---
description: "Learn more about: ICorDebugModuleBreakpoint Interface"
title: "ICorDebugModuleBreakpoint Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugModuleBreakpoint"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugModuleBreakpoint"
helpviewer_keywords: 
  - "ICorDebugModuleBreakpoint interface [.NET Framework debugging]"
ms.assetid: 34667162-f314-475f-ae1b-ce9cb0fcbb83
topic_type: 
  - "apiref"
---
# ICorDebugModuleBreakpoint Interface

Provides access to specific modules. This interface is a subclass of the ICorDebugBreakpoint interface.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetModule Method](icordebugmodulebreakpoint-getmodule-method.md)|Gets an interface pointer to an ICorDebugModule that references the module where this breakpoint is set.|  
  
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
