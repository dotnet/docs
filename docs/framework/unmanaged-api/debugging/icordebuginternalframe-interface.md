---
description: "Learn more about: ICorDebugInternalFrame Interface"
title: "ICorDebugInternalFrame Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugInternalFrame"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugInternalFrame"
helpviewer_keywords: 
  - "ICorDebugInternalFrame interface [.NET Framework debugging]"
ms.assetid: bb4772ca-0d54-4185-b738-7a6ffe9ea85a
topic_type: 
  - "apiref"
---
# ICorDebugInternalFrame Interface

Represents a runtime-internal frame on the stack. This interface is a subclass of the ICorDebugFrame interface.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetFrameType Method](icordebuginternalframe-getframetype-method.md)|Gets the type of this internal frame.|  
  
## Remarks  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
