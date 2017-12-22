---
title: "ICorDebugCodeEnum Interface1"
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
  - "ICorDebugCodeEnum"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugCodeEnum"
helpviewer_keywords: 
  - "ICorDebugCodeEnum interface [.NET Framework debugging]"
ms.assetid: b5589171-a4a0-4c00-bbdc-6e0a42233b75
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugCodeEnum Interface1
Implements "ICorDebugEnum" methods, and enumerates "ICorDebugCode" arrays.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Next Method](../../../../docs/framework/unmanaged-api/debugging/icordebugcodeenum-next-method.md)|Gets the specified number of `ICorDebugCode` instances from the enumeration, starting at the current position.|  
  
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
