---
title: "ICorDebugILFrame4 Interface"
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
  - "ICorDebugILFrame4"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
ms.assetid: 1e739183-3e05-49e5-846f-4075256e41de
topic_type: 
  - "apiref"
caps.latest.revision: 5
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugILFrame4 Interface
[Supported in the .NET Framework 4.5.2 and later versions]  
  
 Provides methods that allow you to access the local variables and code in a stack frame of intermediate language (IL) code. A parameter specifies whether the debugger has access to variables and code added in profiler ReJIT instrumentation.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[EnumerateLocalVariablesEx Method](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe4-enumeratelocalvariablesex-method.md)|Returns a list of the local variables available in the current frame.|  
|[GetCodeEx Method](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe4-getcodeex-method.md)|Returns the code that this stack frame is running.|  
|[GetLocalVariableEx Method](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe4-getlocalvariableex-method.md)|Returns the value of a local variable in the IL frame.|  
  
## Remarks  
 These methods offer functionality in addition to that provided by the [EnumerateLocalVariables](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe-enumeratelocalvariables-method.md), [GetCode](../../../../docs/framework/unmanaged-api/debugging/icordebugframe-getcode-method.md), and [GetLocalVariable](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe-getlocalvariable-method.md) methods. Each method includes a `flags` parameter that specifies whether additional local variables or code defined by a profiler's ReJIT request are visible.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v452plus](../../../../includes/net-current-v452plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
