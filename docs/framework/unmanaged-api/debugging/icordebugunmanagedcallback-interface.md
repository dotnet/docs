---
description: "Learn more about: ICorDebugUnmanagedCallback Interface"
title: "ICorDebugUnmanagedCallback Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugUnmanagedCallback"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugUnmanagedCallback"
helpviewer_keywords: 
  - "ICorDebugUnmanagedCallback interface [.NET Framework debugging]"
ms.assetid: bc71cbca-7d73-40e5-84dd-2109fade3c2a
topic_type: 
  - "apiref"
---
# ICorDebugUnmanagedCallback Interface

Provides notification of native events that are not directly related to the common language runtime (CLR).  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[DebugEvent Method](icordebugunmanagedcallback-debugevent-method.md)|Notifies the debugger that a native event has been fired.|  
  
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
