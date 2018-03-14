---
title: "ICorDebugRegisterSet Interface"
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
  - "ICorDebugRegisterSet"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugRegisterSet"
helpviewer_keywords: 
  - "ICorDebugRegisterSet interface [.NET Framework debugging]"
ms.assetid: d3d9676d-0b87-4bc3-b679-7bbc7a186c88
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugRegisterSet Interface
Represents the set of registers available on the computer that is currently executing code.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetRegisters Method](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset-getregisters-method.md)|Gets the value of each register (on the computer that is currently executing code) that is specified by the bit mask.|  
|[GetRegistersAvailable Method](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset-getregistersavailable-method.md)|Gets a bit mask indicating which registers in this `ICorDebugRegisterSet` are currently available.|  
|[GetThreadContext Method](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset-getthreadcontext-method.md)|Gets the context of the current thread.|  
|[SetRegisters Method](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset-setregisters-method.md)|Not implemented for the .NET Framework version 2.0.|  
|[SetThreadContext Method](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset-setthreadcontext-method.md)|Not implemented for the .NET Framework 2.0.|  
  
## Remarks  
 The `ICorDebugRegisterSet` interface supports only 32-bit registers. Use the [ICorDebugRegisterSet2](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset2-interface.md) interface on platforms such as IA-64 that require additional registers.  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [ICorDebugRegisterSet2 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset2-interface.md)
