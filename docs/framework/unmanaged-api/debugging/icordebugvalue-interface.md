---
title: "ICorDebugValue Interface1"
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
  - "ICorDebugValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugValue"
helpviewer_keywords: 
  - "ICorDebugValue interface [.NET Framework debugging]"
ms.assetid: b2f7007f-c446-4b18-aed1-a25cff8aee31
topic_type: 
  - "apiref"
caps.latest.revision: 17
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugValue Interface1
Represents a value in the process being debugged. The value can be a read or a write value.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[CreateBreakpoint Method](../../../../docs/framework/unmanaged-api/debugging/icordebugvalue-createbreakpoint-method.md)|This method is not currently implemented.|  
|[GetAddress Method](../../../../docs/framework/unmanaged-api/debugging/icordebugvalue-getaddress-method.md)|Gets the address of this `ICorDebugValue` object, which is in the process of being debugged.|  
|[GetSize Method](../../../../docs/framework/unmanaged-api/debugging/icordebugvalue-getsize-method.md)|Gets the size, in bytes, of this `ICorDebugValue` object.|  
|[GetType Method](../../../../docs/framework/unmanaged-api/debugging/icordebugvalue-gettype-method.md)|Gets the primitive type of this `ICorDebugValue` object.|  
  
## Remarks  
 In general, ownership of a value object is passed when it is returned. The recipient is responsible for removing a reference from the object when it is finished with the object.  
  
 Depending on where the value was retrieved from, the value may not remain valid after the process is resumed. So, in general, the value shouldn't be held across a call of the [ICorDebugController::Continue](../../../../docs/framework/unmanaged-api/debugging/icordebugcontroller-continue-method.md) method.  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
    
    
    
    
 [ICorDebugValue3 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugvalue3-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
