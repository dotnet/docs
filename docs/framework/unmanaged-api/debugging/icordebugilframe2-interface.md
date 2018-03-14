---
title: "ICorDebugILFrame2 Interface1"
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
  - "ICorDebugILFrame2"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugILFrame2"
helpviewer_keywords: 
  - "ICorDebugILFrame2 interface [.NET Framework debugging]"
ms.assetid: f94b9d53-d8f8-4424-a95e-53a1bfd26e4a
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugILFrame2 Interface1
A logical extension of the ICorDebugILFrame interface.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[EnumerateTypeParameters Method](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe2-enumeratetypeparameters-method.md)|Gets an ICorDebugTypeEnum object that contains the <xref:System.Type> parameters in this frame.|  
|[RemapFunction Method](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe2-remapfunction-method.md)|Remaps an edited function by specifying the new MSIL offset.|  
  
## Remarks  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
