---
title: "ICorDebugInternalFrame2 Interface"
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
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugInternalFrame2 Interface
Provides information about internal frames, including stack address and position in relation to ICorDebugFrame objects.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetFrameAddress Method](../../../../docs/framework/unmanaged-api/debugging/icordebuginternalframe2-getframeaddress-method.md)|Returns the stack address of the internal frame.|  
|[IsCloserToLeaf Method](../../../../docs/framework/unmanaged-api/debugging/icordebuginternalframe2-isclosertoleaf-method.md)|Checks whether the `this` internal frame is closer to the leaf than the specified ICorDebugFrame object.|  
  
## Remarks  
 This interface extends the ICorDebugInternalFrame interface.  
  
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
