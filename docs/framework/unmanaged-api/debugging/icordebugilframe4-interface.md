---
description: "Learn more about: ICorDebugILFrame4 Interface"
title: "ICorDebugILFrame4 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugILFrame4"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
ms.assetid: 1e739183-3e05-49e5-846f-4075256e41de
topic_type: 
  - "apiref"
---
# ICorDebugILFrame4 Interface

[Supported in the .NET Framework 4.5.2 and later versions]  
  
 Provides methods that allow you to access the local variables and code in a stack frame of intermediate language (IL) code. A parameter specifies whether the debugger has access to variables and code added in profiler ReJIT instrumentation.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[EnumerateLocalVariablesEx Method](icordebugilframe4-enumeratelocalvariablesex-method.md)|Returns a list of the local variables available in the current frame.|  
|[GetCodeEx Method](icordebugilframe4-getcodeex-method.md)|Returns the code that this stack frame is running.|  
|[GetLocalVariableEx Method](icordebugilframe4-getlocalvariableex-method.md)|Returns the value of a local variable in the IL frame.|  
  
## Remarks  

 These methods offer functionality in addition to that provided by the [EnumerateLocalVariables](icordebugilframe-enumeratelocalvariables-method.md), [GetCode](icordebugframe-getcode-method.md), and [GetLocalVariable](icordebugilframe-getlocalvariable-method.md) methods. Each method includes a `flags` parameter that specifies whether additional local variables or code defined by a profiler's ReJIT request are visible.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v452plus](../../../../includes/net-current-v452plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
