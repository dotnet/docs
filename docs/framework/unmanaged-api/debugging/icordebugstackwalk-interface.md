---
title: "ICorDebugStackWalk Interface"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ICorDebugStackWalk"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugStackWalk"
helpviewer_keywords: 
  - "ICorDebugStackWalk interface [.NET Framework debugging]"
ms.assetid: 16d695e8-975d-431b-8421-e9e6c3e3f476
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugStackWalk Interface
Provides methods for getting the managed methods, or frames, on a thread’s stack.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetContext Method](../../../../docs/framework/unmanaged-api/debugging/icordebugstackwalk-getcontext-method.md)|Returns the context for the current frame in the `ICorDebugStackWalk` object.|  
|[SetContext Method](../../../../docs/framework/unmanaged-api/debugging/icordebugstackwalk-setcontext-method.md)|Sets the `ICorDebugStackWalk` object’s current context to a valid context for the thread.|  
|[Next Method](../../../../docs/framework/unmanaged-api/debugging/icordebugstackwalk-next-method.md)|Moves the `ICorDebugStackWalk` object to the next frame.|  
|[GetFrame Method](../../../../docs/framework/unmanaged-api/debugging/icordebugstackwalk-getframe-method.md)|Gets the current frame in the `ICorDebugStackWalk` object.|  
  
## Remarks  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
