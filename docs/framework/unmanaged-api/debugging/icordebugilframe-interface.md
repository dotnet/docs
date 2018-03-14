---
title: "ICorDebugILFrame Interface1"
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
  - "ICorDebugILFrame"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugILFrame"
helpviewer_keywords: 
  - "ICorDebugILFrame interface [.NET Framework debugging]"
ms.assetid: d5cf5056-da4d-4629-914d-afe42a5393df
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugILFrame Interface1
Represents a stack frame of Microsoft intermediate language (MSIL) code. This interface is a subclass of the ICorDebugFrame interface.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[CanSetIP Method](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe-cansetip-method.md)|Gets a value that indicates whether it is safe to set the instruction pointer to the specified offset location.|  
|[EnumerateArguments Method](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe-enumeratearguments-method.md)|Gets an enumerator for the arguments in this frame.|  
|[EnumerateLocalVariables Method](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe-enumeratelocalvariables-method.md)|Gets an enumerator for the local variables in this frame.|  
|[GetArgument Method](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe-getargument-method.md)|Gets the value of the specified argument in this MSIL stack frame.|  
|[GetIP Method](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe-getip-method.md)|Gets the value of the instruction pointer and a bitwise combination value that describes how the value of the instruction pointer was obtained.|  
|[GetLocalVariable Method](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe-getlocalvariable-method.md)|Gets the value of the specified local variable in this MSIL stack frame.|  
|[GetStackDepth Method](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe-getstackdepth-method.md)|Not implemented.|  
|[GetStackValue Method](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe-getstackvalue-method.md)|Not implemented.|  
|[SetIP Method](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe-setip-method.md)|Sets the instruction pointer to the specified offset location in the MSIL code.|  
  
## Remarks  
 The `ICorDebugILFrame` interface is a specialized ICorDebugFrame interface. It is used either for MSIL code frames or for just-in-time (JIT) compiled frames. The JIT-compiled frames implement both the `ICorDebugILFrame` interface and the ICorDebugNativeFrame interface.  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
