---
title: "ICorDebugFunction2 Interface1"
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
  - "ICorDebugFunction2"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFunction2"
helpviewer_keywords: 
  - "ICorDebugFunction2 interface [.NET Framework debugging]"
ms.assetid: 2b936bef-9b75-48bf-859f-42e419c65f1c
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugFunction2 Interface1
Logically extends the ICorDebugFunction interface to provide support for Just My Code step-through debugging, which skips non-user code.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[EnumerateNativeCode Method](../../../../docs/framework/unmanaged-api/debugging/icordebugfunction2-enumeratenativecode-method.md)|(Not yet implemented.) Gets an interface pointer to an ICorDebugCodeEnum that contains the native code statements in the function referenced by this ICorDebugFunction2 object.|  
|[GetJMCStatus Method](../../../../docs/framework/unmanaged-api/debugging/icordebugfunction2-getjmcstatus-method.md)|Gets a value that indicates whether this function is marked as user code.|  
|[GetVersionNumber Method](../../../../docs/framework/unmanaged-api/debugging/icordebugfunction2-getversionnumber-method.md)|Gets the Edit and Continue version of this function.|  
|[SetJMCStatus Method](../../../../docs/framework/unmanaged-api/debugging/icordebugfunction2-setjmcstatus-method.md)|Marks this function for Just My Code stepping.|  
  
## Remarks  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
