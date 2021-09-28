---
description: "Learn more about: ICorDebugInternalFrame2 Interface"
title: "ICorDebugInternalFrame2 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugInternalFrame2"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugInternalFrame2"
helpviewer_keywords: 
  - "ICorDebugInternalFrame2 interface [.NET Framework debugging]"
ms.assetid: d4755569-85b8-4ff4-bf50-0e608e76429f
topic_type: 
  - "apiref"
---
# ICorDebugInternalFrame2 Interface

Provides information about internal frames, including stack address and position in relation to ICorDebugFrame objects.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetFrameAddress Method](icordebuginternalframe2-getframeaddress-method.md)|Returns the stack address of the internal frame.|  
|[IsCloserToLeaf Method](icordebuginternalframe2-isclosertoleaf-method.md)|Checks whether the `this` internal frame is closer to the leaf than the specified ICorDebugFrame object.|  
  
## Remarks  

 This interface extends the ICorDebugInternalFrame interface.  
  
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
