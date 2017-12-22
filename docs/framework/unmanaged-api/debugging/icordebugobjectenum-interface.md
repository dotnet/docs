---
title: "ICorDebugObjectEnum Interface1"
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
  - "ICorDebugObjectEnum"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugObjectEnum"
helpviewer_keywords: 
  - "ICorDebugObjectEnum interface [.NET Framework debugging]"
ms.assetid: 9ffb4498-7719-49d3-8890-df2c22248a0c
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugObjectEnum Interface1
Implements ICorDebugEnum methods, and enumerates arrays of objects by their relative virtual addresses (RVAs).  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Next Method](../../../../docs/framework/unmanaged-api/debugging/icordebugobjectenum-next-method.md)|Gets the RVAs of the specified number of objects from the enumeration, starting at the current position.|  
  
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
